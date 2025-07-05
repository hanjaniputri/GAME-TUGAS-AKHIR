using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public List<Sprite> daftarRambu;
    public Image imageRambu;
    private int indexSekarang = 0;
    // Start is called before the first frame update
    public void NextRambu()
    {
        indexSekarang++;
        if (indexSekarang >= daftarRambu.Count)
            indexSekarang = 0;

        imageRambu.sprite = daftarRambu[indexSekarang];
    }
    public void PrevRambu()
    {
        indexSekarang--;
        if (indexSekarang < 0)
            indexSekarang = daftarRambu.Count - 1;

        imageRambu.sprite = daftarRambu[indexSekarang];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class GantiDuaRambu : MonoBehaviour
{
    public List<Sprite> daftarRambuKiri;
    public List<Sprite> daftarRambuKanan;

    public Image imageRambuKiri;
    public Image imageRambuKanan;

    private int indexKiri = 0;
    private int indexKanan = 0;

    void Start()
    {
        TampilkanRambu();
    }

    public void NextSemuaRambu()
    {
        indexKiri++;
        indexKanan++;

        if (indexKiri >= daftarRambuKiri.Count)
            indexKiri = 0;

        if (indexKanan >= daftarRambuKanan.Count)
            indexKanan = 0;

        TampilkanRambu();
    }

    void TampilkanRambu()
    {
        imageRambuKiri.sprite = daftarRambuKiri[indexKiri];
        imageRambuKanan.sprite = daftarRambuKanan[indexKanan];
    }
}
