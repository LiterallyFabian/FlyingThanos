using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class speedStart : MonoBehaviour 
{
	public Texture OnMouseOverTexture;
	public Texture OnMouseLeaveTexture;
    private GameObject TimerObj;
    public static Text TimerTextComp;





    void Start () 
	{
        TimerObj = GameObject.Find("Timer");
        TimerTextComp = TimerObj.GetComponent<Text>();
        guiController.speedmode = false;
		backgroundMovement.backgroundSpeedBack = 0.02f;
        backgroundMovement.backgroundSpeedFront = 0.32f;
        backgroundMovement.backgroundSpeedMiddle = 0.23f;
	}
	
	void OnMouseOver()
	{
		GetComponent<Renderer>().material.mainTexture=OnMouseOverTexture;
		muteAudio.vbucktext.text = "15p";
		muteAudio.lmaotext.text = "8p";
		muteAudio.burgertext.text = "4p";
		muteAudio.shurikentext.text = "-3s";
        muteAudio.modedesctext.text = "FLYING FAST\nFaster flying, less time, more points";
        TimerTextComp.text = "time left: 40";


    }
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.mainTexture=OnMouseLeaveTexture;
	}
	
	void OnMouseDown()
	{
        SceneManager.LoadScene (1);
		guiController.speedmode = true;
	}

	


}
