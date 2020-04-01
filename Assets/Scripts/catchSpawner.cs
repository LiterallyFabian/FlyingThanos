using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class catchSpawner : MonoBehaviour
{
    public GameObject item;
    public GameObject smallitem;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public static double osuscore;
    public static double osumaxscore;
    public static double osumiss;
    private GameObject[] items = new GameObject[4];

    // Start is called before the first frame update
    void Start()

    {
        items[0] = item;
        items[1] = item2;
        items[2] = item3;
        items[3] = item4;

        osuscore = 0;
        osumiss = 0;
        osumaxscore = 0;
        AddFruits();
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
        
        if (type)
        {
            yield return new WaitForSeconds(wait / 1000f - 0.85f); //högre = snabbare
            Instantiate(items[item], new Vector3(9.5f, (float)(2.9 / 160 * x - 3.5f), hitsound), Quaternion.identity); //spawnar item på f(x), hitsound
        }

        else
        {
            yield return new WaitForSeconds(wait / 1000f - 0.80f);
            Instantiate(smallitem, new Vector3(9.5f, (float)(2.9 / 160 * x -3.5f), 65), Quaternion.identity);
        }
    }

    public void AddFruits()
    {
        string[] maps;
        string[] songs;
        string path = $"{Directory.GetCurrentDirectory()}\\songs\\";

        if (Application.isEditor)
            path = $"{Directory.GetCurrentDirectory()}\\Assets\\testsongs\\";

        maps = System.IO.Directory.GetFiles(path, "*.osu"); //load all the maps + audio
        songs = System.IO.Directory.GetFiles(path, "*.ogg");
        System.Random rnd = new System.Random();
        int selectedmap = rnd.Next(maps.Length);

        string[] song = File.ReadAllLines(maps[selectedmap]);
        bool foundobjects = false;

        List<string> AllFruitLines = new List<string>(); //lista  med alla lines under [HitObjects]
        for (int i = 0; i < song.Length; i++)
        {
            if (!foundobjects)
            {
                if (song[i].Contains("AudioLeadIn")) //sets leadin (how long the game should wait before playing)
                {
                    string[] lead = song[i].Split(':');
                    StartCoroutine(LoadAudio(Convert.ToInt32(lead[1]), songs[selectedmap]));
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
            if (data.Length > 7) //slider
            {
                StartCoroutine(spawn(pos, delay, true, 1, item));

                int diff = rnd.Next(-40, 40);


                int sliderlength = Mathf.FloorToInt(float.Parse(data[7])); //slider length 
                int size = Mathf.RoundToInt(sliderlength / 34);
                for (int loop = 0; loop < size; loop++)
                {
                    StartCoroutine(spawn(pos +  diff * loop+1, loop*40 + delay, false, hitsound, item)); //spawn small item
                }
                
                StartCoroutine(spawn(pos + diff*size+1, delay + (size+1)*40, true, 65, item)); //65 = no hitsound
            }
            else //large item
              StartCoroutine(spawn(pos, delay, true, hitsound,item)); //spawn large item
        }
    }
}
