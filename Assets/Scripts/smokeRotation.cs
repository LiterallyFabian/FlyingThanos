using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = Quaternion.Euler(136, 90, 90);
    }
}
