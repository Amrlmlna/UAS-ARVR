using UnityEngine;
using System.Collections.Generic;

public class ARSpeakerManager : MonoBehaviour
{
    [Header("Playlist (Auto-Loaded)")]
    public AudioClip[] musicPlaylist; // Bakal keisi otomatis

    [Header("Status")]
    public bool isPlaying = false;
    private int currentSongIndex = 0;
    private float currentTrackTime = 0f; // Biar sinkron waktu lagunya

    void Start()
    {
        // 1. LOAD LAGU DARI FOLDER 'Assets/Resources/Music'
        // Pastikan lu udah bikin folder "Music" di dalam folder "Resources"
        musicPlaylist = Resources.LoadAll<AudioClip>("Music");

        if (musicPlaylist.Length > 0)
        {
            Debug.Log("Sukses Load " + musicPlaylist.Length + " Lagu!");
        }
        else
        {
            Debug.LogError("Folder Resources/Music KOSONG atau Gak Ada! Masukin file .mp3 dulu.");
        }
    }

    public void TogglePlayPause()
    {
        // Cari semua benda yang punya Tag "Speakers"
        GameObject[] activeSpeakers = GameObject.FindGameObjectsWithTag("Speakers");

        if (activeSpeakers.Length == 0) 
        {
            Debug.LogWarning("Belum ada speaker yang discan!");
            return;
        }

        isPlaying = !isPlaying; // Switch Nyala/Mati

        foreach (GameObject speaker in activeSpeakers)
        {
            AudioSource audio = speaker.GetComponent<AudioSource>();
            if (audio != null)
            {
                if (isPlaying)
                {
                    // Kalau audionya masih kosong, isi pake playlist
                    if (audio.clip == null && musicPlaylist.Length > 0)
                    {
                        audio.clip = musicPlaylist[currentSongIndex];
                    }

                    audio.time = currentTrackTime; // Samain detiknya
                    audio.Play();
                }
                else
                {
                    currentTrackTime = audio.time; // Simpan posisi detik terakhir
                    audio.Pause();
                }
            }
        }
    }

    // Biar kalo ada speaker baru muncul (baru di-scan), dia langsung gabung nyanyi
    void Update()
    {
        if (isPlaying)
        {
            // Update timer track dari salah satu speaker yang aktif
            GameObject speaker = GameObject.FindGameObjectWithTag("Speakers");
            if (speaker != null)
            {
                AudioSource src = speaker.GetComponent<AudioSource>();
                if (src.isPlaying) currentTrackTime = src.time;
            }
        }
    }
}