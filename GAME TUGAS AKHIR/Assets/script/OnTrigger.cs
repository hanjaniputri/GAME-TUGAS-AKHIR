using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTurnTrigger : MonoBehaviour
{
    private bool hasTurned = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Turnpoint") && !hasTurned)
        {
            hasTurned = true;
            transform.rotation = Quaternion.Euler(0, 0, -90); // Contoh belok kanan
        }
    }
}