using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startGame : MonoBehaviour 
{
	public Texture OnMouseOverTexture;
	public Texture OnMouseLeaveTexture;
    private GameObject TimerObj;
    public static Text TimerTextComp;




    void Start () 
	{
        guiController.classicmode = false;
        guiController.speedmode = false;
        guiController.newmode = false;
        guiController.sharpmode = false;
        guiController.pvpmode = false;
	}
	
	void OnMouseOver()
	{
        TimerObj = GameObject.Find("Timer");
        TimerTextComp = TimerObj.GetComponent<Text>();
        GetComponent<Renderer>().material.mainTexture = OnMouseOverTexture;
        muteAudio.vbucktext.text = "10p";
		muteAudio.lmaotext.text = "5p";
		muteAudio.burgertext.text = "3p";
		muteAudio.shurikentext.text = "-5s";
        muteAudio.modedesctext.text = "CLASSIC\nNormal speed & points. What did you expect?";
        TimerTextComp.text = "time left: 60";
		
		
	}
	void OnMouseExit()
	{
		GetComponent<Renderer>().material.mainTexture=OnMouseLeaveTexture;
	}
	
	void OnMouseDown()
	{
        SceneManager.LoadScene (1);
        guiController.classicmode = true;
	}

	

	

}
