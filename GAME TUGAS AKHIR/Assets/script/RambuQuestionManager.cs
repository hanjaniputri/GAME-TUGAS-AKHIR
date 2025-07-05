using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class RambuQuestionManager : Singleton<RambuQuestionManager>
{
    [Header("Component Reference")]
    [SerializeField] private RambuSpeechRecognition _rambuSpeechRecognition;
    //[SerializeField] private MoveCar _moveCar;
    [Header("Container Reference")]
    [SerializeField] private GameObject _questionContainer;
    [SerializeField] private GameObject _benarContainer;
    [SerializeField] private GameObject _salahContainer;
    [Header("Variables")]
    [SerializeField] private int _currentQuestionNumber = 0;
    [SerializeField] private string _question1Answer;
    [SerializeField] private string _question2Answer;
    [SerializeField] private string _question3Answer;
    [SerializeField] private string _question4Answer;
    [SerializeField] private string _question5Answer;
    [SerializeField] private string _question6Answer;
    [SerializeField] private string _question7Answer;
    [SerializeField] private string _question8Answer;
    [SerializeField] private string _question9Answer;
    [SerializeField] private string _question10Answer;
    [SerializeField] private string _question11Answer;
    [SerializeField] private string _question12Answer;
    [SerializeField] private string _question13Answer;
    [SerializeField] private string _question14Answer;
    [SerializeField] private string _question15Answer;
    [SerializeField] private string _question16Answer;
    [SerializeField] private string _question17Answer;
    //private int _score = 0;
    //[SerializeField] private TextMeshProUGUI _scoreText;
    //[SerializeField] private GameObject winPanel; // drag dari Inspector
    //[SerializeField] private int maxScore = 7; // ganti 7 dengan jumlah soal sebenarnya

    [Header("Lose UI per Rambu")]
    //[SerializeField] private GameObject scoreLose1;
    //[SerializeField] private GameObject scoreLose2;
    //[SerializeField] private GameObject scoreLose3;
    //[SerializeField] private GameObject scoreLose4;
    //[SerializeField] private GameObject scoreLose5;
    //[SerializeField] private GameObject scoreLose6;
    private bool _isGameOver = false;
    public bool IsGameOver => _isGameOver; // agar bisa diakses oleh script lain
    
    private void Start()
    {
        _currentQuestionNumber = 0;
    }

    public void InitializeQuestion()
    {
        if (IsLastQuestion())
        {
            Debug.Log("Pertanyaan terakhir selesai — game selesai.");
            GameManager1.GetInstance().ShowEndGame(); // Tampilkan panel akhir game
            return;
        }

            _currentQuestionNumber++;
        RambuManager.GetInstance().ChangeRambuSpriteByIndex(_currentQuestionNumber - 1);
        switch (_currentQuestionNumber)
        {
            case 1:
                _rambuSpeechRecognition.SetCorrectAnswer(_question1Answer);
                break;
            case 2:
                _rambuSpeechRecognition.SetCorrectAnswer(_question2Answer);
                break;
            case 3:
                _rambuSpeechRecognition.SetCorrectAnswer(_question3Answer);
                break;
            case 4:
                _rambuSpeechRecognition.SetCorrectAnswer(_question4Answer);
                break;
            case 5:
                _rambuSpeechRecognition.SetCorrectAnswer(_question5Answer);
                break;
            case 6:
                _rambuSpeechRecognition.SetCorrectAnswer(_question6Answer);
                break;
            case 7:
                _rambuSpeechRecognition.SetCorrectAnswer(_question7Answer);
                break;
            case 8:
                _rambuSpeechRecognition.SetCorrectAnswer(_question8Answer);
                break;
            case 9:
                _rambuSpeechRecognition.SetCorrectAnswer(_question9Answer);
                break;
            case 10:
                _rambuSpeechRecognition.SetCorrectAnswer(_question10Answer);
                break;
            case 11:
                _rambuSpeechRecognition.SetCorrectAnswer(_question11Answer);
                break;
            case 12:
                _rambuSpeechRecognition.SetCorrectAnswer(_question12Answer);
                break;
            case 13:
                _rambuSpeechRecognition.SetCorrectAnswer(_question13Answer);
                break;
            case 14:
                _rambuSpeechRecognition.SetCorrectAnswer(_question14Answer);
                break;
            case 15:
                _rambuSpeechRecognition.SetCorrectAnswer(_question15Answer);
                break;
            case 16:
                _rambuSpeechRecognition.SetCorrectAnswer(_question16Answer);
                break;
            case 17:
                _rambuSpeechRecognition.SetCorrectAnswer(_question17Answer);
                break;
            
        }

        _questionContainer.SetActive(true);
    }

    public void SetResult(bool isCorrect)
    {
        DeactiveAllUi();
        if (isCorrect)
        {
            //_score++;
            UpdateScoreUI(); //  tampilkan score
            _benarContainer.SetActive(true);
            //_moveCar.ResumeMoving();

        }
        else
        {
            _salahContainer.SetActive(true);
            TampilkanUILose(_currentQuestionNumber);
            _isGameOver = true; // game over saat salah
        }
        //if (_score >= maxScore) // misal skor penuh
        //{
        //    Debug.Log("You won the game");
        //    winPanel.SetActive(true); // munculkan tampilan menang
        //    _isGameOver = true; // game over karena menang
        //}

        StartCoroutine(DelayResumeGame(isCorrect));
    }
    private void TampilkanUILose(int rambuKe)
    {
        //switch (rambuKe)
        //{
        //    case 1:
        //        scoreLose1.SetActive(true);
        //        break;
        //    case 2:
        //        scoreLose2.SetActive(true);
        //        break;
        //    case 3:
        //        scoreLose3.SetActive(true);
        //        break;
        //    case 4:
        //        scoreLose4.SetActive(true);
        //        break;
        //    case 5:
        //        scoreLose5.SetActive(true);
        //        break;
        //    case 6:
        //        scoreLose6.SetActive(true);
        //        break;
            
        //}
    }
    private void UpdateScoreUI()
    {
        //_scoreText.text = "Score: " + _score.ToString();
    }
    private void DeactiveAllUi()
    {
        _benarContainer.SetActive(false);
        _salahContainer.SetActive(false);
        _questionContainer.SetActive(false);
    }

    IEnumerator DelayResumeGame(bool isCorrect)
    {
        yield return new WaitForSeconds(2);
        if (isCorrect)
        {
            _benarContainer.SetActive(false);

            if (_currentQuestionNumber == 7)
            {
                Debug.Log("You won the game");
            }
        }
        else
        {
            _salahContainer.SetActive(false);
           
            _questionContainer.SetActive(true);
        }
    }
        private void SembunyikanUILose(int rambuKe)
    {
        //switch (rambuKe)
        //{
        //    case 1:
        //        scoreLose1.SetActive(false);
        //        break;
        //    case 2:
        //        scoreLose2.SetActive(false);
        //        break;
        //    case 3:
        //        scoreLose3.SetActive(false);
        //        break;
        //    case 4:
        //        scoreLose4.SetActive(false);
        //        break;
        //    case 5:
        //        scoreLose5.SetActive(false);
        //        break;
        //    case 6:
        //        scoreLose6.SetActive(false);
        //        break;
            
        //}
    }
    public bool IsLastQuestion()
    {
        return _currentQuestionNumber >= 17; // karena kamu punya 17 soal
    }
}

