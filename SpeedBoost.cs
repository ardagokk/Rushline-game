using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostMultiplier = 2f; // Hýzlandýrma faktörü
    public float boostDuration = 0.05f; // Hýzlandýrmanýn süresi (saniye)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerMovement = other.GetComponent<PlayerController>();
            if (playerMovement != null)
            {
                playerMovement.SpeedBoost(boostMultiplier); // Hýzý artýr

                // Belirli bir süre sonra hýzý tekrar eski deðerine döndürmek için Invoke fonksiyonunu kullan
                Invoke("ResetSpeed", boostDuration);
            }

            Destroy(gameObject);
        }
    }

    private void ResetSpeed()
    {
        // Hýzý tekrar normal deðere döndür
        PlayerController playerMovement = FindObjectOfType<PlayerController>();
        if (playerMovement != null)
        {
            playerMovement.ResetSpeed();
        }
    }
}
