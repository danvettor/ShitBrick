using UnityEngine;
using System.Collections;

public class WeightControl : MonoBehaviour {

	public GameObject balanceIntegrated;
	public GameObject chain;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag ("Brick")) 
		{
			chain.transform.position = new Vector3(chain.transform.position.x, chain.transform.position.y + 0.045f,
			                                       chain.transform.position.z);
			balanceIntegrated.transform.Rotate(0,0,5.0f);
			
			Vector2 weight = new Vector2 (0,0.05f);
			transform.position = transform.position - (Vector3)weight;
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.CompareTag ("Brick")) 
		{
			
			chain.transform.position = new Vector3(chain.transform.position.x, chain.transform.position.y - 0.045f,
			                                       chain.transform.position.z);
			balanceIntegrated.transform.Rotate(0,0,-5.0f);
			Vector2 weight = new Vector2 (0,0.05f);
			transform.position = transform.position + (Vector3)weight;
		}
	}
}
