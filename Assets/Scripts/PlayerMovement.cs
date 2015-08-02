using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float speed;

	private Rigidbody2D playerRigidBody;
	public float jumpForce;
	private float lookingAt;
	private float direction;
	private float brickDistance;
	private Animator anim;
	public GameObject 
		brick,
		keyUI;
	private bool 
		hasKey,
		canJump;
	// Use this for initialization
	void Start () 
	{
		canJump = true;
		hasKey = false;
		anim = GetComponent<Animator> ();
		playerRigidBody = GetComponent<Rigidbody2D> ();
		brickDistance = this.GetComponent<Renderer> ().bounds.size.x;
		StartCoroutine (leaveBrick());
		lookingAt = 1.0f;
		Debug.Log("Tamanho do sprite "+ GetComponent<Renderer>().bounds.size.x);
	}
	
	void Update ()
	{
			
		Move ();
		Jump ();
		//Debug.Log("Tamanho do sprite "+ GetComponent<Renderer>().bounds.size);
	}
	void Move()
	{
		direction = Input.GetAxisRaw("Horizontal");
		anim.SetFloat ("Velocity", direction);
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			lookingAt = 1.0f;
			transform.eulerAngles = new Vector2(0,0);
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			lookingAt = -1.0f;
			transform.eulerAngles = new Vector2(0,180);
		}
		playerRigidBody.velocity = new Vector2 (direction*speed, playerRigidBody.velocity.y);


	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))   
		{
			if(canJump)
			{
				canJump = false;
				this.playerRigidBody.AddForce(Vector2.up*jumpForce);
			}
		}

		
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.gameObject.CompareTag ("Lava"))
		{
			Application.LoadLevel(2);
		}
		else if (col.gameObject.CompareTag ("Key"))
		{
			Destroy(col.gameObject);
			keyUI.SetActive(true);
			hasKey = true;
		}
		
		else if (col.gameObject.CompareTag ("Walkable"))
		{
			canJump = true;
		}
		else if (col.gameObject.CompareTag ("Exit"))
		{
			if(hasKey)
			{
				Application.LoadLevel(3);
			}
		}

	}



	IEnumerator leaveBrick()
	{
		yield return new WaitForSeconds (2);
		while (true) {
			Vector3 brickPosition = new Vector3 (transform.position.x + brickDistance*(-lookingAt), transform.position.y, transform.position.z);
			Instantiate(brick, brickPosition, Quaternion.identity);
			yield return new WaitForSeconds (2);

		}
	}










}