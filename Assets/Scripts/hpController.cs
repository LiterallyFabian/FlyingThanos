using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpController : MonoBehaviour {
	public Texture onehp;
	public Texture twohp;
	public Texture threehp;
	public Texture fourhp;
	public GameObject gears;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(guiController.lifes == 0){
            GetComponent<Renderer>().enabled = false;
            }
        else{
            GetComponent<Renderer>().enabled = true;
}
		if (guiController.lifes == 4){
		GetComponent<Renderer>().material.mainTexture=fourhp;
		}
			if (guiController.lifes == 3){
		GetComponent<Renderer>().material.mainTexture=threehp;
	}
			if (guiController.lifes == 2){
		GetComponent<Renderer>().material.mainTexture=twohp;
	}
			if (guiController.lifes == 1){
		GetComponent<Renderer>().material.mainTexture=onehp;
		
	}

}
}