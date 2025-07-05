using System.Collections;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 5f;
    private bool isMoving = false;
    private bool isWaitingNearLampu = false;

    void Update()
    {
        // Contoh input: tekan tombol Spasi untuk mulai bergerak
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartMoving();
        }

        if (isMoving && !isWaitingNearLampu)
        {
            MoveCar();
        }
    }

    void MoveCar()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    // Deteksi saat mobil memasuki area trigger tiang lampu
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TiangLampu") && !isWaitingNearLampu)
        {
            StartCoroutine(StopFor5Seconds());
        }
    }

    IEnumerator StopFor5Seconds()
    {
        isWaitingNearLampu = true;
        isMoving = false;

        yield return new WaitForSeconds(5f);

        isWaitingNearLampu = false;
        // Tidak langsung set isMoving ke true, user harus tekan tombol lagi
    }

    public void StartMoving()
    {
        // Hanya izinkan mobil bergerak jika tidak sedang menunggu di lampu
        if (!isWaitingNearLampu)
        {
            isMoving = true;
        }
    }

    public void StopMoving()
    {
        isMoving = false;
    }
}