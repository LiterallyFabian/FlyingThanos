using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class discordToggle : MonoBehaviour
{

    public Texture discordenabled;
    public Texture discorddisabled;
    public static bool discordconnected = true;
    private GameObject statustext;
    public static Text statustextcomp;




    void Start()
    {
        Cursor.visible = true;
        statustext = GameObject.Find("discordstatus");
        statustextcomp = statustext.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(discordconnected == true)
        {
            GetComponent<Renderer>().material.mainTexture = discordenabled;
            statustextcomp.text = "Rich presence\nEnabled";
        } else if (discordconnected == false)
        {
            GetComponent<Renderer>().material.mainTexture = discorddisabled;
            statustextcomp.text = "Rich presence\nDisabled";
        }


    }
    void OnMouseDown()
    {
        if (discordconnected == true)
        {
            discordconnected = false;
        }
        else if (discordconnected == false)
        {
            discordconnected = true;
        }
    }
}

