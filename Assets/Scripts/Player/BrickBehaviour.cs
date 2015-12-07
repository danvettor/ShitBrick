using UnityEngine;
using System.Collections;

public class BrickBehaviour : MonoBehaviour {
    public float weight;
    public string type;
	// Use this for initialization
	void Awake ()
    {
        weight = weight / 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
