using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lives;
    public int score;
    public Text scoreText;
    public Text livesText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public int totalBricks;

    private int destroyedBricks = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateTexts();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateLives(int changeInLives)
    {
        lives += changeInLives;

        if (lives <= 0)
        {
            lives = 0;
            endGame();

        }

        updateTexts();
    }

    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quit()
    {
        Application.Quit();
    }

    private void endGame()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
    }

    public void updateScore(int score)
    {
        this.score += score;
        updateTexts();
    }

    public void notifyBrickDestroyed()
    {
        destroyedBricks++;
        if(destroyedBricks >= totalBricks)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
        }
    }

    private void updateTexts()
    {
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }
}
