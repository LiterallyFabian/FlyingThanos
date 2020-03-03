using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class christmasMusic : MonoBehaviour {
    public AudioClip julmusik;
	public AudioClip speedmusik;
    public AudioClip beachmusik;
    public AudioClip halloween;
    public GameObject thanos;
    

	// Use this for initialization
	void Start () {
        
		if(PlayerPrefs.GetInt("skin", 0) == 4)
        {
            GetComponent<AudioSource>().clip = julmusik;
            GetComponent<AudioSource>().Play();
        }
		if(guiController.speedmode == true)
		        {
            GetComponent<AudioSource>().clip = speedmusik;
            GetComponent<AudioSource>().Play();
        }
        if(PlayerPrefs.GetInt("map", 0) == 2)
        {
            GetComponent<AudioSource>().clip = halloween;
            GetComponent<AudioSource>().Play();
        }
        if(PlayerPrefs.GetInt("skin", 1) == 1 && guiController.speedmode == false && PlayerPrefs.GetInt("skin", 0) != 4)
        {
            GetComponent<AudioSource>().clip = beachmusik;
            GetComponent<AudioSource>().Play();
            thanos.GetComponent<AudioSource>().volume = 0.2f;
        }
        else
        {
            thanos.GetComponent<AudioSource>().volume = 1f;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
