using UnityEngine;
using System.Collections;

public class flyingHitObjectsMovement : MonoBehaviour 
{
    public static int Speed =10;
    public Sprite glitch;
    public Sprite virus;

    void Start () 
	{
        PlayerPrefs.SetInt("spawns", PlayerPrefs.GetInt("spawns", 0) + 1);
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * -Speed * Time.deltaTime);

        if(gameObject.tag == "virus" && this.transform.position.x < 1.8)
        {
            this.GetComponent<SpriteRenderer>().sprite = glitch;
        }
        if (gameObject.tag == "virus" && this.transform.position.x < -0.5)
        {
            this.GetComponent<SpriteRenderer>().sprite = virus;
        }
    }
}
