using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableGen : MonoBehaviour {

	public GameObject eatable;
	GameObject[] eatables;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		eatables = GameObject.FindGameObjectsWithTag ("Eatable");
		if(eatables.Length<4)
		 generateEatable ();
	}

	void generateEatable()
	{
		for (int i = 0; i < 5; i++) {
			float x = (float)Random.Range (-8, 8);
			float y = (float)Random.Range (-8, 8);
			Instantiate (eatable, new Vector3 (x, y, 0.0f), Quaternion.identity);
		}
	}
}
