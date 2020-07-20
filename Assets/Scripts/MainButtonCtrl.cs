using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
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

    //collectiables 
    public Sprite vb;
    public Sprite sl;
    public Sprite bu;
    public Sprite sh;
    public Sprite fr1;
    public Sprite fr2;
    public Sprite fr3;
    public Sprite fr4;

    List<string> maps;
    void Start()
    {
        catchSpawner.songPath = $"{Application.dataPath}/songs";
        if (Application.isEditor) catchSpawner.songPath = @"D:\Skrivbord\songs";

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
        maps = System.IO.Directory.GetFiles(catchSpawner.songPath, "*.osu").ToList();
        for (int i = 0; i < maps.Count; i++)
        {
            maps[i] = Path.GetFileName(maps[i]);
            maps[i] = maps[i].Replace(".osu", "");
        }
        GameObject.Find("Canvas/osu").GetComponent<Dropdown>().AddOptions(maps);
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
    public void GoToStart()
    {
        SceneManager.LoadScene(0);
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
    public void StartOsu(int n)
    {
        if (n == 1) catchSpawner.beatmap = maps[UnityEngine.Random.Range(0, maps.Count-1)];
        else catchSpawner.beatmap = maps[n-2];
        SceneManager.LoadScene(6);
        guiController.osu = true;
    }
    public void HoverOsu()
    {
        VbuckText.text = "10p";
        SlurpText.text = "10p";
        BurgerText.text = "10p";
        ShurikenText.text = "2p";
        InfoText.text = "thanos!catch\nCatch the fruits, don't miss too many!";
        TimerText.text = "Depends";
        GameObject.Find("/Canvas/objectinfo_panel/vbuck").GetComponent<Image>().sprite = fr1;
        GameObject.Find("/Canvas/objectinfo_panel/lmao").GetComponent<Image>().sprite = fr2;
        GameObject.Find("/Canvas/objectinfo_panel/burger").GetComponent<Image>().sprite = fr3;
        GameObject.Find("/Canvas/objectinfo_panel/Shuriken").GetComponent<Image>().sprite = fr4;
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
    public void ResetIcons()
    {
        GameObject.Find("/Canvas/objectinfo_panel/vbuck").GetComponent<Image>().sprite = vb;
        GameObject.Find("/Canvas/objectinfo_panel/lmao").GetComponent<Image>().sprite = sl;
        GameObject.Find("/Canvas/objectinfo_panel/burger").GetComponent<Image>().sprite = bu;
        GameObject.Find("/Canvas/objectinfo_panel/Shuriken").GetComponent<Image>().sprite = sh;
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
    public void OpenFolder(string path)
    {
        Process.Start("explorer.exe", $@"{Application.dataPath}/{path}/".Replace("/", "\\"));
    }
    public void OpenLink(string link)
    {
        Process.Start(link);
    }

}
