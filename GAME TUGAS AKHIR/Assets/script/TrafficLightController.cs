using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject lampuMerah_ON;
    public GameObject lampuKuning_ON;
    public GameObject lampuHijau_ON;

    public float waktuMerah = 3f;
    public float waktuKuning = 1.5f;
    public float waktuHijau = 3f;

    public string statusLampu = "hijau"; // Bisa dibaca oleh mobil

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SiklusLampu());
    }

    IEnumerator SiklusLampu()
    {
        while (true)
        {
            AktifkanLampu(lampuMerah_ON, Color.red);  // Mengubah lampu merah menjadi lebih terang
            statusLampu = "merah";
            yield return new WaitForSeconds(waktuMerah);

            AktifkanLampu(lampuKuning_ON, Color.yellow);  // Mengubah lampu kuning menjadi lebih terang
            statusLampu = "kuning";
            yield return new WaitForSeconds(waktuKuning);

            AktifkanLampu(lampuHijau_ON, Color.green);  // Mengubah lampu hijau menjadi lebih terang
            statusLampu = "hijau";
            yield return new WaitForSeconds(waktuHijau);
        }
    }

    void AktifkanLampu(GameObject lampu, Color color)
    {
        // Nonaktifkan semua lampu terlebih dahulu
        lampuMerah_ON.SetActive(false);
        lampuKuning_ON.SetActive(false);
        lampuHijau_ON.SetActive(false);

        // Aktifkan lampu yang sesuai
        lampu.SetActive(true);

        // Ganti warna cahaya lampu dengan warna yang lebih terang
        // Menambahkan nilai alpha untuk memberikan efek lebih terang
        lampu.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1f); // Alpha = 1f untuk lampu terang
    }
}


