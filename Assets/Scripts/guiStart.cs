using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Text;

public class guiStart : MonoBehaviour 
{
    private string Pcommand;

    [DllImport("winmm.dll")]
    private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, int bla);

    /// Stops currently playing audio file
    

    private GameObject ScoreObj;
	private GameObject TimerObj;
	private Text TimerTextComp;
	private Text ScoreTextComp;
	private int scoreHit;



	void Awake () 
	{
        Pcommand = "close MediaFile";
        mciSendString(Pcommand, null, 0, 0);
        ScoreObj = GameObject.Find ("Score");
		TimerObj = GameObject.Find ("Timer");
		TimerTextComp = TimerObj.GetComponent<Text> ();
		ScoreTextComp = ScoreObj.GetComponent<Text> ();

        TimerTextComp.text = ("Time left: " + guiController.playTime.ToString()); 
		ScoreTextComp.text = "Score: " + guiController.scoreHit.ToString();
	}

}
