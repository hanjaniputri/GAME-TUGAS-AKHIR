using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicDetector : MonoBehaviour
{
    void Start()
    {
        // Check if any microphones are available
        if (Microphone.devices.Length == 0)
        {
            Debug.Log("No microphone detected!");
        }
        else
        {
            Debug.Log("Microphone detected: " + Microphone.devices[0]);

            // Optional: List all available microphones
            foreach (string device in Microphone.devices)
            {
                Debug.Log("Available device: " + device);
            }
        }
    }
}
