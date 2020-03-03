using UnityEngine;
using System.Collections;

public class powerupMovement : MonoBehaviour
{
    public static int powerupSpeed = 8;


    void Start()
    {
    }

    void Update()
    {
        //Vector3.right är samma sak som Vector3(1, 0, 0)
        gameObject.transform.Translate(Vector3.right * -powerupSpeed * Time.deltaTime);
    }
}
