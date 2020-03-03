using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class catchcollision : MonoBehaviour
{
    public AudioClip normal;
    public AudioClip whistle;
    public AudioClip clap;
    public AudioClip finish;
    public AudioClip tick;
    public AudioClip quiet;
    private double acc;
    public static int smallscore = 2;
    public static int largescore = 13;

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
        }
        else
        {
            catchSpawner.osumaxscore += smallscore;
            catchSpawner.osuscore += smallscore;
            PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumax", 0) + smallscore);
            PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osucol", 0) + smallscore);

        }

        if (collider.gameObject.transform.position.z != 89)
        {
            if (collider.gameObject.transform.position.z == 1) //whistle
                GetComponent<AudioSource>().clip = whistle;
            else if (collider.gameObject.transform.position.z == 2) //finish
                GetComponent<AudioSource>().clip = finish;
            else if (collider.gameObject.transform.position.z == 3) //clap
                GetComponent<AudioSource>().clip = clap;
            else if (collider.gameObject.transform.position.z == 3) //drumwhistle
                GetComponent<AudioSource>().clip = clap;
            else
                GetComponent<AudioSource>().clip = normal;
            GetComponent<AudioSource>().Play();
        }
        Destroy(collider.gameObject);

    }
    void Update()
    {
        //Debug.Log($"Spawned: {catchSpawner.osumaxscore}  Catched: {catchSpawner.osuscore}  Missed: {catchSpawner.osumiss}  Acc: {Math.Round(acc, 2)}%  Hotel: Trivago");
        acc = catchSpawner.osuscore / catchSpawner.osumaxscore * 100;
        GameObject.Find("acc").GetComponent<Text>().text = $"{Math.Round(acc, 2)}%";
    }
}
//