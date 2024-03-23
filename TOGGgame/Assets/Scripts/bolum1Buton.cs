using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bolum1Buton : MonoBehaviour
{
    public GameObject yolcuPaneli;
    public GameObject kalanSurePaneli;
    public Text kalanSureText;
    public GameObject kaybetmePaneli;
     

    private float kalanSure = 60f;
    
    private bool oyunDevamEdiyor = false;

    void Start()
    {
        BaslangicHazirliklari();
    }

    void BaslangicHazirliklari()
    {
        yolcuPaneli.SetActive(false);
        kalanSurePaneli.SetActive(false);
        kaybetmePaneli.SetActive(false);
        Time.timeScale = 1f;
    }
    public void DevamEtButon()
    {
        // Oyunu devamet
        Time.timeScale = 1f;
        yolcuPaneli.SetActive(false);
        kalanSurePaneli.SetActive(true);
        oyunDevamEdiyor = true;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (oyunDevamEdiyor)
        {
            kalanSure -= Time.deltaTime;
            kalanSureText.text = Mathf.RoundToInt(kalanSure).ToString();

            if (kalanSure <= 0)
            {
                // Oyunu durdur
                Time.timeScale = 0f;

                // Kaybetme panelini göster
                kaybetmePaneli.SetActive(true);
            }
        }
        
        if (SceneManager.GetActiveScene().name == "ToggSahne1")
        {
            if (yolcuPaneli.activeSelf && Input.GetKeyDown(KeyCode.Return))
            {
                DevamEtButon();
            }
        }
        // Sadece ToggSahne1 sahnesinde olduðumuzda çalýþtýr
        if (SceneManager.GetActiveScene().name == "ToggSahne1")
        {
            // Kaybetme paneli aktif olduðunda ve Enter tuþuna basýldýðýnda TekrarDene1 fonksiyonunu çaðýr
            if (kaybetmePaneli.activeSelf && Input.GetKeyDown(KeyCode.Return))
            {
                TekrarDene1();
            }
        }
        if (SceneManager.GetActiveScene().name == "ToggSahne2")
        {
            // Kaybetme paneli aktif olduðunda ve Enter tuþuna basýldýðýnda TekrarDene1 fonksiyonunu çaðýr
            if (kaybetmePaneli.activeSelf && Input.GetKeyDown(KeyCode.Return))
            {
                TekrarDene2();
            }
        }
    }
    public void anaMenu1()
    {
        Cursor.visible = true;
        // Ana menü 1 e dön
        SceneManager.LoadScene("UIsahne1");
    }
    public void anaMenu2()
    {
        Cursor.visible = true;
        // Ana menü 1 e dön
        SceneManager.LoadScene("UImenu2");
    }
    public void TekrarDene1()
    {
        Cursor.visible = true;
        BaslangicHazirliklari();
        // Ana menü 1 e dön
        SceneManager.LoadScene("ToggSahne1");
    }
    public void TekrarDene2()
    {
        Cursor.visible = true;
        BaslangicHazirliklari();
        // Ana menü 1 e dön
        SceneManager.LoadScene("ToggSahne2");
    }
    public void IleriButon2()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("UIsahne2");
    }


}
