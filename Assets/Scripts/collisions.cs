using UnityEngine;
using System.Collections;

public class collisions : MonoBehaviour 
{
	public AudioClip collect;
	public AudioClip shuriken;
    public AudioClip doublesound;
    public AudioClip shieldsound;
    public AudioClip repairsound;
    public static AudioClip deathsound;
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

    void Start () 
	{
        if (guiController.speedmode == true){
                guiController.playTime = 45;
            }
            if(guiController.newmode == true){
            guiController.playTime = 10;
            }

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
        PlayerPrefs.SetInt("currentCollects", PlayerPrefs.GetInt("currentCollects", 0) + 1);
        PlayerPrefs.SetInt("collects", PlayerPrefs.GetInt("collects", 0) + 1);
        if (collider.gameObject.tag=="vbuck")
		{
			Destroy(collider.gameObject);
		guiController.scoreHit+=10;
			GetComponent<AudioSource>().clip=collect;
			GetComponent<AudioSource>().Play();
            PlayerPrefs.SetInt("vbucks", PlayerPrefs.GetInt("vbucks", 0)+1);
            if(collisions.powerupdouble == true)
            {
                guiController.scoreHit += 10;
            }
            if(guiController.speedmode == true){
                guiController.scoreHit += 5;
            }
            if(guiController.sharpmode == true){
                guiController.scoreHit -=3;
            }
            if (guiController.newmode == true)
            {
                PlayerPrefs.SetFloat("refueltime", PlayerPrefs.GetFloat("refueltime", 0) + 0.8f);
                guiController.playTime +=0.8f;
                guiController.scoreHit -= 2;
            }
            if(guiController.swarmmode == true)
            {
                guiController.scoreHit += 2;
            }
        }
        //Double powerup
        if(collider.gameObject.tag=="double")
        {
            Destroy(collider.gameObject);
            GetComponent<AudioSource>().clip = doublesound;
            GetComponent<AudioSource>().Play();
            powerupdoubleS = true;
            guiController.actualPlayTime = 0;
            PlayerPrefs.SetInt("doubles", PlayerPrefs.GetInt("doubles", 0) + 1);
        }
        if (collider.gameObject.tag == "reverse")
        {
            Destroy(collider.gameObject);
            GetComponent<AudioSource>().clip = reversesound;
            GetComponent<AudioSource>().Play();
            powerupReverse = true;
            guiController.actualPlayTime = -5;
            PlayerPrefs.SetInt("reverses", PlayerPrefs.GetInt("reverses", 0) + 1);
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
            guiController.playTime += 15;
            guiController.actualPlayTime = 10;
            if (guiController.speedmode == true)
            {
                guiController.playTime -= 5;
            }
            if (guiController.newmode == true)
            {
                guiController.playTime -= 9;
            }
            PlayerPrefs.SetInt("powercollects", PlayerPrefs.GetInt("powercollects", 0) + 1);
            PlayerPrefs.SetFloat("refueltime", PlayerPrefs.GetFloat("refueltime", 0) + 9f);
            PlayerPrefs.SetInt("timers", PlayerPrefs.GetInt("timers", 0) + 1);
        }

            //Shield powerup
            if (collider.gameObject.tag == "shield")
        {
            Destroy(collider.gameObject);
            GetComponent<AudioSource>().clip = shieldsound;
            GetComponent<AudioSource>().Play();
            powerupshieldS = true;
            guiController.actualPlayTime = 0;
            PlayerPrefs.SetInt("shields", PlayerPrefs.GetInt("shields", 0) + 1);
        }
        //Repair powerup
        if (collider.gameObject.tag == "repair")
        {
            Destroy(collider.gameObject);
            GetComponent<AudioSource>().clip = repairsound;
            GetComponent<AudioSource>().Play();
            guiController.lifes += 1;
            guiController.actualPlayTime = 4;
            poweruprepair = true;
            PlayerPrefs.SetInt("repairs", PlayerPrefs.GetInt("repairs", 0) + 1);
        }


        if (collider.gameObject.tag=="enemy")
		{
			Destroy(collider.gameObject);
			guiController.playTime-=5f;
            PlayerPrefs.SetInt("shurikens", PlayerPrefs.GetInt("shurikens", 0) + 1);
            GetComponent<AudioSource>().clip=shuriken;
			GetComponent<AudioSource>().Play();
            if (collisions.powerupslow == true)
            {
                guiController.playTime += 3;
            }
            if (collisions.powerupshield == true)
            {
                guiController.playTime += 5;
                guiController.lifes += 1;
            }
            if(goodluckFade.fadingspeed == true){
                guiController.playTime += 5;
            }
            if(guiController.speedmode == true){
                guiController.playTime += 2f;
            }
            if (guiController.sharpmode == true)
            {
                guiController.lifes -= 1f;
            }
            if (guiController.newmode == true)
            {
                guiController.playTime += 0.2f;
            }
            if (guiController.swarmmode == true)
            {
                guiController.scoreHit += 1;
            }
        }
        if (collider.gameObject.tag == "burger")
        {
            Destroy(collider.gameObject);
            guiController.scoreHit+=3;
            GetComponent<AudioSource>().clip= collect;
            GetComponent<AudioSource>().Play();
            if (collisions.powerupdouble == true)
            {
                guiController.scoreHit += 3;
            }
                if(guiController.speedmode == true){
                guiController.scoreHit += 1;
            }
            if (guiController.newmode == true)
            {
                PlayerPrefs.SetFloat("refueltime", PlayerPrefs.GetFloat("refueltime", 0) + 0.2f);
                guiController.playTime += 0.2f;
                guiController.scoreHit += 1;
            }
            if (guiController.swarmmode == true)
            {
                guiController.scoreHit += 2;
            }
            PlayerPrefs.SetInt("burgers", PlayerPrefs.GetInt("burgers", 0) + 1);
        }
        //normal 5p
        //sharp 4p
        //speed 8p
        if (collider.gameObject.tag == "lmao")
        {
            Destroy(collider.gameObject);
            guiController.scoreHit+=5;
            GetComponent<AudioSource>().clip= collect;
            GetComponent<AudioSource>().Play();
            if (collisions.powerupdouble == true)
            {
                guiController.scoreHit += 5;
            }
            if(guiController.speedmode == true){
                guiController.scoreHit += 3;
            }
            if(guiController.sharpmode == true){
                guiController.scoreHit -= 1;
            }
            if (guiController.newmode == true)
            {
                PlayerPrefs.SetFloat("refueltime", PlayerPrefs.GetFloat("refueltime", 0) + 0.4f);
                guiController.playTime += 0.4f;
                guiController.scoreHit += 1;
            }
            if (guiController.swarmmode == true)
            {
                guiController.scoreHit += 2;
            }
            PlayerPrefs.SetInt("slurps", PlayerPrefs.GetInt("slurps", 0) + 1);
        }
    }
	void Update () 
	{
		if(guiController.speedmode == true){
   GameObject[] slowness = GameObject.FindGameObjectsWithTag("slow");
   foreach(GameObject powerup in slowness)
   GameObject.Destroy(powerup);
        }
        if(guiController.sharpmode == false){
   GameObject[] repairx = GameObject.FindGameObjectsWithTag("repair");
   foreach(GameObject powerupx in repairx)
   GameObject.Destroy(powerupx);
        }
        if (guiController.sharpmode == true)
        {
            GameObject[] timerx = GameObject.FindGameObjectsWithTag("timer");
            foreach (GameObject timerp in timerx)
                GameObject.Destroy(timerp);
        }
        if (viruscontroller.hasvirus == true)
        {
            GameObject[] timerx = GameObject.FindGameObjectsWithTag("virus");
            foreach (GameObject timerp in timerx)
                GameObject.Destroy(timerp);
        }

    }
}
