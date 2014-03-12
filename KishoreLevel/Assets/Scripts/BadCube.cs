using UnityEngine;
using System.Collections;

public class BadCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) 
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	}

}
