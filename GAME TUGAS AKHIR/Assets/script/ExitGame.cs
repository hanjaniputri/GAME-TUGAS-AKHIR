using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // Ini akan keluar dari game saat build
        Application.Quit();

        // Tambahan untuk editor (hanya agar terlihat saat testing di editor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
