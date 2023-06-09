using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] KeyCode restartKey = KeyCode.R;
    [SerializeField] KeyCode quitKey = KeyCode.Escape;
    [SerializeField] GameObject gameOverTextObject;
    [SerializeField] GameObject blackoutPanel;
    private bool gameOver = false;
    private bool isPlayerDead = false;
    public int score = 0;

    private void Start()
    {
        gameOverTextObject.SetActive(false);
        blackoutPanel.SetActive(false);

        // Level baþladýðýnda PlayerPrefs'ten kaydedilmiþ bir score varsa onu yükle
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
    }

    private void Update()
    {
        // ...

        if (isPlayerDead)
        {
            if (Input.GetKeyDown(restartKey))
            {
                RestartGame();
            }

            if (Input.GetKeyDown(quitKey))
            {
                QuitGame();
            }
        }
    }

    public void PlayerDeath()
    {
        if (!isPlayerDead)
        {
            isPlayerDead = true;
            gameOverTextObject.SetActive(true);
            blackoutPanel.SetActive(true);
            Debug.Log("Karakter öldü!");

            // Score'u PlayerPrefs'e kaydet
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.Save();
        }
    }
    public void EndGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("Oyun bitti!"); 

            
        }
    }
    private void RestartGame()
    {
        // PlayerPrefs'te saklanan score'u sýfýrla
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
}
