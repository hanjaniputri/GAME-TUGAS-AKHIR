using UnityEngine;
using UnityEngine.UI;
using Microsoft.CognitiveServices.Speech;
using TMPro;
using Microsoft.CognitiveServices.Speech.Audio;
using System.Collections;
using UnityEngine.Android;



#if PLATFORM_ANDROID
#endif
#if PLATFORM_IOS
using UnityEngine.iOS;
using System.Collections;
#endif

public class RambuSpeechRecognition : MonoBehaviour
{
    // Hook up the two properties below with a Text and Button object in your UI.
    [SerializeField] private RambuQuestionManager _rambuQuestionManager;
    public string _message;
    public string _answer;

    public Button startRecoButton;

    private object threadLocker = new object();
    private bool waitingForReco;
    private string message;

    private bool micPermissionGranted = false;
    private bool _isShowingCorrectResult = false;
    private bool _isShowingIncorrectResult = false;

#if PLATFORM_ANDROID || PLATFORM_IOS
    // Required to manifest microphone permission, cf.
    // https://docs.unity3d.com/Manual/android-manifest.html
    private Microphone mic;
#endif

    public void SetCorrectAnswer(string answer)
    {
        Debug.LogWarning("Current Correct Answer: " + answer);
        _answer = answer;

        _isShowingCorrectResult = false;
        _isShowingIncorrectResult = false;
    }

    public async void ButtonClick()
    {
        // Creates an instance of a speech config with specified subscription key and service region.
        // Replace with your own subscription key and service region (e.g., "westus").
        var config = SpeechConfig.FromSubscription("1HUEN4TKRdU4jMI6qSCrPQ5fe03pJnWSerlAjHLpNBwAMqzIKtABJQQJ99BDACYeBjFXJ3w3AAAYACOGWhKt", "eastus");


        config.SpeechRecognitionLanguage = "id-ID";


        // Enable SDK logging (add these lines)
        config.SetProperty(PropertyId.Speech_LogFilename, Application.persistentDataPath + "/SpeechSDKLog.txt");
        Debug.Log(Application.persistentDataPath + "/SpeechSDKLog.txt");
        //config.SetProperty(PropertyId.SpeechServiceConnection_EnableLogging, "true");



        // Make sure to dispose the recognizer after use!
        using (var recognizer = new SpeechRecognizer(config))
        {
            lock (threadLocker)
            {
                waitingForReco = true;
            }

            recognizer.SessionStarted += (s, e) => {
                Debug.Log($"Session started: {e.SessionId}");
            };
            recognizer.SessionStopped += (s, e) => {
                Debug.Log($"Session stopped: {e.SessionId}");
            };
            recognizer.Canceled += (s, e) => {
                Debug.Log($"Canceled: {e.Reason}");
                if (e.Reason == CancellationReason.Error)
                {
                    Debug.LogError($"Error code: {e.ErrorCode}");
                    Debug.LogError($"Error details: {e.ErrorDetails}");
                }
            };

            // Starts speech recognition, and returns after a single utterance is recognized. The end of a
            // single utterance is determined by listening for silence at the end or until a maximum of 15
            // seconds of audio is processed.  The task returns the recognition text as result.
            // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
            // shot recognition like command or query.
            // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
            var result = await recognizer.RecognizeOnceAsync().ConfigureAwait(false);

            // Checks result.
            string newMessage = string.Empty;
            if (result.Reason == ResultReason.RecognizedSpeech)
            {
                newMessage = result.Text;

                if (string.Equals(newMessage, _answer))
                {
                    Debug.Log("Jawaban benar");
                    Debug.Log(newMessage);

                    _isShowingCorrectResult = true;
                }
                else
                {
                    Debug.Log("Jawaban salah");
                    Debug.Log(newMessage);

                    _isShowingIncorrectResult = true;

                }
            }
            else if (result.Reason == ResultReason.NoMatch)
            {
                newMessage = "NOMATCH: Speech could not be recognized.";
            }
            else if (result.Reason == ResultReason.Canceled)
            {
                var cancellation = CancellationDetails.FromResult(result);
                newMessage = $"CANCELED: Reason={cancellation.Reason} ErrorDetails={cancellation.ErrorDetails}";
            }

            lock (threadLocker)
            {
                message = newMessage;
                waitingForReco = false;
            }
        }
    }

    void Start()
    {
        if (_message == null)
        {
            UnityEngine.Debug.LogError("outputText property is null! Assign a UI Text element to it.");
        }
        else if (startRecoButton == null)
        {
            message = "startRecoButton property is null! Assign a UI Button to it.";
            UnityEngine.Debug.LogError(message);
        }
        else
        {

            // Continue with normal initialization, Text and Button objects are present.
#if PLATFORM_ANDROID
            StartCoroutine(CheckAndRequestMicrophonePermission());
            //// Request to use the microphone, cf.
            //// https://docs.unity3d.com/Manual/android-RequestingPermissions.html
            //message = "Waiting for mic permission";
            //if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            //{
            //    Permission.RequestUserPermission(Permission.Microphone);
            //}
#elif PLATFORM_IOS
            if (!Application.HasUserAuthorization(UserAuthorization.Microphone))
            {
                Application.RequestUserAuthorization(UserAuthorization.Microphone);
            }
#else
            micPermissionGranted = true;
            //message = "Click button to recognize speech";
#endif
            startRecoButton.onClick.AddListener(ButtonClick);
        }
    }

    private IEnumerator CheckAndRequestMicrophonePermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
            // Wait for user response
            yield return new WaitForSeconds(1);
        }

        // Double check after request
        micPermissionGranted = Permission.HasUserAuthorizedPermission(Permission.Microphone);
        message = micPermissionGranted ? "Click button to recognize speech" : "Microphone permission required";
    }

    void Update()
    {
#if PLATFORM_ANDROID
        if (!micPermissionGranted && Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            micPermissionGranted = true;
            message = "Click button to recognize speech";
        }
#elif PLATFORM_IOS
        if (!micPermissionGranted && Application.HasUserAuthorization(UserAuthorization.Microphone))
        {
            micPermissionGranted = true;
            message = "Click button to recognize speech";
        }
#endif

        lock (threadLocker)
        {
            if (startRecoButton != null)
            {
                startRecoButton.interactable = !waitingForReco && micPermissionGranted;
            }
            if (_message != null)
            {
                _message = message;
            }
        }

        if (_isShowingCorrectResult)
        {
            _isShowingCorrectResult = false;
            RambuManager.GetInstance().OnCorrectAnswer();
            _rambuQuestionManager.SetResult(true);
        }

        if (_isShowingIncorrectResult)
        {
            _isShowingIncorrectResult = false;
            _rambuQuestionManager.SetResult(false);
        }
    }
}
// </code>