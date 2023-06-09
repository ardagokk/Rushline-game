using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float slowdownMultiplier = 0.5f; // Yavaþlatma faktörü
    public float slowdownDuration = 5f; // Yavaþlatmanýn süresi (saniye)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerMovement = other.GetComponent<PlayerController>();
            if (playerMovement != null)
            {
                playerMovement.ApplySlowDown(slowdownMultiplier); // Hýzý azalt

                // Belirli bir süre sonra hýzý tekrar eski deðerine döndürmek için Invoke fonksiyonunu kullan
                Invoke("ResetSpeed", slowdownDuration);
            }

            Destroy(gameObject);
        }
    }

    private void ResetSpeed()
    {
        PlayerController playerMovement = FindObjectOfType<PlayerController>();
        if (playerMovement != null)
        {
            playerMovement.ResetSpeed();
        }
    }
}