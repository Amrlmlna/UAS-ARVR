using UnityEngine;

public class SimpleTouchButton : MonoBehaviour
{
    public ARSpeakerManager musicManager; // Otaknya
    
    // Efek visual mendlep
    private Vector3 originalPos;
    private void Start() { originalPos = transform.localPosition; }

    // Fungsi Bawaan Unity: Mendeteksi sentuhan jari/klik mouse pada objek ini
    private void OnMouseDown()
    {
        // Efek tombol turun
        transform.localPosition = originalPos - new Vector3(0, 0.01f, 0);

        // Panggil Manager buat Play Musik
        if (musicManager != null)
        {
            musicManager.TogglePlayPause();
            Debug.Log("Tombol Disentuh!");
        }
    }

    private void OnMouseUp()
    {
        // Tombol naik lagi
        transform.localPosition = originalPos;
    }
}