using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	// Movement
	public float movementSpeed;
	public float maxSpeed;

	// Jumping
	private bool isJumping;
	public float jumpForce;
	private bool canJump;

	// Wall jumping
	private bool touchingWall;
	private Vector2 wallPosition;

	// Player selection
	public bool player1;
	public bool player2;
	private float horizontalAxis;
	private float verticalAxis;

	// Checks if player can wall jump
	private bool emptyMeter = false;

	// 'Start' is called once when the game begine
	void Start () 
	{

	}
	
	// 'Update' is called once every frame
	void Update () 
	{
		if (player1)
		{
			horizontalAxis = Input.GetAxisRaw("Horizontal1");
			verticalAxis = Input.GetAxisRaw("Vertical1");

			emptyMeter = GameObject.Find("Meter1").GetComponent<Meter>().isEmpty;
		}
		else if (player2)
		{
			horizontalAxis = Input.GetAxisRaw("Horizontal2");
			verticalAxis = Input.GetAxisRaw("Vertical2");

			emptyMeter = GameObject.Find("Meter2").GetComponent<Meter>().isEmpty;
		}

		Debug.Log("emptyMeter: " + emptyMeter);

		handleMovement();
	}

	void handleMovement()
	{
		Vector2 movementDirection = new Vector2(horizontalAxis, 0);
		movementDirection *= movementSpeed;

		if (Mathf.Abs(rigidbody2D.velocity.x) <= maxSpeed)
		{
			rigidbody2D.AddForce(movementDirection);
		}

		if (verticalAxis > 0 && !isJumping && !touchingWall)
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			isJumping = true;
		}
		else if (verticalAxis > 0 && !isJumping && touchingWall && !emptyMeter)
		{
			if (horizontalAxis >= 0)
			{
				rigidbody2D.AddForce(new Vector2(-(jumpForce/4), jumpForce));
			}
			else
			{
				rigidbody2D.AddForce(new Vector2((jumpForce/4), jumpForce));
			}

			isJumping = true;
		}

		handleWallJumping();
	}

	void handleWallJumping()
	{
		// If the player is touching a wall and is holding the direction 
		// button, decrease gravity scale
		if (Mathf.Abs(horizontalAxis) > 0 && touchingWall)
		{
			rigidbody2D.gravityScale = 0.5f;
			isJumping = false;
		}
		else
		{
			rigidbody2D.gravityScale = 1;
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{
			isJumping = false;
		}

		if (other.gameObject.CompareTag("Wall"))
		{
			wallPosition = transform.position;
			touchingWall = true;
		}

		if (other.gameObject.CompareTag("Player"))
		{
			GameObject.Find("Meter1").GetComponent<Meter>().resetMeter();
			GameObject.Find("Meter2").GetComponent<Meter>().resetMeter();
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Floor"))
		{
			isJumping = true;
		}

		if (other.gameObject.CompareTag("Wall"))
		{
			touchingWall = false;
		}
	}
}
