using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBaslat2 : MonoBehaviour
{
    public GameObject bolum1Paneli;
    public GameObject bolum2Paneli;

    private void Start()
    {
        // Oyun ba�lang�c�nda sadece bolum1 panelini aktifle�tir
        bolum1Paneli.SetActive(true);
        bolum2Paneli.SetActive(false);
    }

    public void Basla2ButonunaBasildi()
    {
        // E�er sadece bolum1 paneli aktifse
        if (bolum1Paneli.activeSelf)
        {
            Time.timeScale = 1f;
            // Oyun sahnesini y�kle
            SceneManager.LoadScene("ToggSahne1");
        }
        // E�er sadece bolum2 paneli aktifse
        else if (bolum2Paneli.activeSelf)
        {
            Time.timeScale = 1f;
            // Oyun sahnesi 2'yi y�kle
            SceneManager.LoadScene("ToggSahne2");
        }
    }
}
