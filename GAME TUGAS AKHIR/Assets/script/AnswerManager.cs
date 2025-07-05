using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerManager : MonoBehaviour
{
    public GameController gameController;
    public bool isCorrect; // atur ini dari inspector (true = jawaban benar)

    public void CheckAnswer()
    {
        if (isCorrect)
        {
            Debug.Log("Jawaban benar!");
            // lanjutkan game atau beri poin
        }
        else
        {
            Debug.Log("Jawaban salah! Restart level.");
            gameController.RestartGame();
        }
    }
}
