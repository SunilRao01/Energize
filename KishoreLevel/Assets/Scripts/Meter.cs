using UnityEngine;
using System.Collections;

public class Meter : MonoBehaviour 
{
	public bool meter1;
	public bool meter2;

	public float meterRate;
	public float maxRate;

	private float originalPosition;
	public bool isEmpty = false;

	// Use this for initialization
	void Start () 
	{
		originalPosition = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (meter1)
		{
			if (Mathf.Abs(rigidbody2D.velocity.x) < maxRate)
			{
				rigidbody2D.AddForce(Vector3.left * meterRate);
			}
		}
		else if (meter2)
		{
			if (Mathf.Abs(rigidbody2D.velocity.x) < maxRate)
			{
				rigidbody2D.AddForce(Vector3.right * meterRate);
			}
		}
	}

	public void resetMeter()
	{
		transform.position = new Vector3 (originalPosition, transform.position.y, transform.position.z);

		isEmpty = false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Bound"))
		{
			isEmpty = true;
		}
	}
}
