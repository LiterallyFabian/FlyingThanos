using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToStart : MonoBehaviour {

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

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("escape"))
            SceneManager.LoadScene(0);

    }
    void OnMouseDown()
    {
        SceneManager.LoadScene(0);
        guiController.playTime = 60;
    }
}

