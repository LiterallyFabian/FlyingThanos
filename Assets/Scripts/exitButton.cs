using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;


public class exitButton : MonoBehaviour {

    public Texture OnMouseOverTexture;
    public Texture OnMouseLeaveTexture;



    void Start()
    {

    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseOverTexture;
    }
    void OnMouseOver()
    {
        GetComponent<Renderer>().material.mainTexture = OnMouseLeaveTexture;
    }

    void OnMouseDown()
    {
        DiscordRpc.Shutdown();
        Application.Quit();
    }



    void Update()
    {

    }
}