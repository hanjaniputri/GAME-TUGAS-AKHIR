using UnityEngine;
using UnityEngine.UI; // Untuk UI

public class CarMovement : MonoBehaviour
{
    [SerializeField] private LampuQuestionManager _lampuQuestionManager;

    public float speed = 5f;         // Kecepatan mobil
    private bool isMoving = false;   // Status apakah mobil bergerak
    private bool isStoppedAtLamp = false; // Status apakah mobil berhenti di tiang lampu

    public Button moveButton; // Referensi tombol UI, assign di Inspector

    void Start()
    {
        // Pengecekan tombol
        if (moveButton == null)
        {
            Debug.LogError("Move Button belum di-assign di Inspector!");
        }
    }

    void Update()
    {
        // Bergerak hanya jika isMoving true dan tidak berhenti di tiang
        if (isMoving && !isStoppedAtLamp)
        {
            MoveCar();
        }
    }

    void MoveCar()
    {
        // Bergerak ke kanan (sesuaikan arah jika perlu)
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    // Deteksi saat mobil masuk ke area trigger tiang lampu
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TiangLampu") && !isStoppedAtLamp)
        {
            _lampuQuestionManager.InitializeQuestion();

            isMoving = false;           // Hentikan pergerakan
            isStoppedAtLamp = true;     // Tandai bahwa mobil berhenti di tiang
            //Invoke("ResumeMovementOption", 5f); // Jadwalkan untuk membuka opsi pergerakan setelah 5 detik
        }
    }

    // Fungsi untuk mengatur ulang status setelah 5 detik
    public void ResumeMovementOption()
    {
        isStoppedAtLamp = false; // Izinkan user menekan tombol lagi
    }

    // Fungsi yang dipanggil saat tombol ditekan (Pointer Down)
    public void StartMoving()
    {
        if (!isStoppedAtLamp)
        {
            isMoving = true;
        }
    }

    // Fungsi yang dipanggil saat tombol dilepas (Pointer Up)
    public void StopMoving()
    {
        if (!isStoppedAtLamp) // Hanya stop jika tidak sedang berhenti di lampu
        {
            isMoving = false;
        }
    }
}