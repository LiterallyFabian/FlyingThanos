using UnityEngine;
using System.Collections;

public class osuitem : MonoBehaviour
{
    public static int Speed = 15;
    private bool notcollected = true;
    private AudioClip whistle;
    private AudioClip finish;
    private AudioClip clap;
    private AudioClip normal;
    private int sound = 65;


    void Start()
    {
        sound = (int)transform.position.z;
        whistle = (AudioClip)Resources.Load("sounds/hitwhistle2", typeof(AudioClip));
        finish = (AudioClip)Resources.Load("sounds/hitfinish4", typeof(AudioClip));
        clap = (AudioClip)Resources.Load("sounds/hitclap8", typeof(AudioClip));
        normal = (AudioClip)Resources.Load("sounds/hitnormal0", typeof(AudioClip));
        PlayerPrefs.SetInt("spawns", PlayerPrefs.GetInt("spawns", 0) + 1);
        if (catchSpawner.party && GetComponent<Animator>() != null)
            GetComponent<Animator>().Play("fruitSpin");
    }

    void Update() 
    {
        if(notcollected) gameObject.transform.Translate(Vector3.right * -Speed * Time.deltaTime); //move obj

        if (transform.position.x < -10.5 && notcollected) //miss
        {
            if (gameObject.tag == "large") 
            {
                catchSpawner.osumaxscore += catchcollision.largescore;
                catchSpawner.osumiss += catchcollision.largescore;
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumax", 0) + catchcollision.largescore);
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumiss", 0) + catchcollision.largescore);
                PlayerPrefs.SetInt("osutotalmiss", PlayerPrefs.GetInt("osutotalmiss", 0) + catchcollision.largescore);
            }
            else if(gameObject.tag == "small")
            {
                catchSpawner.osumaxscore += catchcollision.smallscore;
                catchSpawner.osumiss += catchcollision.smallscore;
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumax", 0) + catchcollision.smallscore);
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumiss", 0) + catchcollision.smallscore);
                PlayerPrefs.SetInt("osutotalmiss", PlayerPrefs.GetInt("osutotalmiss", 0) + catchcollision.smallscore);
            }
            Destroy(this.gameObject);
        }
        if (catchSpawner.party)
            GetComponent<Renderer>().material.SetColor("_Color", HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.time * 0.4f, 1), 0.2f, 1)));
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (sound != 65)
        {
            if (sound == 2) //whistle
                GetComponent<AudioSource>().clip = whistle;
            else if (sound == 4) //finish
                GetComponent<AudioSource>().clip = finish;
            else if (sound == 8) //clap
                GetComponent<AudioSource>().clip = clap;
            else
                GetComponent<AudioSource>().clip = normal;
            GetComponent<AudioSource>().Play();
            GameObject.Find("/Canvas/acc").GetComponent<Animator>().Play("getbig", -1, 0);
        }
        notcollected = false; //collected
        transform.position = new Vector3(-6.5f, transform.position.y, -1);
        if (catchSpawner.party && GetComponent<ParticleSystem>() != null) GetComponent<ParticleSystem>().Play();
        Destroy(GetComponent<BoxCollider2D>());
        GetComponent<SpriteRenderer>().color = Color.clear;
        Destroy(this.gameObject, 3);
    }
}
