using UnityEngine;
using Vuforia;

public class RuntimeButtonBuilder : MonoBehaviour
{
    public ARSpeakerManager musicManager; // Tarik MusicManager ke sini
    
    // Setting area tombol (0,0 = Tengah Marker)
    public string buttonName = "PlayBtn";
    public Vector2 buttonPosition = new Vector2(0f, 0f); 
    public Vector2 buttonSize = new Vector2(0.2f, 0.2f); // Area sentuh agak gede

    void Start()
    {
        var imageTarget = GetComponent<ImageTargetBehaviour>();
        if (imageTarget != null)
        {
            // Bikin tombol secara coding
            var btn = imageTarget.CreateVirtualButton(buttonName, 
                      new Rect(buttonPosition.x, buttonPosition.y, buttonSize.x, buttonSize.y));
            
            // Daftarkan event tekan
            btn.RegisterOnButtonPressed(OnPressed);
            Debug.Log("Tombol Virtual Siap di Marker ini!");
        }
    }

    public void OnPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("TOMBOL DITEKAN!");
        if (musicManager != null) musicManager.TogglePlayPause();
    }
}