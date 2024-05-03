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
    }
   public void NextLevel()
    {

    }

    public void RestartLevel() { }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        if (currentScore > bestscore) { 
        
        bestscore = currentScore;}
    }


    void Start()
    {
        
    }

   

}
