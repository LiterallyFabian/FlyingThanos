using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Globalization;
using UnityEngine.UI;

public class catchSpawner : MonoBehaviour
{
    public GameObject item;
    public GameObject smallitem;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public Animator FadeEffect;
    public GameObject background;
    public GameObject hero;
    public static double osuscore;
    public static double osumaxscore;
    public static double osumiss;
    private GameObject[] items = new GameObject[4];
    public static string beatmap;
    private bool effectcooldown = false;
    NumberFormatInfo lang = new NumberFormatInfo();
    public static string songPath;
    public static bool party = false;

    // Start is called before the first frame update
    void Start()

    {
        lang.NumberDecimalSeparator = ".";
        items[0] = item;
        items[1] = item2;
        items[2] = item3;
        items[3] = item4;

        party = false;
        osuscore = 0;
        osumiss = 0;
        osumaxscore = 0;
        AddFruits();
        AddEffects();
    }
    private void Update()
    {
        background.GetComponent<Renderer>().material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.1f, 1), 0.4f, 1)));
        if (Input.GetKeyDown(KeyCode.K))
        {
            ToggleParty(true);
            GameObject.Find("confettiR").GetComponent<ParticleSystem>().Play();
            GameObject.Find("confettiL").GetComponent<ParticleSystem>().Play();
        }
    }

    IEnumerator LoadAudio(int leadin, string songpath)
    {
        WWW www = new WWW($"file://{songpath}");
        yield return www;
        GetComponent<AudioSource>().clip = www.GetAudioClip(false, true);
        yield return new WaitForSeconds(leadin/1000f);
        GetComponent<AudioSource>().Play();
    }
    IEnumerator spawn(int x, int wait, bool type, int hitsound, int item)
    {
        if (type) //large
        {
            yield return new WaitForSeconds(wait / 1000f - 0.85f); //högre = snabbare
            Instantiate(items[item], new Vector3(9.5f, (float)(2.9 / 160 * x - 4.8f), hitsound), Quaternion.identity); //spawnar item på f(x), hitsound
        }

        else //small
        {
            yield return new WaitForSeconds(wait / 1000f - 0.80f);
            Instantiate(smallitem, new Vector3(9.5f, (float)(2.9 / 160 * x - 4.8f), 65), Quaternion.identity);
        }
    }
    IEnumerator goback(int delay)
    {
        yield return new WaitForSeconds(delay/1000+3.2f);
        SceneManager.LoadScene(0);
    }
    public void AddFruits()
    {
        System.Random rnd = new System.Random();

        string selectedSong = $"{songPath}/{beatmap}.ogg";
        string selectedMap = $"{songPath}/{beatmap}.osu";
        Debug.Log($"Song picked: {selectedMap}\nRelated audio: {selectedSong}" );
        string[] song = File.ReadAllLines(selectedMap);
        bool foundobjects = false;

        List<string> AllFruitLines = new List<string>(); //lista  med alla lines under [HitObjects]
        for (int i = 0; i < song.Length; i++)
        {
            if (!foundobjects)
            {
                if (song[i].Contains("AudioLeadIn")) //sets leadin (how long the game should wait before playing)
                {
                    string[] lead = song[i].Split(':');
                    StartCoroutine(LoadAudio(Convert.ToInt32(lead[1]), selectedSong));
                }
                if (song[i] == "[HitObjects]") //found the correct section, now start adding everything
                    foundobjects = true;    
            }
            else
            {
                AllFruitLines.Add(song[i]);
            }
        }
        string[] AllFruitsArray = AllFruitLines.ToArray();

        for (int i = 0; i < AllFruitsArray.Length; i++)
        {
            string[] data = AllFruitsArray[i].Split(',');

            int delay = Convert.ToInt32(data[2]);
            int pos = Convert.ToInt32(data[1]);
            int hitsound = Convert.ToInt32(data[3]);
            int item = rnd.Next(4);

            if (i == AllFruitsArray.Length-1) StartCoroutine(goback(delay)); 

            if (data.Length > 7) //slider
            {
                int repeats = Convert.ToInt32(data[6]);
                StartCoroutine(spawn(pos, delay, true, 1, item));


                int diff = rnd.Next(5, 20);
                if (rnd.Next(1) == 1) diff = diff * -1;


                int sliderlength = Mathf.FloorToInt((float)Convert.ToDouble(data[7], lang)); //slider length 
                int size = Mathf.RoundToInt(sliderlength / 19.5f) * repeats;
                int where = 0;
                bool dir = true;
                if (diff < 0) dir = false;  //false dir = negative

                for (int loop = 0; loop < size; loop++)
                {
                    int position = pos + (where*diff);
                    if (position > 500 || position < 20) //change direction if it will be too high up, or far down
                    {
                        position = pos + (where * diff);
                        dir = !dir; //toggle dir
                    }
                    if (dir) where++;
                    else where--;
                    StartCoroutine(spawn(position, loop * 40 + delay, false, 65, item)); //spawn small item

                    
                }

                StartCoroutine(spawn(pos + (where * diff), delay + (size + 1) * 40, true, hitsound, item)); //65 = no hitsound
            }
            else //large item
            { 
                StartCoroutine(spawn(pos, delay, true, hitsound, item)); //spawn large item
            }
        }
    }
    public void AddEffects()
    {
        string[] song = File.ReadAllLines($"{songPath}/{beatmap}.osu");
        bool foundobjects = false;
        bool done = false;
        List<string> AllEffectLines = new List<string>(); //lista  med alla lines under [TimingPoints]
        for (int i = 0; i < song.Length; i++)
        {
            if (!foundobjects)
            {
                if (song[i] == "[TimingPoints]") //found the correct section, now start adding everything
                    foundobjects = true;
            }
            else if (!done)
            {

                if (song[i] != "")
                {
                    AllEffectLines.Add(song[i]);
                }
                else done = true;
            }
        }
        foreach (string i in AllEffectLines)
        {
            if (i.Split(',')[7] == "1")
            {
                StartCoroutine(Effect(Convert.ToInt32(i.Split(',')[0])));
            }
            else 
            {
                StartCoroutine(RunEveryTimingPoint(Convert.ToInt32(i.Split(',')[0])));
            }
        }
    }
    private void ToggleParty(bool enable)
    {
        if (enable == party) return;
        else if (!enable)
        {
            party = false;
            background.GetComponent<Animator>().Play("backgroundHide");
        }
        else
        {
            party = true;
            background.GetComponent<Animator>().Play("backgroundShow");
        }

        Debug.Log($"Party mode {(enable ? "enabled" : "disabled")}");
    }
    IEnumerator Effect(int d)
    {
        yield return new WaitForSeconds(d / 1000);
        ToggleParty(true);
        FadeEffect.Play("fade", -1, 0);
        if (!effectcooldown)
        {
            GameObject.Find("confettiR").GetComponent<ParticleSystem>().Play();
            GameObject.Find("confettiL").GetComponent<ParticleSystem>().Play();
            effectcooldown = true;
            yield return new WaitForSeconds(5);
            effectcooldown = false;
        }
    }
    IEnumerator RunEveryTimingPoint(int d)
    {
        yield return new WaitForSeconds(d / 1000);
        ToggleParty(false);
        FadeEffect.Play("fade", -1, 0);
        Debug.Log("play");
    }
}
