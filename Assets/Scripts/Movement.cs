using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	// Use this for initialization
	float speed=2f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		//speed=calculateSpeed ();
	}

	float calculateSpeed()
	{
		return 1.5f / transform.localScale.x;	
	}

	void Move()
	{
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 direction = new Vector3 (mousePosition.x, mousePosition.y,0.0f) - transform.position;
		direction.Normalize ();
		transform.Translate (new Vector3 (direction.x*speed*Time.deltaTime,direction.y*speed*Time.deltaTime,0.0f));
		//rb2d.velocity=new Vector2(direction.x*speed*Time.deltaTime,direction.y*speed*Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Competitor" && col.transform.localScale.x<transform.localScale.x) {
			Destroy (col.gameObject);
		}
	}
		


}
