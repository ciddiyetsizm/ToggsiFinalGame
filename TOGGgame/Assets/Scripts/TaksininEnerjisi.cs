using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaksininEnerjisi : MonoBehaviour
{
    public float maxEnerji = 100f;
    public float enerjiAzalmaHizi = 1f;
    public float enerjiArtisMiktari = 10f;
    public float enerjiArtisMiktari2 = 20f;
    public Slider enerjiSlider;
    public GameObject kaybetmePaneli;

    private float currentEnerji;

    public AudioSource elektrikSesi;

    void Start()
    {
        currentEnerji = 100f;
        UpdateEnerjiUI();
    }

    void Update()
    {
        // Enerji seviyesini azalt
        currentEnerji -= enerjiAzalmaHizi * Time.deltaTime;
        UpdateEnerjiUI();

        // Eðer enerji seviyesi belirli bir eþik altýna düþtüyse, oyunu kaybet
        if (currentEnerji <= 0)
        {
            OyunuKaybet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Eðer temas edilen nesne "elektrik" etiketine sahipse, enerjiyi artýr
        if (other.CompareTag("elektrik"))
        {
            // Elektrik sesini çal
            if (elektrikSesi != null)
            {
                elektrikSesi.Play();
            }
            currentEnerji += enerjiArtisMiktari;
            // Maksimum enerjiyi aþma kontrolü
            currentEnerji = Mathf.Min(currentEnerji, maxEnerji);
            UpdateEnerjiUI();
            // Temas edilen nesneyi yok et 
            Destroy(other.gameObject);
        }
        // Eðer temas edilen nesne "elektrik" etiketine sahipse, enerjiyi artýr
        if (other.CompareTag("elektrik2"))
        {
            // Elektrik sesini çal
            if (elektrikSesi != null)
            {
                elektrikSesi.Play();
            }
            currentEnerji += enerjiArtisMiktari2;
            // Maksimum enerjiyi aþma kontrolü
            currentEnerji = Mathf.Min(currentEnerji, maxEnerji);
            UpdateEnerjiUI();
            // Temas edilen nesneyi yok et 
            Destroy(other.gameObject);
        }
    }

    void UpdateEnerjiUI()
    {
        // Enerji çubuðunun deðerini güncelle
        enerjiSlider.value = currentEnerji / maxEnerji;
    }

    void OyunuKaybet()
    {
        // Oyunu durdur
        Time.timeScale = 0f;

        // Kaybetme panelini göster
        kaybetmePaneli.SetActive(true);
    }
}
