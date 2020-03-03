using UnityEngine;
using System.Collections;

public class shurikenMovement : MonoBehaviour
{
    public int Speed = 12;


    void Start()
    {
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.right * -Speed * Time.deltaTime);
    }
}
