using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float slowdownMultiplier = 0.5f; // Yava�latma fakt�r�
    public float slowdownDuration = 5f; // Yava�latman�n s�resi (saniye)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerMovement = other.GetComponent<PlayerController>();
            if (playerMovement != null)
            {
                playerMovement.ApplySlowDown(slowdownMultiplier); // H�z� azalt

                // Belirli bir s�re sonra h�z� tekrar eski de�erine d�nd�rmek i�in Invoke fonksiyonunu kullan
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