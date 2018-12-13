using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameManager : MonoBehaviour {

    int score, waveNum;
    public Text scoreDisplay, highScoreText;

	// Use this for initialization
	void Start () {
		if(MainMenuController.waves)
        {
            waveNum = GameOverManager.waveNumber;
            scoreDisplay.text = "You Made It To Wave " + waveNum;
            if (PlayerPrefs.HasKey("BestWave"))
            {
                int highScore = PlayerPrefs.GetInt("BestWave");
                
                if (waveNum > highScore)
                {
                    PlayerPrefs.SetInt("BestWave", waveNum);
                    highScoreText.text = "You set the new high score!";
                }
                else
                {
                    highScoreText.text = "Best Wave: " + highScore;
                }
            }
            else
            {
                PlayerPrefs.SetInt("BestWave", waveNum);
                highScoreText.text = "You set the new high score!";
            }
        }
        else
        {
            score = ScoreManager.score;
            scoreDisplay.text = "Your Total Score Was: " + score;
            if (PlayerPrefs.HasKey("BestScoreSS"))
            {
                int highScore = PlayerPrefs.GetInt("BestScoreSS");
                
                if (score > highScore)
                {
                    PlayerPrefs.SetInt("BestScoreSS", score);
                    highScoreText.text = "You set the new high score!";
                }
                else
                {
                    highScoreText.text = "High Score: " + highScore;
                }
            }
            else
            {
                PlayerPrefs.SetInt("BestScoreSS", score);
                highScoreText.text = "You set the new high score!";
            }
        }
	}

    public void BackToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}