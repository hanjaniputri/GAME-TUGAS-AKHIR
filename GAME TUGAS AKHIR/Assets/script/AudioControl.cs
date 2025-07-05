using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Button soundOnButton;
    public Button soundOffButton;
    // Start is called before the first frame update
    void Start()
    {
        // Set event listener untuk tombol
        soundOnButton.onClick.AddListener(PlayAudio);
        soundOffButton.onClick.AddListener(PauseAudio);

        // Pastikan suara dimulai sesuai dengan tombol yang harus ditampilkan
        audioSource.Play();
        soundOnButton.gameObject.SetActive(false);  // Sembunyikan tombol On jika audio sedang dimainkan
    }

    void PlayAudio()
    {
        audioSource.Play();
        soundOnButton.gameObject.SetActive(false);  // Sembunyikan tombol ON
        soundOffButton.gameObject.SetActive(true);  // Tampilkan tombol OFF
    }

    void PauseAudio()
    {
        audioSource.Pause();
        soundOffButton.gameObject.SetActive(false);  // Sembunyikan tombol OFF
        soundOnButton.gameObject.SetActive(true);  // Tampilkan tombol ON
    }
}


