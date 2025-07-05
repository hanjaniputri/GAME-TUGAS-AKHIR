using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Fungsi untuk restart game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Fungsi untuk kembali ke pengaturan game level
    public void BackToLevelSettings()
    {
        // Ganti "LevelSelectionScene" dengan nama scene yang sesuai
        SceneManager.LoadScene("Bermain");
    }
}
