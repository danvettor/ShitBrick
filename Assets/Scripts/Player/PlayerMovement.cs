using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private IEnumerator coroutine;
	private Rigidbody2D playerRigidBody;
	public float 
		speed,
		jumpForce;
	public Slider velSlider;
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
		
		velSlider.minValue = -1;
		//velSlider.gameObject.SetActive(false);
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
	public void StartMoving(float direction)
	{
		//coroutine = Move (direction);
		//StartCoroutine(coroutine);
	
	}
	public void StopMoving()
	{
		//StopCoroutine(coroutine);
	}
	
	public void Move(float direction) 
	{
		//direction = direction - (Vector2) Camera.main.WorldToScreenPoint(transform.position);
		//direction = (Vector2) Vector3.Project (direction.normalized, (Vector3)Vector2.right);
		
		lookingAt = Mathf.Round (direction);
		if (lookingAt == 1 || lookingAt == -1) 
		{
			transform.eulerAngles = new Vector2 (0, Mathf.Acos (lookingAt) * Mathf.Rad2Deg);
			playerRigidBody.velocity = new Vector2 (lookingAt * speed, playerRigidBody.velocity.y);
			velSlider.value = lookingAt;
		}
	}
	/*IEnumerator Move(float direction)
	{
		while(true)
		{
			transform.eulerAngles = new Vector2 (0, Mathf.Acos (direction) * Mathf.Rad2Deg);
			
			playerRigidBody.velocity = new Vector2 (direction*speed, playerRigidBody.velocity.y);
			yield return new WaitForSeconds(0.05f);
		}
	}*/

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