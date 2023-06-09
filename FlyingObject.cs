using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public float speed = 2f; // Hýz deðeri
    public float distance = 2f; // Hareket mesafesi
    private Vector3 initialPosition; // Baþlangýç konumu
    private bool moveRight = true; // Saða doðru hareket edip etmediðini takip eder

    private void Start()
    {
        initialPosition = transform.position; // Baþlangýç konumunu kaydet
    }

    private void Update()
    {
        if (moveRight)
        {
            // Nesneyi saða doðru hareket ettir
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Baþlangýç konumundan belirli mesafede saða ulaþtýðýnda sola dön
            if (transform.position.x >= initialPosition.x + distance)
            {
                moveRight = false;
            }
        }
        else
        {
            // Nesneyi sola doðru hareket ettir
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Baþlangýç konumundan belirli mesafede sola ulaþtýðýnda saða dön
            if (transform.position.x <= initialPosition.x - distance)
            {
                moveRight = true;
            }
        }
    }
}
