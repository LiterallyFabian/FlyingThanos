using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleIcon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (collisions.powerupdouble == true)
        {
            transform.localPosition = new Vector3(353.7f, -178.7f, 0);
        }
        else
        {
            transform.localPosition = new Vector3(353.7f, -278.7f, 0);
        }
    }
}
