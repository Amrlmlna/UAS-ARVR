using UnityEngine;
using System.Collections.Generic;

public class ARSpeakerManager : MonoBehaviour
{
    [Header("Playlist (Otomatis Terisi)")]
    public AudioClip[] musicPlaylist; 

    [Header("Status Player")]
    public bool isPlaying = false;
    public string currentSongName;

    private int currentSongIndex = 0;
    private float currentTrackTime = 0f;

    void Start()
    {
        // MAGIC LINE: Ini perintah buat ambil semua lagu di folder "Resources/Music"
        musicPlaylist = Resources.LoadAll<AudioClip>("Music");

        if (musicPlaylist.Length > 0)
        {
            Debug.Log("Berhasil load " + musicPlaylist.Length + " lagu dari folder Music!");
            currentSongName = musicPlaylist[0].name;
        }
        else
        {
            Debug.LogError("Folder 'Resources/Music' kosong boss! Masukin lagu dulu.");
        }
    }

    public void TogglePlayPause()
    {
        GameObject[] activeSpeakers = GameObject.FindGameObjectsWithTag("Speakers");

        if (activeSpeakers.Length == 0) return;

        isPlaying = !isPlaying;

        foreach (GameObject speaker in activeSpeakers)
        {
            AudioSource audio = speaker.GetComponent<AudioSource>();
            if (audio != null)
            {
                if (isPlaying)
                {
                    // Kalau lagu kosong, isi pakai playlist yang udah di-load otomatis
                    if (audio.clip == null && musicPlaylist.Length > 0) 
                    {
                        audio.clip = musicPlaylist[currentSongIndex];
                    }
                    
                    audio.time = currentTrackTime;
                    audio.Play();
                }
                else
                {
                    currentTrackTime = audio.time;
                    audio.Pause();
                }
            }
        }
    }

    public void NextSong()
    {
        if (musicPlaylist.Length == 0) return;

        currentSongIndex++;
        if (currentSongIndex >= musicPlaylist.Length) currentSongIndex = 0;

        currentTrackTime = 0f;
        currentSongName = musicPlaylist[currentSongIndex].name;

        // Update semua speaker
        GameObject[] activeSpeakers = GameObject.FindGameObjectsWithTag("Speakers");
        foreach (GameObject speaker in activeSpeakers)
        {
            AudioSource audio = speaker.GetComponent<AudioSource>();
            if (audio != null)
            {
                audio.clip = musicPlaylist[currentSongIndex];
                audio.time = 0f;
                if (isPlaying) audio.Play();
            }
        }
    }

    // Biar sinkron terus waktunya
    void Update()
    {
        if (isPlaying)
        {
            GameObject speaker = GameObject.FindGameObjectWithTag("Speakers");
            if (speaker != null && speaker.GetComponent<AudioSource>().isPlaying)
            {
                currentTrackTime = speaker.GetComponent<AudioSource>().time;
            }
        }
    }
}