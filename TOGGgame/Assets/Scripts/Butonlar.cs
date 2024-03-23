using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butonlar : MonoBehaviour
{
    public GameObject[] paneller;
    private int aktifPanelIndex = 0;
    public GameObject levelPaneli;
    public GameObject SecenekPaneli;
    public GameObject AnaPanel;
    


    public void SagButonaBasildi()
    {
        GecisSag();
    }

    public void SolButonaBasildi()
    {
        GecisSol();
    }

    void GecisSag()
    {
        if (aktifPanelIndex < paneller.Length - 1)
        {
            paneller[aktifPanelIndex].SetActive(false);
            aktifPanelIndex++;
            paneller[aktifPanelIndex].SetActive(true);
        }
    }

    void GecisSol()
    {
        if (aktifPanelIndex > 0)
        {
            paneller[aktifPanelIndex].SetActive(false);
            aktifPanelIndex--;
            paneller[aktifPanelIndex].SetActive(true);
        }
    }
    public void GeriDonButonunaBasildi()
    {
        // "GeriDon" butonuna basýldýðýnda paneli devre dýþý býrak
        levelPaneli.SetActive(false);
    }
    public void OynaButonunaBasildi()
    {
        Time.timeScale = 1f;
        levelPaneli.SetActive(true);
    }
    public void CikisButonunaBasildi()
    {
        // "Çýkýþ" butonuna basýldýðýnda uygulamadan çýk
        Application.Quit();
    }
    public void SecenekButonunaBasildi()
    {
        
        SecenekPaneli.SetActive(true);
        AnaPanel.SetActive(false);
    }
    public void GeriSecenekButonu()
    {
        
        SecenekPaneli.SetActive(false);
        AnaPanel.SetActive(true);
    }
}
