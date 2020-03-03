using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Devmode : MonoBehaviour {
    public AudioClip devmodeon;
    public AudioClip devmodeoff;
    public bool devmode = false;
    private GameObject devobj;
    public static Text devtext;
    public Transform powerupSlow;
    public Transform powerupDouble;
    public Transform powerupShield;
    public Transform powerupRepair;
    public Transform powerupTimer;
    public Transform powerupVirus;

    // Use this for initialization
    void Start () {
        devobj = GameObject.Find("devmodetext");
        devtext = devobj.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        //startar devmode
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (devmode==false)
            {
                transform.localPosition = new Vector3(-306, -200, 0);
                guiController.playTime = 100000f;
                GetComponent<AudioSource>().clip = devmodeon;
                GetComponent<AudioSource>().Play();
                devmode = true;
                guiController.TimerTextComp.fontSize = 50;
                devtext.fontSize = 22;
                guiController.lifes = 1000;
            }
        }
        //går ut ifrån devmode
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (devmode==true)
            {
                transform.localPosition = new Vector3(-306, -290, 0);
                guiController.playTime = 60f;
                guiController.scoreHit = 0;
                GetComponent<AudioSource>().clip = devmodeoff;
                GetComponent<AudioSource>().Play();
                devmode = false;
                guiController.TimerTextComp.fontSize = 22;
                devtext.fontSize = 50;
                guiController.lifes = 3;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(powerupSlow, new Vector3(16, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(powerupDouble, new Vector3(16, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(powerupShield, new Vector3(16, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(powerupRepair, new Vector3(16, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(powerupTimer, new Vector3(16, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Instantiate(powerupVirus, new Vector3(16, 0, 0), Quaternion.identity);
            viruscontroller.hasvirus = false;
        }
        




    }
}

