using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int bestscore;
    public  int currentScore;
    public int currentLevel;
   
    public static GameManager singleton;

    private void Awake()
    {
        if (singleton==null)
        
        {
            singleton = this;
        }
        else if (singleton! == this) {
        Destroy(gameObject);
        }

        bestscore = PlayerPrefs.GetInt("HighScore");
    }
   public void NextLevel()
    {
        Debug.Log("pasamos de nivel");
    }

    public void RestartLevel() {

        Debug.Log("Restart");
        singleton.currentScore = 0;
        FindAnyObjectByType<BallController>().ResetBall();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        if (currentScore > bestscore) { 
        
        bestscore = currentScore;}
        PlayerPrefs.SetInt("HighScore", currentScore);
    }


    void Start()
    {
        
    }

   

}
