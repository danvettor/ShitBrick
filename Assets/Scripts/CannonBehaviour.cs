using UnityEngine;
using System.Collections;

public class CannonBehaviour : MonoBehaviour {

    public GameObject fireballPrefab;
    public Transform shootPosition;
    public float speed;
	void Start ()
    {
        StartCoroutine(Shoot());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject fireball = Instantiate(fireballPrefab, shootPosition.position, Quaternion.identity) as GameObject;
            fireball.GetComponent<Rigidbody2D>().velocity = shootPosition.right*speed;
            yield return new WaitForSeconds(1.0f);

        }
    }
}
