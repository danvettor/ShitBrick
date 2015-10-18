using UnityEngine;
using System.Collections;

public class WeightControl : MonoBehaviour {

	public GameObject balanceIntegrated;
	public GameObject chain;
    public GameObject brick;
    private Vector2 brickWeight;
	void Start ()
    {
        brickWeight = new Vector2(0,brick.GetComponent<BrickBehaviour>().weight);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag ("Brick")) 
		{
			

            //esse trecho seria pra mudar a outra plataforma
            if (balanceIntegrated != null)
            {
                chain.transform.position = new Vector3(chain.transform.position.x, chain.transform.position.y + 0.045f,
                                                   chain.transform.position.z);

                balanceIntegrated.transform.Rotate(0, 0, 5.0f);
            }
            Vector2 temp = (Vector2)transform.position - brickWeight;
            StartCoroutine(LerpOutUpdate(transform.position,temp, 0.2f));
           // transform.position = Vector2.Lerp ((Vector2) transform.position, (Vector2)transform.position - brickWeight, 0.2f);
		}
	}
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.CompareTag ("Brick")) 
		{
			
            if (balanceIntegrated != null)
            {
                chain.transform.position = new Vector3(chain.transform.position.x, chain.transform.position.y - 0.045f,
                                       chain.transform.position.z);

                balanceIntegrated.transform.Rotate(0, 0, -5.0f);
            }
            Vector2 temp = (Vector2)transform.position + brickWeight;
            StartCoroutine(LerpOutUpdate(transform.position, temp, 0.2f));
        }
	}

    IEnumerator LerpOutUpdate(Vector3 source, Vector3 target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.position = Vector3.Lerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.position = target;
    }




}
