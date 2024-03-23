using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControl : MonoBehaviour
{
    public float hiz = 10.0f; // Ara� h�z�
    public float donusHizi = 100.0f; // Ara� d�n�� h�z�

    void Update()
    {
        HareketKontrolu();
    }

    void HareketKontrolu()
    {
        float dikeyHareket = Input.GetAxis("Vertical"); // W/S veya yukar�/a�a�� ok tu�lar�yla sa�lanan dikey giri�
        float yatayHareket = Input.GetAxis("Horizontal"); // A/D veya sol/sa� ok tu�lar�yla sa�lanan yatay giri�

        // Hareketi sa�lama
        Vector3 hareket = new Vector3(yatayHareket, 0, dikeyHareket) * hiz * Time.deltaTime;
        transform.Translate(hareket);

        // D�n��� sa�lama
        float donus = yatayHareket * donusHizi * Time.deltaTime;
        transform.Rotate(Vector3.up * donus);
    }
}
