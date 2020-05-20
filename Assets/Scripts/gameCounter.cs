using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("playtime", 0);
        if (guiController.pvpmode == true)
        {
            PlayerPrefs.SetInt("pvp", PlayerPrefs.GetInt("pvp", 0) + 1);
        }
        else if (guiController.sharpmode == true)
        {
            PlayerPrefs.SetInt("sharp", PlayerPrefs.GetInt("sharp", 0) + 1);
        }
        else if (guiController.swarmmode == true)
        {
            PlayerPrefs.SetInt("swarm", PlayerPrefs.GetInt("swarm", 0) + 1);
        }
        else if (guiController.newmode == true)
        {
            PlayerPrefs.SetInt("refuel", PlayerPrefs.GetInt("refuel", 0) + 1);
        }
        else if (guiController.osu == true)
        {
            PlayerPrefs.SetInt("osu", PlayerPrefs.GetInt("osu", 0) + 1);
        }
        else if (guiController.speedmode == true)
        {
            PlayerPrefs.SetInt("flyingfast", PlayerPrefs.GetInt("flyingfast", 0) + 1);
        }
        else
        {
            PlayerPrefs.SetInt("classic", PlayerPrefs.GetInt("classic", 0) + 1);
        }
        PlayerPrefs.SetInt("games", PlayerPrefs.GetInt("games", 0) + 1);

        if (PlayerPrefs.GetInt("skin", 0) == 4)
        {
            PlayerPrefs.SetInt("snowmap", PlayerPrefs.GetInt("snowmap", 0) + 1);
        }
        else if (PlayerPrefs.GetInt("map", 0) == 1)
        {
            PlayerPrefs.SetInt("beachmap", PlayerPrefs.GetInt("beachmap", 0) + 1);
        }
        else if (PlayerPrefs.GetInt("map", 0) == 0)
        {
            PlayerPrefs.SetInt("grassmap", PlayerPrefs.GetInt("grassmap", 0) + 1);
        }
        else if (PlayerPrefs.GetInt("map", 0) == 2)
        {
            PlayerPrefs.SetInt("spookymap", PlayerPrefs.GetInt("spookymap", 0) + 1);
        }

            PlayerPrefs.SetInt($"thanos{PlayerPrefs.GetInt("skin", 0)}", PlayerPrefs.GetInt($"thanos{PlayerPrefs.GetInt("skin", 0)}", 0) + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (guiController.scoreHit > PlayerPrefs.GetInt("swarmscore", 0) && guiController.swarmmode == true)
        {
            PlayerPrefs.SetInt("swarmscore", guiController.scoreHit);
            PlayerPrefs.SetFloat("swplaytime", guiController.ptime);
        } 
        else if (guiController.scoreHit > PlayerPrefs.GetInt("refuelscore", 0) && guiController.newmode == true)
        {
            PlayerPrefs.SetInt("refuelscore", guiController.scoreHit);
            PlayerPrefs.SetFloat("rfplaytime", guiController.ptime);
        }
        else if (guiController.scoreHit > PlayerPrefs.GetInt("sharpscore", 0) && guiController.sharpmode == true)
        {
            PlayerPrefs.SetInt("sharpscore", guiController.scoreHit);
            PlayerPrefs.SetFloat("ssplaytime", guiController.ptime);
        }
        else if (guiController.scoreHit > PlayerPrefs.GetInt("fastscore", 0) && guiController.speedmode == true)
        {
            PlayerPrefs.SetInt("fastscore", guiController.scoreHit);
            PlayerPrefs.SetFloat("ffplaytime", guiController.ptime);
        }
        else if (guiController.scoreHit > PlayerPrefs.GetInt("classicscore", 0) && guiController.classicmode == true)
        {
            PlayerPrefs.SetInt("classicscore", guiController.scoreHit);
            PlayerPrefs.SetFloat("ccplaytime", guiController.ptime);
        }
    }
}
