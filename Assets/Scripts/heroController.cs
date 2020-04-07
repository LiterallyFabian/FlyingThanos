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

    //Om flyingHero hamnar utanför skärmen!
    private float maxPositionY;
    private float minPositionY;
    private float maxPositionX;
    private float minPositionX;
    public static float delay;

    private bool lookright = true;

    void Start () 
	{
		//Högst upp på skärmen. 
		maxPositionY=(Camera.main.orthographicSize);
		//Längst ned på skärmen
		minPositionY=-(Camera.main.orthographicSize+0.8f);
        Time.timeScale = 1;
        maxPositionX = 10;
        minPositionX = -10;
    }

	void FixedUpdate () 
	{
		//Input.GetAxis("Vertical") ger float-värden mellan 1 till -1 beroende på om piltangenter upp eller nedåt hålls ned!
		yDir = Input.GetAxis("Vertical")*verticalSpeed;
		//Ger fart åt objektets rigidbody. Vector3.up är samma som Vector3(0, 1, 0)
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

            //När upp eller nedtangent är intryckt!
            if (Input.GetKey(KeyCode.UpArrow))
		{
            //Nytt rotationsvärde, 45 grader, i z-axeln!
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
		
		//Om flyingHero är högre upp än skärm
		if(gameObject.transform.position.y>maxPositionY)
		{
			gameObject.transform.position=new Vector3(gameObject.transform.position.x, minPositionY, 
			                                          gameObject.transform.position.z);
		}
		//Om flyingHero är längre ned än skärm
		if(gameObject.transform.position.y<minPositionY)
		{
			gameObject.transform.position=new Vector3(gameObject.transform.position.x, maxPositionY, 
			                                          gameObject.transform.position.z);
		}
        //Om flyingHero är högre upp än skärm
        if (gameObject.transform.position.x > maxPositionX)
        {
            gameObject.transform.position = new Vector3(minPositionX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        //Om flyingHero är längre ned än skärm
        if (gameObject.transform.position.x < minPositionX)
        {
            gameObject.transform.position = new Vector3(maxPositionX, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }


}
