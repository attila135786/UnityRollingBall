﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour {
	public Vector3 rotationVector = new Vector3(15, 30, 45);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (rotationVector * Time.deltaTime);
	}
}
