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
		anim.SetFloat("Velocity", playerRigidBody.velocity.x);
	}

	public void Move(Vector2 direction)
	{
		direction = direction - (Vector2) Camera.main.WorldToScreenPoint(transform.position);
		direction = (Vector2) Vector3.Project (direction.normalized, (Vector3)Vector2.right);
		lookingAt = Mathf.Round (direction.x);
		if (lookingAt == 1 || lookingAt == -1) 
		{
			transform.eulerAngles = new Vector2 (0, Mathf.Acos (lookingAt) * Mathf.Rad2Deg);
			playerRigidBody.velocity = new Vector2 (lookingAt*speed, playerRigidBody.velocity.y);

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
	void OnTriggerEnter2D(Collider2D col)
	{
		
		if (col.gameObject.CompareTag ("Lava"))
		{
			LevelController.setLastScene(Application.loadedLevelName);
			print (LevelController.getLastScene());
			Application.LoadLevel("LoseScene");
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
                LevelController.ChangeLevel();
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