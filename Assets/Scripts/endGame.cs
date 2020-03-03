using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class endGame : MonoBehaviour 
{
	private GameObject ScoreObj;
	private GameObject TimerObj;

	private Text TimerTextComp;
	private Text ScoreTextComp;
   // public int highScore = 0;
 //   string highScoreKey = "HScore";

    private void Start()
    {
        //�ndrar textens f�rg till r�d om man n�r 200 po�ng
        if (guiController.scoreHit >= 300)
        {
            if (guiController.scoreHit < 450)
            {
                ScoreTextComp.color = new Color(216.0f / 255.0f, 28.0f / 255.0f, 2.0f / 255.0f);
            }

        }
        //�ndrar textens f�rg till m�rkr�d om man n�r 400 po�ng
        if (guiController.scoreHit > 450)
        {
            if (guiController.scoreHit < 600)
            {
                ScoreTextComp.color = new Color(170.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);
            }
        }
        //�dndrar textens f�rg till en m�rkare r�d om man n�r 500 po�ng
        if (guiController.scoreHit > 600)
        {
            ScoreTextComp.color = new Color(122.0f / 255.0f, 6.0f / 255.0f, 5.0f / 255.0f);
        }
    }

    void Awake()
    {

        ScoreObj = GameObject.Find("Score");
        TimerObj = GameObject.Find("Timer");
      //  HighscoreObj = GameObject.Find("HScore");
    //    HighscoreComp = HighscoreObj.GetComponent<Text>();
        TimerTextComp = TimerObj.GetComponent<Text>();
        ScoreTextComp = ScoreObj.GetComponent<Text>();

        TimerTextComp.text = "Time left: 60";
        ScoreTextComp.text = "Score: " + guiController.scoreHit.ToString();


    }
    
}

