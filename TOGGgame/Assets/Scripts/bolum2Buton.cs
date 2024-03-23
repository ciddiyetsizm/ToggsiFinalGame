using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bolum2Buton : MonoBehaviour
{
    public GameObject yolcuPaneli;
    public GameObject kalanSurePaneli;
    public Text kalanSureText;
    public GameObject kaybetmePaneli;
    

    
    private float kalanSure2 = 45f;
    private bool oyunDevamEdiyor2 = false;

    void Start()
    {
        BaslangicHazirliklari2();
    }

    void BaslangicHazirliklari2()
    {
        yolcuPaneli.SetActive(false);
        kalanSurePaneli.SetActive(false);
        kaybetmePaneli.SetActive(false);
        Time.timeScale = 1f;
    }
    public void DevamEtButon2()
    {
        // Oyunu devamet
        Time.timeScale = 1f;
        yolcuPaneli.SetActive(false);
        kalanSurePaneli.SetActive(true);
        oyunDevamEdiyor2 = true;
    }
    private void Update()
    {
        if (oyunDevamEdiyor2)
        {
            kalanSure2 -= Time.deltaTime;
            kalanSureText.text = Mathf.RoundToInt(kalanSure2).ToString();

            if (kalanSure2 <= 0)
            {
                // Oyunu durdur
                Time.timeScale = 0f;

                // Kaybetme panelini göster
                kaybetmePaneli.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene().name == "ToggSahne2")
        {
            if (yolcuPaneli.activeSelf && Input.GetKeyDown(KeyCode.Return))
            {
                DevamEtButon2();
            }
        }

    }
    
}
