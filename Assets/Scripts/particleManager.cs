using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleManager : MonoBehaviour {

    public GameObject SnowParticles; 


    void Start () {
        //Om man har valt julskinnet så aktiveras snön
        if (PlayerPrefs.GetInt("skin", 0 ) == 4)
        {
            SnowParticles.transform.position = new Vector3(4.1f, 6.56f, 0.8f);
        }
        else
        {
            SnowParticles.transform.position = new Vector3(-22.5f, 6.5f, 0.8f);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
