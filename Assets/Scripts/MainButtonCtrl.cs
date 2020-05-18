using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtonCtrl : MonoBehaviour
{
    private Text TimerText;
    private Text VbuckText;
    private Text SlurpText;
    private Text BurgerText;
    private Text ShurikenText;
    private Text InfoText;
    void Start()
    {
        TimerText = GameObject.Find("Timer").GetComponent<Text>();
        VbuckText = GameObject.Find("vbucktext").GetComponent<Text>();
        SlurpText = GameObject.Find("lmaotext").GetComponent<Text>();
        ShurikenText = GameObject.Find("shurikentext").GetComponent<Text>();
        BurgerText = GameObject.Find("burgertext").GetComponent<Text>();
        InfoText = GameObject.Find("modeinfo").GetComponent<Text>();

        guiController.classicmode = false;
        guiController.speedmode = false;
        guiController.newmode = false;
        guiController.sharpmode = false;
        guiController.pvpmode = false;
        guiController.osu = false; 
        backgroundMovement.backgroundSpeedBack = 0.02f;
        backgroundMovement.backgroundSpeedFront = 0.32f;
        backgroundMovement.backgroundSpeedMiddle = 0.23f;
    }

    public void StartSwarm()
    {
        guiController.swarmmode = true;
        SceneManager.LoadScene(1);
    }
    public void HoverSwarm()
    {
        VbuckText.text = "12p";
        SlurpText.text = "7p";
        BurgerText.text = "5p";
        ShurikenText.text = "-4s";
        InfoText.text = "SWARM\nMore and faster shurikens. Good luck!";
        TimerText.text = "time left: 60";
    }
    
    public void StartNormal()
    {
        SceneManager.LoadScene(1);
        guiController.classicmode = true;
    }
    public void HoverNormal()
    {
        
        VbuckText.text = "10p";
        SlurpText.text = "5p";
        BurgerText.text = "3p";
        ShurikenText.text = "-5s";
        InfoText.text = "CLASSIC\nNormal speed & points. What did you expect?";
        TimerText.text = "time left: 60";
    }
    public void StartRefuel()
    {
        SceneManager.LoadScene(1);
        guiController.newmode = true;
    }
    public void HoverRefuel()
    {
        VbuckText.text = ".8s";
        SlurpText.text = ".4s";
        BurgerText.text = ".2s";
        ShurikenText.text = "-5s";
        InfoText.text = "REFUEL\nGain fuel by collecting items";
        TimerText.text = "time left: 10";
    }
    public void StartPvp()
    {
        guiController.pvpmode = true;
        SceneManager.LoadScene(4);
    }
    public void HoverPvp()
    {
        VbuckText.text = "10p";
        SlurpText.text = "5p";
        BurgerText.text = "3p";
        ShurikenText.text = "-5s";
        InfoText.text = "Duel\n60 seconds each, horizontal moving enabled. Good luck!";
        TimerText.text = "time left: 60";
    }
    public void StartSharp()
    {
        SceneManager.LoadScene(1);
        guiController.sharpmode = true;
    }
    public void HoverSharp()
    {
        VbuckText.text = "7p";
        SlurpText.text = "4p";
        BurgerText.text = "3p";
        ShurikenText.text = "-1hp";
        InfoText.text = "SHARP SHURIKENS\nLess points, sharper shurikens, no time limit";
        TimerText.text = "No time limit";
    }
    public void StartOsu()
    {
        SceneManager.LoadScene(6);
        guiController.osu = true;
    }
    public void HoverOsu()
    {
        VbuckText.text = "??";
        SlurpText.text = "4p";
        BurgerText.text = "3p";
        ShurikenText.text = "-1hp";
        InfoText.text = "thanos!catch\nCatch the fruits, don't miss too many!";
        TimerText.text = "No time limit";
    }
    public void StartSpeed()
    {
        SceneManager.LoadScene(1);
        guiController.speedmode = true;
    }
    public void HoverSpeed()
    {
        VbuckText.text = "15p";
        SlurpText.text = "8p";
        BurgerText.text = "4p";
        ShurikenText.text = "-3s";
        InfoText.text = "FLYING FAST\nFaster flying, less time, more points";
        TimerText.text = "time left: 40";
    }
    public void QuitGame()
    {
        DiscordRpc.Shutdown();
        Application.Quit();
    }
    public void OpenScene(int id)
    {
        SceneManager.LoadScene(id);
    }

}
