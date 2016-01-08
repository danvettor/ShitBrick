using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputTreatment : MonoBehaviour {
	[SerializeField]
	private PlayerMovement playerMovement;
	private float minTouchSpeedToJump, initialX, touchDX, maxTouchDX;
	Vector2 mousePos, mouseDeltaPos, touchPos;

	[SerializeField]
	private Slider slider;
	private float sliderDY;
	
	void Start()
	{
		minTouchSpeedToJump = Screen.height / 2;
		maxTouchDX = slider.handleRect.anchorMax.x;
		sliderDY = Screen.height / 6;
		print ("maxTouchDX = " + maxTouchDX);
	}

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
//		printDeltaPos.text = "DeltaPos = " + Input.GetTouch(0).deltaPosition;
		for(int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).position.x < Screen.width / 2)
			{
				if (Input.GetTouch(i).phase == TouchPhase.Began)
				{
					initialX = Input.GetTouch(i).position.x;
					showSlider (i);
				} 
				else if (Input.GetTouch (i).phase == TouchPhase.Moved)
				{
					touchDX = Input.GetTouch(i).position.x - initialX;
					playerMovement.Move(touchDX);
					slider.value = touchDX;
				}
				else if (Input.GetTouch(i).phase == TouchPhase.Ended)
				{
					gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					slider.gameObject.SetActive(false);
				}
			}
			else
			{
				if (Input.GetTouch(i).deltaPosition.y / Input.GetTouch(i).deltaTime > minTouchSpeedToJump)
				playerMovement.Jump ();
			}

		}
		print ("DeltaX = " + touchDX);

	}
	
	void showSlider (int i)
	{
		slider.gameObject.SetActive (true);
		slider.transform.position = new Vector3 (initialX, Input.GetTouch (i).position.y + sliderDY, slider.transform.position.z);
		slider.value = 0;
	}
}
