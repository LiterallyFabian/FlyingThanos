using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class osustart : MonoBehaviour
{
    public Texture OnMouseOverTexture;
    public Texture OnMouseLeaveTexture;
    private GameObject TimerObj;
    public static Text TimerTextComp;






    void Start()
    {
        TimerObj = GameObject.Find("Timer");
        TimerTextComp = TimerObj.GetComponent<Text>();
        guiController.speedmode = false;
        backgroundMovement.backgroundSpeedBack = 0.02f;
        backgroundMovement.backgroundSpeedFront = 0.32f;
        backgroundMovement.backgroundSpeedMiddle = 0.23f;
        guiController.sharpmode = false;
    }

    void OnMouseOver()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseOverTexture;
        muteAudio.vbucktext.text = "7p";
        muteAudio.lmaotext.text = "4p";
        muteAudio.burgertext.text = "3p";
        muteAudio.shurikentext.text = "-1hp";
        muteAudio.modedesctext.text = "thanos!catch\nCatch the fruits, don't miss too many!";
        TimerTextComp.text = "No time limit";

    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseLeaveTexture;
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(6);
        guiController.osu = true;
    }




}
