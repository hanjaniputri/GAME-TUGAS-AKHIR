using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilingParallax : MonoBehaviour
{
    public Transform player;      // Referensi objek pemain (misalnya mobil atau kamera)
    public float parallaxSpeed;   // Kecepatan gerak latar belakang
    public float width;           // Lebar latar belakang (gambar atau objek)
    private float startPos;       // Posisi awal latar belakang
    // Start is called before the first frame update
    void Start()
    {
        // Menyimpan posisi awal latar belakang
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Hitung pergerakan berdasarkan posisi pemain
        float distanceMoved = player.position.x * parallaxSpeed;

        // Pindahkan latar belakang
        transform.position = new Vector3(startPos + distanceMoved, transform.position.y, transform.position.z);

        // Jika latar belakang telah mencapai batas, buat ulang posisi
        if (transform.position.x - player.position.x >= width)
        {
            startPos += width;
        }
    
    }
}
