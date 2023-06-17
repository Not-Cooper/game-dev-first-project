using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int playerScore;
    private int highScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        ScoreData scoreData = SaveSystem.loadScore();
        highScore = scoreData.score;
        if (scoreText != null)
        {
            highScoreText.text = highScore.ToString();
        }
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;

        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = highScore.ToString();
        }

        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        FindAnyObjectByType<AudioManager>().Play("Theme");
    }

    public void gameOver()
    {
        if (playerScore >= highScore)
        {
            SaveSystem.SaveScore(this);
        }
        gameOverScreen.SetActive(true);
    }

    public int getScore()
    {
        return this.playerScore;
    }

    public int getHighScore()
    {
        return this.highScore;
    }
}
