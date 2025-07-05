using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject panelUI;         // Panel instruksi + tombol
    public mobil mobilScript;          // Referensi ke script mobil
    public GameObject tombolPlay;      // Tombol itu sendiri

    public void OnPlayButtonClicked()
    {
        panelUI.SetActive(false);      // Hilangkan panel
        mobilScript.MulaiGame();       // Panggil fungsi mulai dari mobil
        tombolPlay.SetActive(false);   // Sembunyikan tombol
    }
}

