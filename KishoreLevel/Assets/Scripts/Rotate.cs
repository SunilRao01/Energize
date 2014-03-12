﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour 
{
	public bool xRotation;
	public bool yRotation;
	public bool zRotation;

	public float rotationSpeed;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (xRotation)
		{
			transform.Rotate(Vector3.right * rotationSpeed);
		}
		if (yRotation)
		{
			transform.Rotate(Vector3.up * rotationSpeed);
		}
		if (zRotation)
		{
			transform.Rotate(Vector3.forward * rotationSpeed);
		}
	}
}
