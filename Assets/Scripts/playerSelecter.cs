using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerSelecter : MonoBehaviour {
    public Sprite damage0;
    public Sprite damage1;
    public Sprite damage2;
    public Sprite damage3;
    public GameObject thanos;





    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"{PlayerPrefs.GetInt("skin", 0)}");


        if (guiController.lifes == 3 && guiController.sharpmode == true){
            thanos.GetComponent<SpriteRenderer>().sprite = damage0;
        }
            else if(guiController.lifes == 2 && guiController.sharpmode == true){
            thanos.GetComponent<SpriteRenderer>().sprite = damage2;
        }
            else if(guiController.lifes == 1 && guiController.sharpmode == true){
            thanos.GetComponent<SpriteRenderer>().sprite = damage3; 
        }

        if(guiController.lifes == 92) //random unreachable thing to load resources, idk? lol
        {
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("0");
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("1");
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("2");
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("3");
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("4");
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("5");
            this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("thanosjul");
        }

    }
    
}


