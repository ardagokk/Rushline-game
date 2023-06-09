using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string leveladý; // Geçmek istediðiniz sahnenin ismi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Eðer geçiþ yapýlacak nesne "Player" etiketine sahipse
        {
            SceneManager.LoadScene(leveladý); // Yeni sahneye geçiþ yap
        }
    }
}
