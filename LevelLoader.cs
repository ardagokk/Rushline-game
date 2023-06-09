using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string levelad�; // Ge�mek istedi�iniz sahnenin ismi

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // E�er ge�i� yap�lacak nesne "Player" etiketine sahipse
        {
            SceneManager.LoadScene(levelad�); // Yeni sahneye ge�i� yap
        }
    }
}
