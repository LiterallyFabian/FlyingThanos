﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class endgameComment : MonoBehaviour {
    private GameObject CommentObj;
    public static Text CommentTextComp;
    public static int fixedscoreone;
    public static int fixedscoretwo;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("totalscore", PlayerPrefs.GetInt("totalscore", 0) + guiController.scoreHit);
        CommentObj = GameObject.Find("comment");
        CommentTextComp = CommentObj.GetComponent<Text>();
        fixedscoreone = guiController.scoreHit - guiController.scoreHitpvp;
        fixedscoretwo = guiController.scoreHitpvp - guiController.scoreHit;
        if (guiController.lastmodepvp == false)
        {
            if (guiController.scoreHit < 25)
            {
                CommentTextComp.text = "no comment";
            }
            if (guiController.scoreHit >= 25 && guiController.scoreHit <= 50)
            {
                CommentTextComp.text = "did you even try?";
            }
            if (guiController.scoreHit >= 51 && guiController.scoreHit <= 75)
            {
                CommentTextComp.text = "at least you tried! I think..";
            }
            if (guiController.scoreHit >= 76 && guiController.scoreHit <= 125)
            {
                CommentTextComp.text = "try to avoid the shurikens next time";
            }
            if (guiController.scoreHit >= 126 && guiController.scoreHit <= 175)
            {
                CommentTextComp.text = "better luck next time!";
            }
            if (guiController.scoreHit >= 251 && guiController.scoreHit <= 275)
            {
                CommentTextComp.text = "nice score!";
            }
            if (guiController.scoreHit >= 176 && guiController.scoreHit <= 199)
            {
                CommentTextComp.text = "almost 200!";
            }
            if (guiController.scoreHit >= 200 && guiController.scoreHit <= 225)
            {
                CommentTextComp.text = "above 200!";
            }
            if (guiController.scoreHit >= 226 && guiController.scoreHit <= 250)
            {
                CommentTextComp.text = "Well done!";
            }
            if (guiController.scoreHit >= 251 && guiController.scoreHit <= 280)
            {
                CommentTextComp.text = "good job!";
            }
            if (guiController.scoreHit >= 281 && guiController.scoreHit <= 299)
            {
                CommentTextComp.text = "Almost 300!";
            }
            if (guiController.scoreHit >= 300 && guiController.scoreHit <= 330)
            {
                CommentTextComp.text = "nice!";
            }
            if (guiController.scoreHit >= 331 && guiController.scoreHit <= 360)
            {
                CommentTextComp.text = "awesome score!";
            }
            if (guiController.scoreHit >= 361 && guiController.scoreHit <= 399)
            {
                CommentTextComp.text = "close to 400!";
            }
            if (guiController.scoreHit >= 400 && guiController.scoreHit <= 419)
            {
                CommentTextComp.text = "Super awesome!";
            }
            if (guiController.scoreHit >= 420 && guiController.scoreHit <= 450)
            {
                CommentTextComp.text = "Awesome score!";
            }
            if (guiController.scoreHit >= 451 && guiController.scoreHit <= 499)
            {
                CommentTextComp.text = "nice score bro!";
            }
            if (guiController.scoreHit >= 500 && guiController.scoreHit <= 540)
            {
                CommentTextComp.text = "above 500??!";
            }
            if (guiController.scoreHit >= 541 && guiController.scoreHit <= 580)
            {
                CommentTextComp.text = "crazy score!";
            }
            if (guiController.scoreHit >= 581 && guiController.scoreHit <= 640)
            {
                CommentTextComp.text = guiController.scoreHit + "  points??";
            }
            if (guiController.scoreHit >= 641 && guiController.scoreHit <= 680)
            {
                CommentTextComp.text = "epic score! good job!";
            }
            if (guiController.scoreHit >= 681 && guiController.scoreHit <= 720)
            {
                CommentTextComp.text = "insane score!";
            }
            if (guiController.scoreHit > 721)
            {
                CommentTextComp.text = guiController.scoreHit + "  points? damn, good job!";
            }
        }
        else if (guiController.lastmodepvp == true && guiController.scoreHit > guiController.scoreHitpvp)
        {
            CommentTextComp.text = "Player one won with " + fixedscoreone + " more points! gg!";
        }
        else if (guiController.lastmodepvp == true && guiController.scoreHit < guiController.scoreHitpvp)
        {
            CommentTextComp.text = "Player two won with " + fixedscoretwo + " more points! gg!";
        }
        else if (guiController.lastmodepvp == true && guiController.scoreHit == guiController.scoreHitpvp)
        {
            CommentTextComp.text = "Well, this is awkward. No one won.";
        }
        if (guiController.scoreHit > PlayerPrefs.GetInt("highscore", 0))
        {
            CommentTextComp.text = "New highscore!!";
            PlayerPrefs.SetInt("highscore", guiController.scoreHit);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
    }

}
 