using UnityEngine;

public class BoyuKucult : MonoBehaviour
{
    private Vector3 originalScale; // Orijinal �l�ek de�eri
    private bool isScaling; // Boyutun k���lt�l�p k���lt�lmedi�ini takip etmek i�in kullan�l�r

    private void Start()
    {
        originalScale = transform.localScale; // Ba�lang��ta orijinal �l�e�i kaydediyoruz
        isScaling = false; // Ba�lang��ta boyut k���lt�lmedi�i i�in false olarak ayarl�yoruz
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible") && !isScaling) // E�er �arp��t���n�z nesne "Collectible" etiketine sahipse ve boyut zaten k���lt�lmemi�se
        {
            StartCoroutine(KucultVeDon()); // Boyut k���ltme ve geri d�nme i�lemini ba�lat�r
        }
    }

    private System.Collections.IEnumerator KucultVeDon()
    {
        isScaling = true; // Boyut k���ltme i�lemi ba�lad��� i�in true olarak ayarl�yoruz

        // Boyutu yar�ya d���r�yoruz
        Vector3 newScale = new Vector3(originalScale.x / 2f, originalScale.y / 2f, originalScale.z / 2f);
        transform.localScale = newScale;

        yield return new WaitForSeconds(10f); // 10 saniye bekliyoruz

        // Orijinal boyuta geri d�n�yoruz
        transform.localScale = originalScale;

        isScaling = false; // Boyut d�n��� tamamland��� i�in false olarak ayarl�yoruz
    }
}
