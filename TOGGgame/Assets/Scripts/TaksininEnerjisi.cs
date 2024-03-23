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

        // E�er enerji seviyesi belirli bir e�ik alt�na d��t�yse, oyunu kaybet
        if (currentEnerji <= 0)
        {
            OyunuKaybet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // E�er temas edilen nesne "elektrik" etiketine sahipse, enerjiyi art�r
        if (other.CompareTag("elektrik"))
        {
            // Elektrik sesini �al
            if (elektrikSesi != null)
            {
                elektrikSesi.Play();
            }
            currentEnerji += enerjiArtisMiktari;
            // Maksimum enerjiyi a�ma kontrol�
            currentEnerji = Mathf.Min(currentEnerji, maxEnerji);
            UpdateEnerjiUI();
            // Temas edilen nesneyi yok et 
            Destroy(other.gameObject);
        }
        // E�er temas edilen nesne "elektrik" etiketine sahipse, enerjiyi art�r
        if (other.CompareTag("elektrik2"))
        {
            // Elektrik sesini �al
            if (elektrikSesi != null)
            {
                elektrikSesi.Play();
            }
            currentEnerji += enerjiArtisMiktari2;
            // Maksimum enerjiyi a�ma kontrol�
            currentEnerji = Mathf.Min(currentEnerji, maxEnerji);
            UpdateEnerjiUI();
            // Temas edilen nesneyi yok et 
            Destroy(other.gameObject);
        }
    }

    void UpdateEnerjiUI()
    {
        // Enerji �ubu�unun de�erini g�ncelle
        enerjiSlider.value = currentEnerji / maxEnerji;
    }

    void OyunuKaybet()
    {
        // Oyunu durdur
        Time.timeScale = 0f;

        // Kaybetme panelini g�ster
        kaybetmePaneli.SetActive(true);
    }
}
