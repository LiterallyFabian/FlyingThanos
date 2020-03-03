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
        gameObject.transform.Translate(Vector3.right * -Speed * Time.deltaTime);
        if (transform.position.x < -10.5)
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
}
