using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using UnityEngine.SceneManagement;


public class openSkins : MonoBehaviour
{

    public Texture OnMouseOverTexture;
    public Texture OnMouseLeaveTexture;



    void Start()
    {
        Cursor.visible = true;
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
        SceneManager.LoadScene(3);
    }



    void Update()
    {
        
    }

}