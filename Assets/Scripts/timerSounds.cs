using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerSounds : MonoBehaviour {

    public AudioClip timer;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (guiController.newmode == false)
        {
            if (guiController.playTime <= 10.3f)
            {
                if (guiController.playTime >= 10)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (guiController.playTime <= 8.3f)
            {
                if (guiController.playTime >= 8)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (guiController.playTime <= 6.3f)
            {
                if (guiController.playTime >= 6)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (guiController.playTime <= 5.3f)
            {
                if (guiController.playTime >= 5)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (guiController.playTime <= 4.3f)
            {
                if (guiController.playTime >= 4)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (guiController.playTime <= 3.3f)
            {
                if (guiController.playTime >= 3)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (guiController.playTime <= 2.3f)
            {
                if (guiController.playTime >= 2)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
            if (guiController.playTime <= 1.3f)
            {
                if (guiController.playTime >= 1)
                {
                    GetComponent<AudioSource>().clip = timer;
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }
}
