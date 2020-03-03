using UnityEngine;
using System.Collections;

public class pvpController : MonoBehaviour
{
    public static float verticalSpeed = 130.0f;
    public static float horizontalSpeed = 90.0f;
    private float yDir;
    public static float rotationSpeed = 150.0f;
    public static float rotationup = 45f;
    public static float rotationdown = -45;

    private float maxPositionY;
    private float minPositionY;
    private float maxPositionX;
    private float minPositionX;


    void Start()
    {

        maxPositionY = (Camera.main.orthographicSize);
        minPositionY = -(Camera.main.orthographicSize + 0.8f);
        Time.timeScale = 1;
        maxPositionX = 10;
        minPositionX = -10;
    }

    void FixedUpdate()
    {
        yDir = Input.GetAxis("VerticalPVP") * verticalSpeed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * yDir);


        yDir = Input.GetAxis("HorizontalPVP") * horizontalSpeed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * yDir);

    }
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Quaternion newRotation1 = Quaternion.AngleAxis(rotationup, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, newRotation1, 0.1f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Quaternion newRotation1 = Quaternion.AngleAxis(rotationdown, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, newRotation1, 0.1f);
        }
        else
        {
            Quaternion newRotation = Quaternion.AngleAxis(0, Vector3.forward);
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, newRotation, 0.1f);
        }



        //Om flyingHero är högre upp än skärm
        if (gameObject.transform.position.y > maxPositionY)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, minPositionY, gameObject.transform.position.z);
        }
        //Om flyingHero är längre ned än skärm
        if (gameObject.transform.position.y < minPositionY)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, maxPositionY, gameObject.transform.position.z);
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
