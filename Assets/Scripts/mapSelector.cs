using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mapSelector : MonoBehaviour

{
    public Texture OnMouseOverTexture;
    public Texture OnMouseLeaveTexture;
    public Texture grayout;
    public bool hover;

    public static int cars = 5;
    public static int maps = 2;

    //4 = santa
    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("skin", 0) == 4 && this.gameObject.CompareTag("maparrow"))
        {
            GetComponent<Renderer>().material.mainTexture = grayout;
        }
        else if (!hover)
            GetComponent<Renderer>().material.mainTexture = OnMouseLeaveTexture;
        else
            GetComponent<Renderer>().material.mainTexture = OnMouseOverTexture;
    }
    void OnMouseDown()
    {
        //kolla längd maps/cars
        //adda +1
        //om max längd, set 0
        if(this.gameObject.CompareTag("cararrow") && transform.position.z == -2)
        PlayerPrefs.SetInt("skin", PlayerPrefs.GetInt("skin", 0) + 1); //öka 1

        else if (this.gameObject.CompareTag("cararrow") && transform.position.z == -1)
            PlayerPrefs.SetInt("skin", PlayerPrefs.GetInt("skin", 0) - 1); //minska 1

        if (PlayerPrefs.GetInt("skin", 0) < 0)
            PlayerPrefs.SetInt("skin", cars); //återställ om för liten

        else if (PlayerPrefs.GetInt("skin", 0) > cars)
            PlayerPrefs.SetInt("skin", 0); //återställ om för stor

        if (this.gameObject.CompareTag("maparrow") && transform.position.z == -2)
            PlayerPrefs.SetInt("map", PlayerPrefs.GetInt("map", 0) + 1); //öka 1

        else if (this.gameObject.CompareTag("maparrow") && transform.position.z == -1)
            PlayerPrefs.SetInt("map", PlayerPrefs.GetInt("map", 0) - 1); //minska 1
        if(PlayerPrefs.GetInt("map", 0) < 0)
            PlayerPrefs.SetInt("map", maps); //återställ om för liten

        else if (PlayerPrefs.GetInt("map", 0) > maps)
            PlayerPrefs.SetInt("map", 0); //återställ om för stor
    }
    void OnMouseOver()
    {
        hover = true;
    }
    void OnMouseExit()
    {
        hover = false;
    }
}
