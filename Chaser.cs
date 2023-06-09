using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform target; // Hedef obje
    public float speed = 5f; // Kovalayan objenin hareket hýzý
    GameManager gameManager;
    public float rotationSpeed = 5f;
    
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = FindObjectOfType<GameManager>();

    }
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();

        // Yüzün karaktere doðru dönmesini saðla
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Kovalayan objeyi ileri doðru hareket ettir
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Çarpýþan obje karakterse, karakteri öldür
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            gameManager.PlayerDeath();
        }
    }
}
