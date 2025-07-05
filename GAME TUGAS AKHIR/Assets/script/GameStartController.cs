using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStartController : MonoBehaviour
{
    public GameObject instructionScreen; // Referensi ke layar instruksi
    // Start is called before the first frame update
    void Start()
    {
        // Menampilkan layar instruksi saat game dimulai
        instructionScreen.SetActive(true);
    }
    public void StartGame()
    {
        // Menghilangkan layar instruksi dan mulai permainan
        instructionScreen.SetActive(false);
    }
}


