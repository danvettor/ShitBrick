using UnityEngine;
using System.Collections;

public class PassScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Application.LoadLevel(1);

		}
		else if(Input.GetKeyDown(KeyCode.Escape))
	    {
			Application.Quit();
		}

		if (Application.loadedLevel == 0) {
			StartCoroutine(Title ());
		
		}
	}

	IEnumerator Title()
	{
		yield return new WaitForSeconds (2);
		Application.LoadLevel (1);

	}
}
