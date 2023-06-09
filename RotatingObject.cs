using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 500f;
    private GameManager gameManager;
    private void Update()
    {
        // Game object'i h�zl� bir �ekilde d�nd�rmek i�in
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Karakter game object'e �arpt���nda �lmesini sa�lamak i�in
        if (other.CompareTag("Player"))
        {
            // Karakterin �l�m i�lemlerini burada ger�ekle�tirebilirsiniz
            PlayerDeath(other.gameObject);
        }
    }

    private void PlayerDeath(GameObject player)
    {
        player.SetActive(false); // Karakteri etkisiz hale getirerek �ld�rme �rne�i
        Debug.Log("Karakter �ld�!");

        gameManager.PlayerDeath();
    }
}