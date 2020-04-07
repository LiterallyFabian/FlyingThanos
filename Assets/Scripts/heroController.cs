using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class heroController : MonoBehaviour 
{
    public static float verticalSpeed = 130.0f;
    public static float horizontalSpeed = 90.0f;
    private float yDir;
    public static float rotationSpeed = 150.0f;
    public static float rotationup = 45f;
    public static float rotationdown = -45;

    //Om flyingHero hamnar utanf�r sk�rmen!
    private float maxPositionY;
    private float minPositionY;
    private float maxPositionX;
    private float minPositionX;
    public static float delay;

    private bool lookright = true;

    void Start () 
	{
		//H�gst upp p� sk�rmen. 
		maxPositionY=(Camera.main.orthographicSize);
		//L�ngst ned p� sk�rmen
		minPositionY=-(Camera.main.orthographicSize+0.8f);
        Time.timeScale = 1;
        maxPositionX = 10;
        minPositionX = -10;
    }

	void FixedUpdate () 
	{
		//Input.GetAxis("Vertical") ger float-v�rden mellan 1 till -1 beroende p� om piltangenter upp eller ned�t h�lls ned!
		yDir = Input.GetAxis("Vertical")*verticalSpeed;
		//Ger fart �t objektets rigidbody. Vector3.up �r samma som Vector3(0, 1, 0)
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up*yDir);
        if (guiController.pvpmode == true || SceneManager.GetActiveScene().name == "start")
        {
            yDir = Input.GetAxis("Horizontal") * horizontalSpeed;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * yDir);
        }

    }
	void Update()
	{
        if (Input.GetKey(KeyCode.LeftShift))
        {
            verticalSpeed = 250f;
        }
        else
        {
            verticalSpeed = 130f;
        }

            //N�r upp eller nedtangent �r intryckt!
            if (Input.GetKey(KeyCode.UpArrow))
		{
            //Nytt rotationsv�rde, 45 grader, i z-axeln!
            Quaternion newRotation1 = Quaternion.AngleAxis(rotationup, Vector3.forward);
            gameObject.transform.rotation= Quaternion.Slerp(gameObject.transform.rotation, newRotation1, 0.1f);
            PlayerPrefs.SetInt("ups", PlayerPrefs.GetInt("ups", 0) + 1);
        }
		else if(Input.GetKey(KeyCode.DownArrow))
		{
            Quaternion newRotation1 = Quaternion.AngleAxis(rotationdown, Vector3.forward);
            gameObject.transform.rotation= Quaternion.Slerp(gameObject.transform.rotation, newRotation1, 0.1f);
            PlayerPrefs.SetInt("downs", PlayerPrefs.GetInt("downs", 0) + 1);
        }
		else
		{
			Quaternion newRotation = Quaternion.AngleAxis(0, Vector3.forward);
			gameObject.transform.rotation= Quaternion.Slerp(gameObject.transform.rotation, newRotation, 0.1f);
            PlayerPrefs.SetInt("stay", PlayerPrefs.GetInt("stay", 0) + 1);
        }
		
		//Om flyingHero �r h�gre upp �n sk�rm
		if(gameObject.transform.position.y>maxPositionY)
		{
			gameObject.transform.position=new Vector3(gameObject.transform.position.x, minPositionY, 
			                                          gameObject.transform.position.z);
		}
		//Om flyingHero �r l�ngre ned �n sk�rm
		if(gameObject.transform.position.y<minPositionY)
		{
			gameObject.transform.position=new Vector3(gameObject.transform.position.x, maxPositionY, 
			                                          gameObject.transform.position.z);
		}
        //Om flyingHero �r h�gre upp �n sk�rm
        if (gameObject.transform.position.x > maxPositionX)
        {
            gameObject.transform.position = new Vector3(minPositionX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        //Om flyingHero �r l�ngre ned �n sk�rm
        if (gameObject.transform.position.x < minPositionX)
        {
            gameObject.transform.position = new Vector3(maxPositionX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }


}
