using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunBaslat : MonoBehaviour
{
    public GameObject bolum1Paneli;
    public GameObject bolum2Paneli;

    private void Start()
    {
        // Oyun baþlangýcýnda sadece bolum1 panelini aktifleþtir
        bolum1Paneli.SetActive(true);
        bolum2Paneli.SetActive(false);
    }

    public void BaslaButonunaBasildi()
    {
        // Eðer sadece bolum1 paneli aktifse
        if (bolum1Paneli.activeSelf)
        {
            // Oyun sahnesini yükle
            SceneManager.LoadScene("ToggSahne1");
        }
        
    }
}
