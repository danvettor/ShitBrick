using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputTreatment : MonoBehaviour {
	[SerializeField]
	private PlayerMovement playerMovement;
	private float minTouchSpeedToJump, initialX, touchDX, maxTouchDX;
	Vector2 mousePos, mouseDeltaPos, touchPos, touchInitialPos;

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
					touchInitialPos = ShowSlider (Input.GetTouch(i).position);

				} 
				else if (Input.GetTouch (i).phase == TouchPhase.Moved)
				{
					MoveSlider(Input.GetTouch(i).position);
					touchDX = Input.GetTouch(i).position.x - touchInitialPos.x;

					playerMovement.Move(touchDX);
					slider.value = touchDX;
				}
				else if(Input.GetTouch (i).phase == TouchPhase.Stationary)
				{
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
	
	Vector3 ShowSlider (Vector3 initialPos)
	{	
		slider.transform.position = new Vector3(initialPos.x, initialPos.y + sliderDY, initialPos.z);
		slider.gameObject.SetActive (true);
		slider.value = 0;
		return initialPos;
	}
	void MoveSlider(Vector2 variationPos)
	{
		Vector3 newPos = new Vector3 (variationPos.x, variationPos.y + sliderDY, slider.transform.position.z);
		slider.transform.position = Vector3.Lerp(slider.transform.position, newPos, 0.4f);

	}
}
