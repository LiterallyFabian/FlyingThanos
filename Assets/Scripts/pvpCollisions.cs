using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pvpCollisions : MonoBehaviour
{
    public AudioClip collect;
    public AudioClip shuriken;
    public AudioClip doublesound;
    public AudioClip shieldsound;
    public AudioClip repairsound;
    public AudioClip reversesound;
    public static bool powerupdouble = false;
    public static bool powerupslow = false;
    public static bool powerupfast = false;
    public static bool powerupdoubleS = false;
    public static bool powerupslowS = false;
    public static bool powerupshield = false;
    public static bool powerupshieldS = false;
    public static bool poweruprepair = false;
    public static bool powerupReverse = false;
    public static bool powerupReverseS = false;

    void Start()
    {
        if (guiController.speedmode == true)
        {
            guiController.playTime = 45;
        }
        if (guiController.newmode == true)
        {
            guiController.playTime = 10;
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPrefs.SetInt("collects", PlayerPrefs.GetInt("collects", 0) + 1);
        if (collider.gameObject.tag == "vbuck")
        {
            Destroy(collider.gameObject);
            guiController.scoreHitpvp += 10;
            GetComponent<AudioSource>().clip = collect;
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("vbucks", PlayerPrefs.GetInt("vbucks", 0) + 1);
        }
        //Slow powerup
        if (collider.gameObject.tag == "slow")
        {
            Destroy(collider.gameObject);
            powerupslowS = true;
            guiController.actualPlayTime = 0;
            PlayerPrefs.SetInt("slows", PlayerPrefs.GetInt("slows", 0) + 1);
        }
        //Timer powerup
        if (collider.gameObject.tag == "timer")
        {
            Destroy(collider.gameObject);
            guiController.playTimepvp += 10;
            guiController.actualPlayTime = 10;
            PlayerPrefs.SetInt("slows", PlayerPrefs.GetInt("slows", 0) + 1);
        }


        if (collider.gameObject.tag == "enemy")
        {
            Destroy(collider.gameObject);
            guiController.playTimepvp -= 5f;
            GetComponent<AudioSource>().clip = shuriken;
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("shurikens", PlayerPrefs.GetInt("shurikens", 0) + 1);

        }
        if (collider.gameObject.tag == "burger")
        {
            Destroy(collider.gameObject);
            guiController.scoreHitpvp += 3;
            GetComponent<AudioSource>().clip = collect;
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("burgers", PlayerPrefs.GetInt("burgers", 0) + 1);
        }
        //normal 5p
        //sharp 4p
        //speed 8p
        if (collider.gameObject.tag == "lmao")
        {
            Destroy(collider.gameObject);
            guiController.scoreHitpvp += 5;
            GetComponent<AudioSource>().clip = collect;
            GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("slurps", PlayerPrefs.GetInt("slurps", 0) + 1);
        }
    }
    void Update()
    {
        if (guiController.speedmode == true)
        {
            GameObject[] slowness = GameObject.FindGameObjectsWithTag("slow");
            foreach (GameObject powerup in slowness)
                GameObject.Destroy(powerup);
        }
        if (guiController.sharpmode == false)
        {
            GameObject[] repairx = GameObject.FindGameObjectsWithTag("repair");
            foreach (GameObject powerupx in repairx)
                GameObject.Destroy(powerupx);
        }
        if (guiController.sharpmode == true)
        {
            GameObject[] timerx = GameObject.FindGameObjectsWithTag("timer");
            foreach (GameObject timerp in timerx)
                GameObject.Destroy(timerp);
        }
        if (guiController.pvpmode == true)
        {
            GameObject[] doublex = GameObject.FindGameObjectsWithTag("double");
            foreach (GameObject doublep in doublex)
                GameObject.Destroy(doublep);
            if (guiController.pvpmode == true)
            {
                GameObject[] shieldx = GameObject.FindGameObjectsWithTag("shield");
                foreach (GameObject shieldp in shieldx)
                    GameObject.Destroy(shieldp);
            }
            if (guiController.pvpmode == true)
            {
                GameObject[] virusx = GameObject.FindGameObjectsWithTag("virus");
                foreach (GameObject virusp in virusx)
                    GameObject.Destroy(virusp);
            }

        }
    }
}