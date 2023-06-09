using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text FinalText;
    public Text ScoreText;

    private void Start()
    {
        // Level baþladýðýnda PlayerPrefs'ten kaydedilmiþ bir score varsa onu yükle
        if (PlayerPrefs.HasKey("Score"))
        {
            int score = PlayerPrefs.GetInt("Score");
            UpdateScore(score);
        }
        else
        {
            UpdateScore(0);
        }
    }

    public void AddScore(int newScore)
    {
        int currentScore = PlayerPrefs.GetInt("Score", 0) + newScore;
        PlayerPrefs.SetInt("Score", currentScore);
        PlayerPrefs.Save();

        UpdateScore(currentScore);
        
    }

    private void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
        FinalText.text = "Your Final Score: " + score.ToString();

    }
   
}