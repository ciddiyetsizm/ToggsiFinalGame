using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSurus : MonoBehaviour
{
    public float maxHiz = 10.0f;
    public float hizlanmaMiktari = 2.0f;
    public float frenlemeMiktari = 5.0f;
    public float donusHizi = 100.0f;

    private float hiz;
    private float horizontalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        HareketEt();
        //Don();
    }

    void HareketEt()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (verticalInput > 0) // W tuþuna basýlýrsa
        {
            hiz = Mathf.Lerp(hiz, maxHiz, hizlanmaMiktari * Time.fixedDeltaTime);
        }
        else if (verticalInput < 0) // S tuþuna basýlýrsa
        {
            hiz = Mathf.Lerp(hiz, 0, frenlemeMiktari * Time.fixedDeltaTime);
        }

        transform.Translate(Vector3.forward * hiz * Time.fixedDeltaTime);
    }

    void Don()
    {
        float donusMiktari = horizontalInput * donusHizi;
        transform.Translate(Vector3.right * donusMiktari * Time.fixedDeltaTime);
    }
}
