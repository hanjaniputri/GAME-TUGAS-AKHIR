using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextTimer : MonoBehaviour
{
    public Text timerText;  // Referensi ke UI Text untuk menampilkan waktu
    public GameObject startButton;  // Tombol Start
    public GameObject instructionPanel;  // Panel Instruksi
    private float timeLeft = 100f; // Set waktu countdown, misalnya 200 detik
    private bool gameStarted = false;  // Status apakah game sudah dimulai

    // Start is called before the first frame update
    void Start()
    {
        // Menyembunyikan tombol dan panel instruksi saat game dimulai
        startButton.SetActive(true);
        instructionPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted && timeLeft > 0)
        {
            // Mengurangi waktu setiap frame
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Floor(timeLeft).ToString();  // Update teks timer
        }
        else if (timeLeft <= 0)
        {
            // Jika waktu habis
            timerText.text = "Time's Up!";
            // Anda bisa tambahkan kode untuk mengakhiri permainan di sini
        }
    }

    public void StartGame()
    {
        // Mulai game, sembunyikan tombol start dan instruksi
        startButton.SetActive(false);
        instructionPanel.SetActive(false);
        gameStarted = true;  // Set status game menjadi dimulai
    }
}

