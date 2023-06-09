using UnityEngine;

public class BoyuArttýr : MonoBehaviour
{
    private Vector3 originalScale; // Orijinal ölçek deðeri
    private bool isScaling; // Boyutun büyütülüp büyütülmediðini takip etmek için kullanýlýr

    private void Start()
    {
        originalScale = transform.localScale; // Baþlangýçta orijinal ölçeði kaydediyoruz
        isScaling = false; // Baþlangýçta boyut büyütülmediði için false olarak ayarlýyoruz
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectibleUp2") && !isScaling) // Eðer çarpýþtýðýnýz nesne "CollectibleUp2" etiketine sahipse ve boyut zaten büyütülmemiþse
        {
            StartCoroutine(ArtirVeDon()); // Boyut büyütme ve geri dönme iþlemini baþlatýr
        }
        Destroy(other.gameObject);
    }

    private System.Collections.IEnumerator ArtirVeDon()
    {
        isScaling = true; // Boyut büyütme iþlemi baþladýðý için true olarak ayarlýyoruz

        // Boyutu iki katýna çýkartýyoruz
        Vector3 newScale = new Vector3(originalScale.x * 2f, originalScale.y * 2f, originalScale.z * 2f);
        transform.localScale = newScale;

        yield return new WaitForSeconds(10f); // 10 saniye bekliyoruz

        // Orijinal boyuta geri dönüyoruz
        transform.localScale = originalScale;

        isScaling = false; // Boyut dönüþü tamamlandýðý için false olarak ayarlýyoruz
    }
}