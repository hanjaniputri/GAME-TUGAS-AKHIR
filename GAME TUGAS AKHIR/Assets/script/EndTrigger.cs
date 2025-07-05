using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public string sceneNameToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pastikan mobil diberi tag "Player"
        {
            Debug.Log("Sampai di ujung, pindah scene ke " + sceneNameToLoad);
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
