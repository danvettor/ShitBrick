using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class InputTreatment : MonoBehaviour {
	[SerializeField]
	private PlayerMovement playerMovement;
	Vector2 mousePos, mouseDeltaPos, touchPos, touchInitialPos;

	[SerializeField]
	GameObject joystick;

	void Update ()
	{
		//MouseInput ();
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
			//playerMovement.Move(mousePos);

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
		foreach(Touch currentTouch in Input.touches)
		{
			//print ("Touch id" + currentTouch.fingerId);
			if (currentTouch.position.x < Screen.width / 2)
			{
				if (currentTouch.phase == TouchPhase.Began)
				{
					print("ENTORU");
					Joystick jScript = joystick.GetComponent<Joystick>();
					Vector3 nextPos = Camera.main.ScreenToWorldPoint(new Vector3(currentTouch.position.x, currentTouch.position.y, Camera.main.nearClipPlane));
					jScript.setNextPosition(nextPos);
					joystick.SetActive(true);
				}
			}
		}

	}
}
