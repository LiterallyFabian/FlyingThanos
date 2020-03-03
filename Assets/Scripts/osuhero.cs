using UnityEngine;
using System.Collections;

public class osuhero : MonoBehaviour
{
    public static float verticalSpeed = 130.0f;
    public static float horizontalSpeed = 90.0f;
    private float yDir;
    public static float rotationSpeed = 150.0f;
    public static float rotationup = 30f;
    public static float rotationdown = -30;

    //Om flyingHero hamnar utanför skärmen!
    public static float delay;

    void Start()
    {
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        //Input.GetAxis("Vertical") ger float-värden mellan 1 till -1 beroende på om piltangenter upp eller nedåt hålls ned!
        yDir = Input.GetAxis("Vertical") * verticalSpeed;
        //Ger fart åt objektets rigidbody. Vector3.up är samma som Vector3(0, 1, 0)
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * yDir);

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
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, newRotation1, 0.1f);
            PlayerPrefs.SetInt("ups", PlayerPrefs.GetInt("ups", 0) + 1);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Quaternion newRotation1 = Quaternion.AngleAxis(rotationdown, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, newRotation1, 0.1f);
            PlayerPrefs.SetInt("downs", PlayerPrefs.GetInt("downs", 0) + 1);
        }
        else
        {
            Quaternion newRotation = Quaternion.AngleAxis(0, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, newRotation, 0.1f);
            PlayerPrefs.SetInt("stay", PlayerPrefs.GetInt("stay", 0) + 1);
        }
        if(gameObject.transform.position.y < -4.9)
        {
            gameObject.transform.position = new Vector3(-7f, -4.9f, 1f);
        }
        if (gameObject.transform.position.y > 4.9)
        {
            gameObject.transform.position = new Vector3(-7f, 4.9f, 1f);
        }
    }
}
