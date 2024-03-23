using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carControl : MonoBehaviour
{
    public float hiz = 10.0f; // Araç hýzý
    public float donusHizi = 100.0f; // Araç dönüþ hýzý

    void Update()
    {
        HareketKontrolu();
    }

    void HareketKontrolu()
    {
        float dikeyHareket = Input.GetAxis("Vertical"); // W/S veya yukarý/aþaðý ok tuþlarýyla saðlanan dikey giriþ
        float yatayHareket = Input.GetAxis("Horizontal"); // A/D veya sol/sað ok tuþlarýyla saðlanan yatay giriþ

        // Hareketi saðlama
        Vector3 hareket = new Vector3(yatayHareket, 0, dikeyHareket) * hiz * Time.deltaTime;
        transform.Translate(hareket);

        // Dönüþü saðlama
        float donus = yatayHareket * donusHizi * Time.deltaTime;
        transform.Rotate(Vector3.up * donus);
    }
}
