using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform[] garisPutihArray; // Isi 10 garis putih di sini
    public float speed = 2f;
    public float resetY = -6f;
    public float startY = 6f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform garis in garisPutihArray)
        {
            // Gerakkan garis ke bawah
            garis.Translate(Vector3.down * speed * Time.deltaTime);

            // Jika sudah melewati batas bawah, kembalikan ke atas
            if (garis.position.y < resetY)
            {
                Vector3 pos = garis.position;
                pos.y = startY;
                garis.position = pos;
            }
        }
    }
}
