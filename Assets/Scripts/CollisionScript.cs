using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log ("Found");
		float xscale = col.gameObject.transform.localScale.x;
		float yscale = col.gameObject.transform.localScale.y;
		xscale *= 1.1f;
		yscale *= 1.1f;
		col.gameObject.transform.localScale = new Vector3 (xscale, yscale, 1.0f);
		Destroy (this.gameObject);
	}


}
