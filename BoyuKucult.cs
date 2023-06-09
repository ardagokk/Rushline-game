using UnityEngine;

public class BoyuKucult : MonoBehaviour
{
    private Vector3 originalScale; // Orijinal ölçek deðeri
    private bool isScaling; // Boyutun küçültülüp küçültülmediðini takip etmek için kullanýlýr

    private void Start()
    {
        originalScale = transform.localScale; // Baþlangýçta orijinal ölçeði kaydediyoruz
        isScaling = false; // Baþlangýçta boyut küçültülmediði için false olarak ayarlýyoruz
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible") && !isScaling) // Eðer çarpýþtýðýnýz nesne "Collectible" etiketine sahipse ve boyut zaten küçültülmemiþse
        {
            StartCoroutine(KucultVeDon()); // Boyut küçültme ve geri dönme iþlemini baþlatýr
        }
    }

    private System.Collections.IEnumerator KucultVeDon()
    {
        isScaling = true; // Boyut küçültme iþlemi baþladýðý için true olarak ayarlýyoruz

        // Boyutu yarýya düþürüyoruz
        Vector3 newScale = new Vector3(originalScale.x / 2f, originalScale.y / 2f, originalScale.z / 2f);
        transform.localScale = newScale;

        yield return new WaitForSeconds(10f); // 10 saniye bekliyoruz

        // Orijinal boyuta geri dönüyoruz
        transform.localScale = originalScale;

        isScaling = false; // Boyut dönüþü tamamlandýðý için false olarak ayarlýyoruz
    }
}
