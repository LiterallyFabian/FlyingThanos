using UnityEngine;
using System.Collections;

public class osuitem : MonoBehaviour
{
    public static int Speed = 15;


    void Start()
    {
        PlayerPrefs.SetInt("spawns", PlayerPrefs.GetInt("spawns", 0) + 1);
    }

    void Update() 
    {
        gameObject.transform.Translate(Vector3.right * -Speed * Time.deltaTime); //move obj

        if (transform.position.x < -10.5) //miss
        {
            if (gameObject.tag == "large") 
            {
                catchSpawner.osumaxscore += catchcollision.largescore;
                catchSpawner.osumiss += catchcollision.largescore;
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumax", 0) + catchcollision.largescore);
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumiss", 0) + catchcollision.largescore);
            }
            else
            {
                catchSpawner.osumaxscore += catchcollision.smallscore;
                catchSpawner.osumiss += catchcollision.smallscore;
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumax", 0) + catchcollision.smallscore);
                PlayerPrefs.SetInt("osucollects", PlayerPrefs.GetInt("osumiss", 0) + catchcollision.smallscore);

            }
            Destroy(this);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.transform.position.z != 65)
        {
            if (collider.gameObject.transform.position.z == 1) //whistle
                GetComponent<AudioSource>().clip = catchcollision.whistle;
            else if (collider.gameObject.transform.position.z == 2) //finish
                GetComponent<AudioSource>().clip = catchcollision.finish;
            else if (collider.gameObject.transform.position.z == 3) //clap
                GetComponent<AudioSource>().clip = catchcollision.clap;
            else if (collider.gameObject.transform.position.z == 3) //drumwhistle
                GetComponent<AudioSource>().clip = catchcollision.clap;
            else
                GetComponent<AudioSource>().clip = catchcollision.normal;
            GetComponent<AudioSource>().Play();
        }
        transform.position = new Vector3(100, 100); //teleportera iväg föremålet men gör så ljudet spelas
    }
}
