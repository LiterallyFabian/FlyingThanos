using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startSwarm : MonoBehaviour
{
    public Texture OnMouseOverTexture;
    public Texture OnMouseLeaveTexture;
    private GameObject TimerObj;
    public static Text TimerTextComp;




    void Start()
    {
        guiController.swarmmode = false;
        guiController.speedmode = false;
        guiController.newmode = false;
        guiController.sharpmode = false;
    }

    void OnMouseOver()
    {
        TimerObj = GameObject.Find("Timer");
        TimerTextComp = TimerObj.GetComponent<Text>();
        GetComponent<Renderer>().material.mainTexture = OnMouseOverTexture;
        muteAudio.vbucktext.text = "12p";
        muteAudio.lmaotext.text = "7p";
        muteAudio.burgertext.text = "5p";
        muteAudio.shurikentext.text = "-4s";
        muteAudio.modedesctext.text = "SWARM\nMore and faster shurikens. Good luck!";
        TimerTextComp.text = "time left: 60";


    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseLeaveTexture;
    }

    void OnMouseDown()
    {
        guiController.swarmmode = true;
        SceneManager.LoadScene(1);
    }




    void Update()
    {
    }
}
