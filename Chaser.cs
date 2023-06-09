using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform target; // Hedef obje
    public float speed = 5f; // Kovalayan objenin hareket h�z�
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

        // Y�z�n karaktere do�ru d�nmesini sa�la
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        // Kovalayan objeyi ileri do�ru hareket ettir
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // �arp��an obje karakterse, karakteri �ld�r
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            gameManager.PlayerDeath();
        }
    }
}
