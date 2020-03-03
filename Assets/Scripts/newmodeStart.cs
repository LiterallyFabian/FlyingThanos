using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class newmodeStart: MonoBehaviour
{
    public Texture OnMouseOverTexture;
    public Texture OnMouseLeaveTexture;
    private GameObject TimerObj;
    public static Text TimerTextComp;




    void Start()
    {
        TimerObj = GameObject.Find("Timer");
        TimerTextComp = TimerObj.GetComponent<Text>();
        guiController.newmode = false;
        backgroundMovement.backgroundSpeedBack = 0.02f;
        backgroundMovement.backgroundSpeedFront = 0.32f;
        backgroundMovement.backgroundSpeedMiddle = 0.23f;
    }

    void OnMouseOver()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseOverTexture;
        muteAudio.vbucktext.text = ".8s";
        muteAudio.lmaotext.text = ".4s";
        muteAudio.burgertext.text = ".2s";
        muteAudio.shurikentext.text = "-5s";
        muteAudio.modedesctext.text = "REFUEL\nGain fuel by collecting items";
        TimerTextComp.text = "time left: 10";


    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseLeaveTexture;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(1);
        guiController.newmode = true;
    }




}
