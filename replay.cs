using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // R tuþuna basýldýðýnda
        {
            SceneManager.LoadScene("Level1"); // Level 1'i yükle
        }
    }
}