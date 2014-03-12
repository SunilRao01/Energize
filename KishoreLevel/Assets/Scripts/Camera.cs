using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Lock rotation
		transform.eulerAngles = new Vector3(0, 0, 0);

		// Lock z/z position
		transform.position = new Vector3(0, GameObject.Find("Player1").GetComponent<Transform>().position.y + 2, -10);
		                                
	}
}
