﻿using UnityEngine;
using System.Collections;

public class Rotation2 : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime*20);
    }
}
