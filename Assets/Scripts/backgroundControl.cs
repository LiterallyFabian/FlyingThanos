using UnityEngine;


public class backgroundControl : MonoBehaviour
{
    public GameObject sky;
    public GameObject cloud;
    public GameObject back;
    public GameObject front;


    void Start()
    {
        if (PlayerPrefs.GetInt("skin", 0) != 4)
        {
            sky.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/{PlayerPrefs.GetInt("map", 0)}sky") as Texture;
            front.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/{PlayerPrefs.GetInt("map", 0)}front") as Texture;
            cloud.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/{PlayerPrefs.GetInt("map", 0)}cloud") as Texture;
            back.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/{PlayerPrefs.GetInt("map", 0)}back") as Texture;
        }
        else
        {
            sky.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/snowsky") as Texture;
            front.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/snowfront") as Texture;
            cloud.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/snowcloud") as Texture;
            back.GetComponent<Renderer>().material.mainTexture = Resources.Load($"maps/snowback") as Texture;
        }
    }
}
