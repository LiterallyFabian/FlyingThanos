using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class guiController : MonoBehaviour 
{
	//scoreHit ska kunna nås enkelt från annat skript. Därför Static!
	public static int scoreHit;
    public static int scoreHitpvp;
    public static bool speedmode;
    public static bool sharpmode;
    public static bool swarmmode;
    public static bool newmode;
    public static bool osu;
    public static bool classicmode;
    public static bool pvpmode;
    public Transform salt;
    public Text TimerText;
    public Image TimerUI;
    public Image ScoreUI;
    public static GameObject thanos;
    public GameObject ThanosMain;
    public GameObject ThanosPVP;
    public GameObject ThanosMainsprite;
    public GameObject ThanosPVPsprite;
    public static bool lastmodepvp;


    //playTime-variabeln finns i 2 skript. Den deklareras i detta skript. 
    //Ordet "static" gör att även skriptet guiStart kan hämta variabelvärdet!
    //playTime kan du ändra för att förlänga speltiden.
    public static float playTime = 60.0f;
    public static float playTimepvp = 60.0f;
    public static float actualPlayTime = 0f;
    public static float lifes = 3f;
    public static float ptime = 0f;


	private GameObject ScoreObj;
	private GameObject TimerObj;
    public static Text TimerTextComp;
	private Text ScoreTextComp;

    private GameObject ScoreObjpvp;
    private GameObject TimerObjpvp;
    public static Text TimerTextComppvp;
    private Text ScoreTextComppvp;


    void Awake()
	{
		ScoreObj = GameObject.Find ("Score");
		TimerObj = GameObject.Find ("Timer");
		TimerTextComp = TimerObj.GetComponent<Text> ();
		ScoreTextComp = ScoreObj.GetComponent<Text> ();
        ScoreObjpvp = GameObject.Find("ScorePVP");
        TimerObjpvp = GameObject.Find("TimerPVP");
            TimerTextComppvp = TimerObjpvp.GetComponent<Text>();
            ScoreTextComppvp = ScoreObjpvp.GetComponent<Text>();
        scoreHit = 0;
        scoreHitpvp = 0;
		playTime=60f;
        playTimepvp = 60f;
        actualPlayTime = 0f;
        if(sharpmode == true){
            playTime = 6000f;
        }



	}

	void Update () 
	{
        ptime += Time.deltaTime;
        //Räkna ned tiden. Gå till gameOver-scenen när tiden gått ut!
        if (collisions.powerupslow == false)
        {
            playTime -= Time.deltaTime;
            playTimepvp -= Time.deltaTime;
        }
        if (playTime >= 0)
        {
            actualPlayTime += Time.deltaTime;
            TimerTextComp.text = "Time left: " + playTime.ToString("F1");
            ScoreTextComp.text = "Score: " + scoreHit.ToString();
        } else if (pvpmode == true)
        {
            TimerTextComp.text = "PLAYER 1 OUT";
        }
        if (playTimepvp >= 0 && pvpmode == true)
        {
            TimerTextComppvp.text = "Time left: " + playTimepvp.ToString("F1");
            ScoreTextComppvp.text = "Score: " + scoreHitpvp.ToString();
        }
        else if (playTimepvp <= 0 && pvpmode == true)
        {
            TimerTextComppvp.text = "PLAYER 2 OUT";
        }

            if (sharpmode == true)
        {
            ScoreUI.transform.localPosition = new Vector3(81.7f, -32.0f, 139.5f);
            TimerUI.enabled = false;
            TimerText.enabled = false;
        } else
        {
            TimerUI.enabled = true;
            TimerText.enabled = true;
        }


		if(pvpmode == true && playTime<=0 && playTimepvp<=0)
		{
            lastmodepvp = true;
			SceneManager.LoadScene (0);
		} else if (pvpmode == false && playTime <= 0)
        {
            lastmodepvp = false;
            SceneManager.LoadScene(0);
        }
        if(pvpmode == true && playTime <= 0)
        {
            ThanosMain.GetComponent<AudioSource>().clip = collisions.deathsound;
            ThanosMain.GetComponent<AudioSource>().Play();
            Destroy(ThanosMain);
        }
        if (pvpmode == true && playTimepvp <= 0)
        {
            ThanosPVP.GetComponent<AudioSource>().clip = collisions.deathsound;
            ThanosPVP.GetComponent<AudioSource>().Play();
            Destroy(ThanosPVP);
        }

        //om man kör sharp shurikens & har 0 liv så dör man
        if (lifes == 0 && sharpmode == true){
            SceneManager.LoadScene (0);
        }

        /*
        FÖLJANDE KOD LÄSES PÅ EGEN RISK
        BE GONE FABIAN
        DON'T DO THIS TO YOURSELF
        AVOID THIS FUCKING MESS
        DO SOMETHING BETTER WITH YOUR LIFE
        last warning


        enjoy
        */
        if(playTime>25)
        {
            TimerTextComp.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
        }

        //Mörkröd siffra, när tiden är under 5
        if(playTime<=5)
        {
            TimerTextComp.color = new Color(153.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);
        }
        //Orange siffra, när tiden är mellan 10-17
        if(playTime<=17)
        {
            if (playTime > 10)
            {
                TimerTextComp.color = new Color(255.0f / 255.0f, 136.0f / 255.0f, 0.0f / 255.0f);
            }
        }
        //Röd siffra, när tiden är mellan 5-10
        if (playTime <= 10)
        {
            if (playTime > 5)
            {
                TimerTextComp.color = new Color(255.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
            }
        }
        //Ändrar textens färg till gul, om tiden är mellan 17-25 sekunder
        if (playTime <= 25)
        {
            if (playTime > 17)
            {
                TimerTextComp.color = new Color(242.0f / 255.0f, 203.0f / 255.0f, 9.0f / 255.0f);
            }
        }
        //Ändrar textens färg till röd om man når 200 poäng
        if (scoreHit >= 400)
        {
            if (scoreHit < 550)
            {
                ScoreTextComp.color = new Color(216.0f / 255.0f, 28.0f / 255.0f, 2.0f / 255.0f);
            }
           
        }
        //ändrar textens färg till mörkröd om man når 400 poäng
        if (scoreHit>550)
        {
            if (scoreHit<750)
            {
                ScoreTextComp.color = new Color(170.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);
            }
        }
        //ädndrar textens färg till en mörkare röd om man når 500 poäng
        if (scoreHit > 750)
        {
                ScoreTextComp.color = new Color(122.0f / 255.0f, 6.0f / 255.0f, 5.0f / 255.0f);
        }

        //ändrar textens färg till svart när spelet börjar eller när man går in i devmode
        if (playTime >= 59)
        {
            if (playTime>40)
            {
                TimerTextComp.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
            }
        }
        //Sätter score texten till svart när spelet börjar
        if (scoreHit == 0)
        {
            ScoreTextComp.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
        }
        //Ändrar textens färg till blå medans slow powerupen är aktiv
        if (collisions.powerupslow == true)
        {
            TimerTextComp.color = new Color(35.0f / 255.0f, 119.0f / 255.0f, 237.0f / 255.0f);
        }
        /////////
        if (pvpmode == true)
        {
            if (playTimepvp > 25)
            {
                TimerTextComppvp.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
            }

            //Mörkröd siffra, när tiden är under 5
            if (playTimepvp <= 5 && playTimepvp > 0)
            {
                TimerTextComppvp.color = new Color(153.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);
            }
            //Orange siffra, när tiden är mellan 10-17
            if (playTimepvp <= 17)
            {
                if (playTimepvp > 10)
                {
                    TimerTextComppvp.color = new Color(255.0f / 255.0f, 136.0f / 255.0f, 0.0f / 255.0f);
                }
            }
            //Röd siffra, när tiden är mellan 5-10
            if (playTimepvp <= 10)
            {
                if (playTimepvp > 5)
                {
                    TimerTextComppvp.color = new Color(255.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
                }
            }
            //Ändrar textens färg till gul, om tiden är mellan 17-25 sekunder
            if (playTimepvp <= 25)
            {
                if (playTimepvp > 17)
                {
                    TimerTextComppvp.color = new Color(242.0f / 255.0f, 203.0f / 255.0f, 9.0f / 255.0f);
                }
            }
            //Ändrar textens färg till röd om man når 200 poäng
            if (scoreHitpvp >= 400)
            {
                if (scoreHitpvp < 550)
                {
                    ScoreTextComppvp.color = new Color(216.0f / 255.0f, 28.0f / 255.0f, 2.0f / 255.0f);
                }

            }
            //ändrar textens färg till mörkröd om man når 400 poäng
            if (scoreHitpvp > 550)
            {
                if (scoreHitpvp < 750)
                {
                    ScoreTextComppvp.color = new Color(170.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);
                }
            }
            //ädndrar textens färg till en mörkare röd om man når 500 poäng
            if (scoreHitpvp > 750)
            {
                ScoreTextComppvp.color = new Color(122.0f / 255.0f, 6.0f / 255.0f, 5.0f / 255.0f);
            }

            //ändrar textens färg till svart när spelet börjar eller när man går in i devmode
            if (playTimepvp >= 59)
            {
                if (playTimepvp > 40)
                {
                    TimerTextComppvp.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
                }
            }
            //Sätter score texten till svart när spelet börjar
            if (scoreHitpvp == 0)
            {
                ScoreTextComppvp.color = new Color(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f);
            }
            //Ändrar textens färg till blå medans slow powerupen är aktiv
            if (collisions.powerupslow == true)
            {
                TimerTextComppvp.color = new Color(35.0f / 255.0f, 119.0f / 255.0f, 237.0f / 255.0f);
            }
        }
        if (pvpmode == false && playTime <= 0)
        {
            lastmodepvp = false;
            SceneManager.LoadScene(0);
        }
    }


}
