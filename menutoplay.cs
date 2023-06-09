using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menutoplay : MonoBehaviour
{
    public Scoring score;
    public string leveladi;
    // Start is called before the first frame update

    public void PlayGame()
    {
    
        SceneManager.LoadScene(leveladi);
    }
    public void QuitGame()
    {
      
        Application.Quit();
    }
}
