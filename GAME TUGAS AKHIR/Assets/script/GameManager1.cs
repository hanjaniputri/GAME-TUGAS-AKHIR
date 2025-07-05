using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;

    public GameObject endGamePanel; // drag dari Inspector

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static GameManager1 GetInstance()
    {
        return instance;
    }

    public void ShowEndGame()
    {
        Debug.Log("Game selesai ditampilkan.");
        endGamePanel.SetActive(true); // tampilkan panel akhir
        Time.timeScale = 0f; // (opsional) berhentikan game
    }
    public void KeluarKeMenu()
    {
        Time.timeScale = 1f; // pastikan game berjalan normal lagi
        SceneManager.LoadScene("menu"); // ganti dengan nama scene menu awal kamu
    }
}
