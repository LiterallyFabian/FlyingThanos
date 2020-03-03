using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Sitter på audiobutton i start & gameover, hanterar ljudet

public class muteAudio : MonoBehaviour
{
    public Texture nomute;
    public Texture mute;
    public static GameObject vbuckobjtext;
    public static GameObject lmaoobjtext;
    public static GameObject shurikenobjtext;
    public static GameObject burgerobjtext;
    public static GameObject modedescobjbtext;


    public static Text modedesctext;
    public static Text vbucktext;
    public static Text shurikentext;
    public static Text burgertext;
    public static Text lmaotext;

    void OnMouseDown()
    {
        //om ljudet när man trycker på ikonen är på ska det stängas av
        if (AudioListener.volume == 1f)
        {
            GetComponent<Renderer>().material.mainTexture = mute;
            AudioListener.volume = 0f;
        }
        else
        //annars är ljudet redan avstängt, och då ska det sättas på
        {
            GetComponent<Renderer>().material.mainTexture = nomute;
            AudioListener.volume = 1f;
        }
    }

    void Update()
    {    //Kollar alltid volymen och sätter rätt ikon
        if (AudioListener.volume == 0f)
        {
            GetComponent<Renderer>().material.mainTexture = mute;
        }
        else
        {
            GetComponent<Renderer>().material.mainTexture = nomute;
        }
                //find text obj
		vbuckobjtext = GameObject.Find ("vbucktext");
		lmaoobjtext = GameObject.Find ("lmaotext");
		shurikenobjtext = GameObject.Find("shurikentext");
		burgerobjtext = GameObject.Find("burgertext");
        modedescobjbtext = GameObject.Find("modeinfo");
        //define text obj
      modedesctext = modedescobjbtext.GetComponent<Text>();
	  vbucktext = vbuckobjtext.GetComponent<Text> ();
	  lmaotext = lmaoobjtext.GetComponent<Text> ();
	  burgertext = burgerobjtext.GetComponent<Text> ();
	  shurikentext = shurikenobjtext.GetComponent<Text> ();
    }
}
