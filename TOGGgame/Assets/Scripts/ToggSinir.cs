using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggSinir : MonoBehaviour
{
    public float maxSagHareket = 3f; // Maksimum sa� hareket s�n�r�
    public float maxSolHareket = -3f; // Maksimum sol hareket s�n�r�

    void Update()
    {
        // Karakterin mevcut konumunu al
        Vector3 karakterKonumu = transform.position;

        // X ekseni �zerindeki hareketi s�n�rla
        karakterKonumu.x = Mathf.Clamp(karakterKonumu.x, maxSolHareket, maxSagHareket);

        // Yeni konumu uygula
        transform.position = karakterKonumu;
    }
}
