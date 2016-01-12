using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private IEnumerator coroutine;
	private Rigidbody2D playerRigidBody;
	public float 
		speed,
		jumpForce;
	private float 
		lookingAt,
		direction, 
		brickDistance;
	private Animator anim;
	public bool 
		canJump,
		hasKey;
	public GameObject 
		brick,
		keyUI;
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
		anim.SetFloat("Velocity", playerRigidBody.velocity.x);
		
	}
	
	public void Move(float direction) 
	{	lookingAt = direction > 0 ? 1: -1;
		if (lookingAt == 1 || lookingAt == -1) 
		{
			transform.eulerAngles = new Vector2 (0, Mathf.Acos (lookingAt) * Mathf.Rad2Deg);
			playerRigidBody.velocity = new Vector2 (lookingAt * speed, playerRigidBody.velocity.y);
		}
	}

	public void Jump()
	{
		if(canJump)
		{
			canJump = false;
			this.playerRigidBody.AddForce(Vector2.up*jumpForce);
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