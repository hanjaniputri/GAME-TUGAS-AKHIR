using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(string gamelevel)
    {
        SceneManager.LoadScene(gamelevel);
    }
    public void keluarbtn()
    {
        Application.Quit();
    }
  }
