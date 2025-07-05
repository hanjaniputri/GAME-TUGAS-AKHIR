using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    public void LoadBelajarScene()
    {
        SceneManager.LoadScene("belajar");
    }

    public void LoadBermainScene()
    {
        SceneManager.LoadScene("bermain");
    }
    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void KembaliKeGameLevel()
    {
        SceneManager.LoadScene("game level");
    }
    public void LoadRambuPeringatan()
    {
        SceneManager.LoadScene("rambu_peringatan");
    }

    public void LoadRambuLarangan()
    {
        SceneManager.LoadScene("rambu_larangan");
    }

    public void LoadRambuPerintah()
    {
        SceneManager.LoadScene("rambu_perintah");
    }

    public void LoadRambuPetunjuk()
    {
        SceneManager.LoadScene("rambu_petunjuk");
    }
    public void KembaliKeBelajar()
    {
        SceneManager.LoadScene("belajar");
    }
    public void LoadGameSimulasilampu()
    {
        SceneManager.LoadScene("game_simulasi_lampu");
    }
    public void LoadGameSimulasiRambu()
    {
        SceneManager.LoadScene("GameRambu");
    }
    public void LoadGameSimulasi()
    {
        SceneManager.LoadScene("game_simulasi");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
