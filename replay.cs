using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R tu�una bas�ld���nda
        {
            SceneManager.LoadScene("Level1"); // Level 1'i y�kle
        }
    }
}