using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

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
        Debug.LogError("back");
        yield return new WaitForSeconds(delay/1000+3.2f);
        SceneManager.LoadScene(0);
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
        Debug.Log($"Song picked: {maps[selectedmap]}\nRelated audio: {songs[selectedmap]}" );
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
            Debug.Log("hitsound: " + hitsound);
            int item = rnd.Next(4);

            if (i == AllFruitsArray.Length-1) StartCoroutine(goback(delay)); 

            if (data.Length > 7) //slider
            {
                int repeats = Convert.ToInt32(data[6]);
                StartCoroutine(spawn(pos, delay, true, 1, item));


                int diff = rnd.Next(5, 20);
                if (rnd.Next(1) == 1) diff = diff * -1;


                int sliderlength = Mathf.FloorToInt(float.Parse(data[7])); //slider length 
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
}
