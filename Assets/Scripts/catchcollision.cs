using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class catchcollision : MonoBehaviour
{
    public static AudioClip normal;
    public static AudioClip whistle;
    public static AudioClip clap;
    public static AudioClip finish;
    public static AudioClip tick;
    public static AudioClip quiet;
    public static GameObject cameraobj;
    public static double acc;
    public static int smallscore = 2;
    public static int largescore = 10;

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osucollects", 0) + 1);
        PlayerPrefs.SetInt("collects", PlayerPrefs.GetInt("collects", 0) + 1);
        
        if (collider.gameObject.tag == "large")
        {
            catchSpawner.osumaxscore += largescore;
            catchSpawner.osuscore += largescore;
            PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumax", 0) + largescore);
            PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osucol", 0) + largescore);
            PlayerPrefs.SetInt("osutotal", PlayerPrefs.GetInt("osutotal", 0) + largescore);
        }
        else
        {
            catchSpawner.osumaxscore += smallscore;
            catchSpawner.osuscore += smallscore;
            PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumax", 0) + smallscore);
            PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osucol", 0) + smallscore);
            PlayerPrefs.SetInt("osutotal", PlayerPrefs.GetInt("osutotal", 0) + smallscore);

        }

    }
    void Update()
    {
        //Debug.Log($"Spawned: {catchSpawner.osumaxscore}  Catched: {catchSpawner.osuscore}  Missed: {catchSpawner.osumiss}  Acc: {Math.Round(acc, 2)}%  Hotel: Trivago");
        acc = catchSpawner.osuscore / catchSpawner.osumaxscore * 100;
        if(catchSpawner.osuscore != 0)
            GameObject.Find("acc").GetComponent<Text>().text = $"{Math.Round(acc, 2)}%";
        else
            GameObject.Find("acc").GetComponent<Text>().text = $"100%";

    }
}
//