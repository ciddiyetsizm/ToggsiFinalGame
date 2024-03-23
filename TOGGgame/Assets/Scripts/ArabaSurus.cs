using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArabaSurus : MonoBehaviour
{
    public float maxHiz = 10.0f;
    public float hizlanmaMiktari = 2.0f;
    public float frenlemeMiktari = 5.0f;
    public float kayisHizi = 100.0f;
    public GameObject kaybetmePaneli; // Kaybetme paneli objesi
    public GameObject yolcu;
    public GameObject kazanmaPaneli;
    public GameObject yolcuPaneli;
    public GameObject yolcuText;
    public GameObject duraklatmaMenusu;

    private Vector3 baslangicKonumu; // Baþlangýç konumunu saklamak için deðiþken
    public float maxSagHareket = 3f; // Maksimum sað hareket sýnýrý
    public float maxSolHareket = -3f; // Maksimum sol hareket sýnýrý


    private float hiz;
    private float horizontalInput;

    private bool oyunDuraklatildi = false;
    private bool yolcuAlindiMi = false;



    void Start()
    {
        Cursor.visible = false;
        // Baþlangýç konumunu kaydet
        baslangicKonumu = transform.position;

    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Oyun duraklatýldýysa devam ettir
            if (oyunDuraklatildi)
            {
                Time.timeScale = 1f; // Oyun zamanýný normal hýzda çalýþtýr
                oyunDuraklatildi = false;
            }
            else // Oyun devam ediyorsa duraklat
            {
                Time.timeScale = 0f; // Oyun zamanýný durdur
                oyunDuraklatildi = true;
            }

            // Duraklatma menüsünü etkinleþtir veya devre dýþý býrak
            duraklatmaMenusu.SetActive(oyunDuraklatildi);
            if (duraklatmaMenusu.activeInHierarchy)
                Cursor.visible = true;
            else
                Cursor.visible = false;
        }
        
        
    }

    void FixedUpdate()
    {
        HareketEt();
        Kay();
        // Karakterin mevcut konumunu al
        Vector3 karakterKonumu = transform.position;

        // Yeni Z konumunu hesapla
        float yeniZKonum = karakterKonumu.z + Input.GetAxis("Horizontal");

        // Z ekseni üzerindeki hareketi sýnýrla
        yeniZKonum = Mathf.Clamp(yeniZKonum, baslangicKonumu.z + maxSolHareket, baslangicKonumu.z + maxSagHareket);

        // Yeni konumu uygula
        transform.position = new Vector3(karakterKonumu.x, karakterKonumu.y, yeniZKonum);
    }

    void HareketEt()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0) // W tuþuna basýlýrsa
        {
            hiz = Mathf.Lerp(hiz, maxHiz, hizlanmaMiktari * Time.fixedDeltaTime);
        }
        else if (verticalInput < 0) // S tuþuna basýlýrsa
        {
            hiz = Mathf.Lerp(hiz, 0, frenlemeMiktari * Time.fixedDeltaTime);
        }

        transform.Translate(Vector3.forward * hiz * Time.fixedDeltaTime);


    }

    void Kay()
    {
        float kayisMiktari = horizontalInput * kayisHizi;
        transform.Translate(Vector3.right * kayisMiktari * Time.fixedDeltaTime);

        
    }
    

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("arac")) // "Arac" tag'ine sahip bir nesneyle çarpýþtýysa
        {
            // Çarpma sesini çal
            GetComponent<AudioSource>().Play();
            OyunuDurdurVeKaybetPaneliniGoster();
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("durak")) // "Durak" tag'ine sahip bir nesneyle temas ettiyse
        {
            YolcuObjesiniDeaktiveEt();
            yolcuAlindiMi = true;
        }
        if (other.CompareTag("sonDurak")) // "Durak" tag'ine sahip bir nesneyle temas ettiyse
        {
            if (yolcuAlindiMi == true)
            {
                KazanmaPaneli();
            }
            else
            {
                OyunuDurdurVeKaybetPaneliniGoster();
            }
            
        }
        
    }
    void KazanmaPaneli()
    {
        Cursor.visible = true;
        // Oyunu durdur
        Time.timeScale = 0f;

        // Kaybetme panelini göster
        kazanmaPaneli.SetActive(true);

        // Kazanma panelindeki sesi çal
        AudioSource kazanmaSesiKaynagi = kazanmaPaneli.GetComponent<AudioSource>();
        if (kazanmaSesiKaynagi != null)
        {
            kazanmaSesiKaynagi.Play();
        }
    }

    void YolcuObjesiniDeaktiveEt()
    {
        Cursor.visible = true;
        // Oyunu durdur
        Time.timeScale = 0f;
        // Yolcu objesini deaktive et
        yolcu.SetActive(false);
        yolcuText.SetActive(false);
        yolcuPaneli.SetActive(true);

    }

    void OyunuDurdurVeKaybetPaneliniGoster()
    {
        Cursor.visible = true;
        // Oyunu durdur
        Time.timeScale = 0f;

        // Kaybetme panelini göster
        kaybetmePaneli.SetActive(true);
    }
}
