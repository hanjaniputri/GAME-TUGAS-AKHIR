using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGame : MonoBehaviour
{
    public int score = 0;
    public int totalRambu = 5;  // total rambu yang harus dijawab
    public Text scoreText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    void Start()
    {
        UpdateScoreText();
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
    }
    public void JawabanBenar()
    {
        score++;
        UpdateScoreText();

        if (score >= totalRambu)
        {
            Menang();
        }
    }

    public void JawabanSalah()
    {
        GameOver();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;  // game berhenti
    }

    void Menang()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;  // game berhenti
    }
}