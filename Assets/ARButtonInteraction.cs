using UnityEngine;
using Vuforia; // WAJIB ADA biar kenal sama Virtual Button

[RequireComponent(typeof(VirtualButtonBehaviour))] 
public class ARButtonInteraction : MonoBehaviour

public class ARButtonInteraction : MonoBehaviour
{
    [Header("Hubungkan ke Sini")]
    public ARSpeakerManager musicManager; // Tarik objek MusicManager ke sini
    public Transform buttonVisual; // Tarik objek Kubus/Plane tombol kamu ke sini

    private VirtualButtonBehaviour vbBehaviour;
    private Vector3 originalPosition;

    void Start()
    {
        // Cari komponen Virtual Button di objek ini
        vbBehaviour = GetComponent<VirtualButtonBehaviour>();

        // Simpan posisi awal tombol visual biar bisa balik lagi
        if (buttonVisual != null) 
        {
            originalPosition = buttonVisual.localPosition;
        }

        // Daftarkan fungsi kita ke Event System-nya Vuforia
        if (vbBehaviour != null)
        {
            vbBehaviour.RegisterOnButtonPressed(OnButtonPressed);
            vbBehaviour.RegisterOnButtonReleased(OnButtonReleased);
        }
        else
        {
            Debug.LogError("Waduh! Script ini harus ditempel di objek yang punya 'VirtualButtonBehaviour'!");
        }
    }

    // Dipanggil otomatis pas jempol nutupin marker
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Tombol Ditekan!");

        // 1. Efek Visual (Tombol Turun sedikit) -> Konsep Physics Interaction
        if (buttonVisual != null)
        {
            // Turunkan posisi Y sedikit (sesuaikan angkanya kalau kejauhan)
            buttonVisual.localPosition = originalPosition - new Vector3(0, 0.01f, 0); 
        }

        // 2. Panggil Musik
        if (musicManager != null)
        {
            musicManager.TogglePlayPause();
        }
    }

    // Dipanggil otomatis pas jempol diangkat
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Tombol Dilepas!");

        // Balikin tombol ke posisi semula
        if (buttonVisual != null)
        {
            buttonVisual.localPosition = originalPosition;
        }
    }
}