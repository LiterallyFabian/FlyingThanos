using UnityEngine;
using System.Collections;

public class backgroundMovement : MonoBehaviour 
{
	public GameObject backgroundFront;
	public GameObject backgroundMiddle;
	public GameObject backgroundBack;

	public static float backgroundSpeedFront = 0.4f;
	public static float backgroundSpeedMiddle = 0.3f;
	public static float backgroundSpeedBack = 0.2f;

	void Start ()
	{
		
	}

	void Update ()
	{
		backgroundFront.GetComponent<Renderer>().material.mainTextureOffset= new Vector2(Time.time*backgroundSpeedFront-0.1f, 0);
		backgroundBack.GetComponent<Renderer>().material.mainTextureOffset= new Vector2(Time.time*backgroundSpeedBack-0.1f, 0);
		backgroundMiddle.GetComponent<Renderer>().material.mainTextureOffset= new Vector2(Time.time*backgroundSpeedMiddle-0.1f, 0);
	}
} 
