using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputTreatment : MonoBehaviour {
	[SerializeField]
	private PlayerMovement playerMovement;

	[SerializeField]
	private Text printDeltaPos;

	[SerializeField]
	private float dyMinToJump = 10f;

	Vector2 mousePos, mouseDeltaPos, touchPos, touchDeltaPos;
	void Update ()
	{
		MouseInput ();
		TouchInput ();
	}

	//Existem algumas diferencas sutis entre a implementacao do Touch e do Mouse, nao errei nos nomes nao
	void MouseInput()
	{
		if (Input.GetMouseButtonDown (0))
		{
			mouseDeltaPos = Input.mousePosition;
		
		}
		if (Input.GetMouseButton (0))
		{
			mousePos = Input.mousePosition;
			playerMovement.Move(mousePos);

		}
		else if (Input.GetMouseButtonUp (0))
		{
			mouseDeltaPos = mousePos - mouseDeltaPos;
			Debug.Log ("Magnitude swipe" + mouseDeltaPos.magnitude);
			if(mouseDeltaPos.magnitude > Screen.height/2 && mouseDeltaPos.y > 0 && Vector2.Angle(mouseDeltaPos, Vector2.right) > 45)
				playerMovement.Jump();
			Debug.Log ("Tamanho da tela:( " + Screen.width+" "+Screen.height+ ")");
		}

	}
	
	void TouchInput()
	{
//		printDeltaPos.text = "DeltaPos = " + Input.GetTouch(0).deltaPosition;
		if(Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				touchDeltaPos = Input.GetTouch(0).position;
				playerMovement.Move (touchDeltaPos);
			} 
			else if (Input.GetTouch(0).deltaPosition.y > dyMinToJump)
				playerMovement.Jump ();

		}

	}
	
}
