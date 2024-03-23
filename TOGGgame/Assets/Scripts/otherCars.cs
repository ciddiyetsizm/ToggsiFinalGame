using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherCars : MonoBehaviour
{
    public float sabitHiz = 5.0f; // Sabit hýz deðeri

    void Update()
    {
        HareketEt();
    }

    void HareketEt()
    {
        // Sabit hýzda hareket et
        transform.Translate(Vector3.forward * sabitHiz * Time.deltaTime);
    }
}
