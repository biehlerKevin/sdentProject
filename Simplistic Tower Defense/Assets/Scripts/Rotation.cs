using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime*20);
    }
}
