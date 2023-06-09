using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    public float speed = 2f; // H�z de�eri
    public float distance = 2f; // Hareket mesafesi
    private Vector3 initialPosition; // Ba�lang�� konumu
    private bool moveRight = true; // Sa�a do�ru hareket edip etmedi�ini takip eder

    private void Start()
    {
        initialPosition = transform.position; // Ba�lang�� konumunu kaydet
    }

    private void Update()
    {
        if (moveRight)
        {
            // Nesneyi sa�a do�ru hareket ettir
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // Ba�lang�� konumundan belirli mesafede sa�a ula�t���nda sola d�n
            if (transform.position.x >= initialPosition.x + distance)
            {
                moveRight = false;
            }
        }
        else
        {
            // Nesneyi sola do�ru hareket ettir
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            // Ba�lang�� konumundan belirli mesafede sola ula�t���nda sa�a d�n
            if (transform.position.x <= initialPosition.x - distance)
            {
                moveRight = true;
            }
        }
    }
}
