using UnityEngine;
using System.Collections;

public class PassTitleScene : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
	
		StartCoroutine(Title ());
		
	}

	IEnumerator Title()
	{
		yield return new WaitForSeconds (2);

        LevelController.ChangeLevel();
        StopCoroutine(Title());
	}
}
