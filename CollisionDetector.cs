using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] GameManager gameManager; // GameManager nesnesine eriþmek için referans

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // GameManager nesnesini bul
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Çarpýþmanýn gerçekleþtiði nesnenin etiketini kontrol et
        {
            gameManager.EndGame(); // Oyunu bitir
        }
    }
}
