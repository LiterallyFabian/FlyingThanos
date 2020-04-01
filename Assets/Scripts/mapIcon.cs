using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapIcon : MonoBehaviour
{
    void Update()
    {
        if(PlayerPrefs.GetInt("skin", 0) != 4)
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"{PlayerPrefs.GetInt("map", 0)}icon");
        else
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"snowicon");
    }
}
