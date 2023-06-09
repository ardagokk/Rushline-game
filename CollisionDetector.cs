using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] GameManager gameManager; // GameManager nesnesine eri�mek i�in referans

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager nesnesini bul
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �arp��man�n ger�ekle�ti�i nesnenin etiketini kontrol et
        {
            gameManager.EndGame(); // Oyunu bitir
        }
    }
}
