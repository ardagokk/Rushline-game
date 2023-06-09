using UnityEngine;

public class BoyuArtt�r : MonoBehaviour
{
    private Vector3 originalScale; // Orijinal �l�ek de�eri
    private bool isScaling; // Boyutun b�y�t�l�p b�y�t�lmedi�ini takip etmek i�in kullan�l�r

    private void Start()
    {
        originalScale = transform.localScale; // Ba�lang��ta orijinal �l�e�i kaydediyoruz
        isScaling = false; // Ba�lang��ta boyut b�y�t�lmedi�i i�in false olarak ayarl�yoruz
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectibleUp2") && !isScaling) // E�er �arp��t���n�z nesne "CollectibleUp2" etiketine sahipse ve boyut zaten b�y�t�lmemi�se
        {
            StartCoroutine(ArtirVeDon()); // Boyut b�y�tme ve geri d�nme i�lemini ba�lat�r
        }
        Destroy(other.gameObject);
    }

    private System.Collections.IEnumerator ArtirVeDon()
    {
        isScaling = true; // Boyut b�y�tme i�lemi ba�lad��� i�in true olarak ayarl�yoruz

        // Boyutu iki kat�na ��kart�yoruz
        Vector3 newScale = new Vector3(originalScale.x * 2f, originalScale.y * 2f, originalScale.z * 2f);
        transform.localScale = newScale;

        yield return new WaitForSeconds(10f); // 10 saniye bekliyoruz

        // Orijinal boyuta geri d�n�yoruz
        transform.localScale = originalScale;

        isScaling = false; // Boyut d�n��� tamamland��� i�in false olarak ayarl�yoruz
    }
}