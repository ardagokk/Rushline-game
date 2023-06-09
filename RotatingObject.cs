using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 500f;
    private GameManager gameManager;
    private void Update()
    {
        // Game object'i hýzlý bir þekilde döndürmek için
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Karakter game object'e çarptýðýnda ölmesini saðlamak için
        if (other.CompareTag("Player"))
        {
            // Karakterin ölüm iþlemlerini burada gerçekleþtirebilirsiniz
            PlayerDeath(other.gameObject);
        }
    }

    private void PlayerDeath(GameObject player)
    {
        player.SetActive(false); // Karakteri etkisiz hale getirerek öldürme örneði
        Debug.Log("Karakter öldü!");

        gameManager.PlayerDeath();
    }
}