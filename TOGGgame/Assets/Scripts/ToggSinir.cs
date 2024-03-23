using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggSinir : MonoBehaviour
{
    public float maxSagHareket = 3f; // Maksimum sað hareket sýnýrý
    public float maxSolHareket = -3f; // Maksimum sol hareket sýnýrý

    void Update()
    {
        // Karakterin mevcut konumunu al
        Vector3 karakterKonumu = transform.position;

        // X ekseni üzerindeki hareketi sýnýrla
        karakterKonumu.x = Mathf.Clamp(karakterKonumu.x, maxSolHareket, maxSagHareket);

        // Yeni konumu uygula
        transform.position = karakterKonumu;
    }
}
