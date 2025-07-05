using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobil : MonoBehaviour
{
    [SerializeField] private LevelSelectionManager _levelSelectionManager;
    public float speed = 3f;
    private Vector2 moveDirection = Vector2.up; // Arah gerak awal
    private bool isStopping = false;
    private bool isStarted = false; // <- Tambahan: belum mulai sampai tombol ditekan

    public string nextSceneKiri = "SceneKiri";
    public string nextSceneKanan = "SceneKanan";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted && !isStopping)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TurnpointKiri"))
        {
            _levelSelectionManager.InitializeBelokKiri();
            StartCoroutine(BerhentiDiBelokan());
        }

        if (other.CompareTag("TurnpointKanan"))
        {
            _levelSelectionManager.InitializeBelokKanan();
            StartCoroutine(BerhentiDiBelokan());
        }
    }

    IEnumerator BerhentiDiBelokan()
    {
        isStopping = true;
        yield return new WaitForSeconds(10f);
        isStopping = false;
        _levelSelectionManager.TurnOffRecordContainer();
    }

    //  Fungsi ini dipanggil dari tombol
    public void MulaiGame()
    {
        isStarted = true;
    }
    public void BelokKanan()
    {
        transform.rotation = Quaternion.Euler(0, 0, -90); // putar mobil ke kanan
        moveDirection = Vector2.right; // arah gerak ke kanan
        isStopping = false; // lanjut jalan
        _levelSelectionManager.TurnOffRecordContainer(); // langsung hilangkan UI
    }

    public void BelokKiri()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90); // putar mobil ke kiri
        moveDirection = Vector2.left; // arah gerak ke kiri
        isStopping = false; // lanjut jalan
        _levelSelectionManager.TurnOffRecordContainer(); // langsung hilangkan UI
    }
}
