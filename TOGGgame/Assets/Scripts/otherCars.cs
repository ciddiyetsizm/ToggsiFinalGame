using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherCars : MonoBehaviour
{
    public float sabitHiz = 5.0f; // Sabit h�z de�eri

    void Update()
    {
        HareketEt();
    }

    void HareketEt()
    {
        // Sabit h�zda hareket et
        transform.Translate(Vector3.forward * sabitHiz * Time.deltaTime);
    }
}
