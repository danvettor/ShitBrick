using UnityEngine;
using System.Collections;

public class CollisionTreatment : MonoBehaviour {

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
			GetComponent<PlayerMovement>().keyUI.SetActive(true);
			GetComponent<PlayerMovement>().hasKey = true;
		}
		
		else if (col.gameObject.CompareTag ("Walkable"))
		{
			GetComponent<PlayerMovement>().canJump = true;
		}
		else if (col.gameObject.CompareTag ("Exit"))
		{
			if(GetComponent<PlayerMovement>().hasKey)
			{
				LevelController.ChangeLevel();
			}
		}
		
	}

}
