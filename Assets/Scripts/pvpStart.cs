using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pvpStart : MonoBehaviour
{
    public Texture OnMouseOverTexture;
    public Texture OnMouseLeaveTexture;
    private GameObject TimerObj;
    public static Text TimerTextComp;




    void Start()
    {
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
        muteAudio.modedesctext.text = "Duel\n60 seconds each, horizontal moving enabled. Good luck!";
        TimerTextComp.text = "time left: 60";


    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseLeaveTexture;
    }

    void OnMouseDown()
    {
        guiController.pvpmode = true;
        SceneManager.LoadScene(4);
    }
}
