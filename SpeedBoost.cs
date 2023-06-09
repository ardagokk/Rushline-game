using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostMultiplier = 2f; // H�zland�rma fakt�r�
    public float boostDuration = 0.05f; // H�zland�rman�n s�resi (saniye)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerMovement = other.GetComponent<PlayerController>();
            if (playerMovement != null)
            {
                playerMovement.SpeedBoost(boostMultiplier); // H�z� art�r

                // Belirli bir s�re sonra h�z� tekrar eski de�erine d�nd�rmek i�in Invoke fonksiyonunu kullan
                Invoke("ResetSpeed", boostDuration);
            }

            Destroy(gameObject);
        }
    }

    private void ResetSpeed()
    {
        // H�z� tekrar normal de�ere d�nd�r
        PlayerController playerMovement = FindObjectOfType<PlayerController>();
        if (playerMovement != null)
        {
            playerMovement.ResetSpeed();
        }
    }
}
