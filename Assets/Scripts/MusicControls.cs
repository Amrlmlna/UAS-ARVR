using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MusicControls : MonoBehaviour
{
    public AudioClip clip; // The AudioClip you want to play
    private Song currentSong;
    public GameObject musicControlsMenu;

    public GameObject errorText;
    public TextMeshProUGUI songTimeText;
    public TextMeshProUGUI songTitleText;
    public TextMeshProUGUI nextUpText;
    public TextMeshProUGUI mainQueueText;
    private string formattedTimeText;

    private float currentTime;
    public bool nowPlaying;
    private AudioSource activeAudiosource;

    // Images
    public Image playButton;
    public Image rewindButton;
    public Image forwardButton;
    public Image seekBackButton;
    public Image seekForwardButton;
    public Sprite playButtonImage;
    public Sprite pauseButtonImage;

    // For music queue
    private List<Song> queue = new List<Song>();
    private int currentSongIndex = 0;
    private List<TextMeshProUGUI> queueTexts;

    void Start()
    {
        errorText?.SetActive(false);
        currentTime = 0f;
        nowPlaying = false;

        // Get all TextMeshProUGUI with tag "Queue Text". This is to update all canvases which display the queue
        queueTexts = new List<TextMeshProUGUI>();

        if (GameObject.FindGameObjectWithTag("Queue Text") != null)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Queue Text"))
            {
                queueTexts.AddRange(go.GetComponentsInChildren<TextMeshProUGUI>());
            }
        }

        // Add handheld queue text to list, since it will be inactive at start and will not be found by the above
        if (mainQueueText != null)
            queueTexts.Add(mainQueueText);
    }

    private void OnEnable()
    {
        if (errorText != null)
            errorText.SetActive(false);
    }

    private void Update()
    {
        UpdateMetadata();

        // Always check if the current song is over
        if (activeAudiosource && activeAudiosource.time >= activeAudiosource.clip.length - 0.05f)
        {
            SkipAudio();
        }
    }

    public void PlayPause()
    {
        // Find all GameObjects with the tag "Speakers"
        GameObject[] speakers = GameObject.FindGameObjectsWithTag("Speakers");

        if (speakers.Length == 0)
        {
            if (errorText != null)
                errorText.SetActive(true);
            return;
        }

        if (errorText != null)
            errorText.SetActive(false);

        // If any audio source is playing, pause all audio sources
        if (nowPlaying)
        {
            foreach (GameObject speaker in speakers)
            {
                AudioSource audioSource = speaker.GetComponent<AudioSource>();
                if (audioSource != null && audioSource.isPlaying)
                {
                    audioSource.Pause();
                }
            }

            nowPlaying = false;
        }
        // Otherwise, play the audio clip on all audio sources
        else
        {
            foreach (GameObject speaker in speakers)
            {
                AudioSource audioSource = speaker.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // Assign the clip to the AudioSource and play it
                    audioSource.clip = currentSong?.clip ?? clip;
                    if (activeAudiosource)
                    {
                        audioSource.time = activeAudiosource.time;
                    }

                    audioSource.Play();
                    activeAudiosource = audioSource;
                }
            }

            nowPlaying = true;
        }
        
        UpdatePlayButtonSprite();
    }

    public void RewindAudio()
    {
        if (activeAudiosource != null && activeAudiosource.time < 2f)
        {
            currentSongIndex--;

            if (currentSongIndex < 0)
            {
                currentSongIndex = queue.Count - 1;
            }

            // Set the new song
            currentSong = queue[currentSongIndex];
            clip = currentSong.clip;
        }

        GameObject[] speakers = GameObject.FindGameObjectsWithTag("Speakers");

        foreach (GameObject speaker in speakers)
        {
            AudioSource audioSource = speaker.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.clip = clip;
                audioSource.time = 0f;
                audioSource.Play();
                activeAudiosource = audioSource;
            }
        }

        nowPlaying = true;
        SetQueueText();
        UpdatePlayButtonSprite();
    }

    public void SkipAudio()
    {
        currentSongIndex++;
        if (currentSongIndex >= queue.Count)
        {
            currentSongIndex = 0;
        }

        currentSong = queue[currentSongIndex];
        clip = currentSong.clip;

        // Play the new song
        GameObject[] speakers = GameObject.FindGameObjectsWithTag("Speakers");

        foreach (GameObject speaker in speakers)
        {
            AudioSource audioSource = speaker.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.clip = clip;
                audioSource.time = 0f;
                audioSource.Play();
                activeAudiosource = audioSource;
            }
        }

        nowPlaying = true;
        SetQueueText();
        UpdatePlayButtonSprite();
    }

    void UpdateMetadata()
    {
        if (activeAudiosource != null && activeAudiosource.clip != null)
        {
            currentTime = activeAudiosource.time;
            float totalTime = (currentSong != null) ? currentSong.clip.length : 0f;

            string currentMinutes = Mathf.Floor(currentTime / 60).ToString("00");
            string currentSeconds = Mathf.Floor(currentTime % 60).ToString("00");

            string totalMinutes = Mathf.Floor(totalTime / 60).ToString("00");
            string totalSeconds = Mathf.Floor(totalTime % 60).ToString("00");

            formattedTimeText = currentMinutes + ":" + currentSeconds + " / " + totalMinutes + ":" + totalSeconds;
            if (songTimeText != null)
                songTimeText.text = formattedTimeText;

            if (songTitleText != null && currentSong != null)
            {
                string currentSongName = currentSong.name;
                // Truncate song name if it's too long
                if (currentSongName.Length > 30)
                {
                    currentSongName = currentSongName.Substring(0, 30) + "...";
                }
                songTitleText.text = currentSongName;
            }

            if (nextUpText != null && queue.Count > 0)
            {
                string nextUpName = queue[(currentSongIndex + 1) % queue.Count].name;
                if (nextUpName.Length > 25)
                {
                    nextUpName = nextUpName.Substring(0, 25) + "...";
                }
                nextUpText.text = "Next up: " + nextUpName;
            }
        }
    }

    // Function to handle new speaker being created while music is already playing
    public void CatchUpNewSpeaker(AudioSource newSpeaker)
    {
        if (nowPlaying && activeAudiosource != null)
        {
            newSpeaker.clip = (currentSong != null) ? currentSong.clip : clip;
            if (activeAudiosource != null)
                newSpeaker.time = activeAudiosource.time;
            newSpeaker.Play();
        }
    }

    public void SeekTenSeconds(bool forward)
    {
        GameObject[] speakers = GameObject.FindGameObjectsWithTag("Speakers");

        foreach (GameObject speaker in speakers)
        {
            AudioSource audioSource = speaker.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.clip = (currentSong != null) ? currentSong.clip : clip;

                if (!forward)
                {
                    if (audioSource.time < 10f)
                    {
                        audioSource.time = 0f;
                    }
                    else
                    {
                        audioSource.time -= 10f;
                    }
                }
                else if (audioSource.time + 10f > audioSource.clip.length)
                {
                    audioSource.time = audioSource.clip.length;
                }
                else
                {
                    audioSource.time += 10f;
                }
            }
        }
    }

    public void SetQueue(List<Song> newQueue)
    {
        queue = newQueue;

        if (queue.Count > 0)
        {
            currentSong = queue[currentSongIndex];
        }

        SetQueueText();
    }

    private void SetQueueText()
    {
        if (queueTexts == null || queueTexts.Count == 0 || queue.Count == 0) return;

        string queueString = "";
        int maxDisplay = Mathf.Min(10, queue.Count); // Show max 10 songs in queue
        for (int i = currentSongIndex; i < queue.Count && (i - currentSongIndex) < maxDisplay; i++)
        {
            if (i == currentSongIndex)
            {
                queueString += "<color=#fff07a>" + queue[i].name + "</color>\n";
            }
            else
            {
                queueString += queue[i].name + "\n";
            }
        }

        foreach (TextMeshProUGUI queueText in queueTexts)
        {
            queueText.text = queueString;
        }
    }

    public string GetSongName()
    {
        string songName;
        if (currentSong == null)
        {
            songName = "---";
        }
        else
        {
            songName = currentSong.name;
        }

        return songName;
    }

    public float[] GetTimeMetadata()
    {
        float[] metadata = new float[2];
        metadata[0] = currentTime;

        if (currentSong == null || currentSong.clip == null)
        {
            metadata[1] = 0f;
        }
        else
        {
            metadata[1] = currentSong.clip.length;
        }
        return metadata;
    }

    private void UpdatePlayButtonSprite()
    {
        if (playButton != null && playButtonImage != null && pauseButtonImage != null)
        {
            if (nowPlaying)
            {
                playButton.sprite = pauseButtonImage;
            }
            else
            {
                playButton.sprite = playButtonImage;
            }
        }
    }
}