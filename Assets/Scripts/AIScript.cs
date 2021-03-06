using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class AIScript : MonoBehaviour {

	GameObject[] eatables;
	GameObject[] competitors;
	float[] eatableDistance;
	float[] competitorDistance;
	float speed=2f;
	bool chaseOrRunFlag=false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		eatables = GameObject.FindGameObjectsWithTag ("Eatable");
		competitors=GameObject.FindGameObjectsWithTag ("Competitor");
		eatableDistance = new float[eatables.Length];
		competitorDistance = new float[competitors.Length];
		//speed=calculateSpeed ();
		DoAction ();
	}

	float calculateSpeed()
	{
		return 1.5f / transform.localScale.x;	
	}

	void DoAction()
	{
		chaseOrRunFlag=ChaseOrRun ();
		if(!chaseOrRunFlag)
		 Eat ();
	}

	bool ChaseOrRun()
	{
		for (int i = 0; i<competitors.Length; i++) {
			 competitorDistance [i] = Vector3.Distance (transform.position,competitors[i].transform.position);
		}
		int competitorIndex=calculateShortestCompetitor ();

		//Run Code
		if(competitors[competitorIndex].transform.localScale.x > transform.localScale.x && competitorDistance [competitorIndex] < 4.5f)
		{
			Vector3 direction = competitors [competitorIndex].transform.position - transform.position;
			direction.Normalize ();
			transform.Translate (new Vector3 (-direction.x * speed * Time.deltaTime,-direction.y * speed * Time.deltaTime, 0.0f));
			return true;
		}

		//Chase Code
		else if (competitorDistance [competitorIndex] < 3.5f && competitors[competitorIndex].transform.localScale.x < transform.localScale.x) {
			Vector3 direction = competitors [competitorIndex].transform.position - transform.position;
			direction.Normalize ();
			transform.Translate (new Vector3 (direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime, 0.0f));
			return true;
		}

		//Eat Code
		else {
			return false;
		}
	}

	void Eat()
	{
		for (int i = 0; i<eatables.Length; i++) {
			eatableDistance [i] = Vector3.Distance (transform.position,eatables[i].transform.position);
		}
		int eatableIndex=calculateShortestEatable ();
		Vector3 direction = eatables[eatableIndex].transform.position - transform.position;
		direction.Normalize ();
		transform.Translate (new Vector3 (direction.x*speed*Time.deltaTime,direction.y*speed*Time.deltaTime,0.0f));
	}

	int calculateShortestEatable()
	{
		float minDistance = 9999999f;
		int index=0;
		for (int i = 0; i < eatableDistance.Length; i++) {
			if (eatableDistance [i] < minDistance) {
				minDistance = eatableDistance [i];
				index = i;
			}
		}
		return index;
	}

	int calculateShortestCompetitor()
	{
		
		int index=0;
		float minDistance = 9999999999f;
		for (int i = 0; i < competitorDistance.Length; i++) {
			
			if (competitorDistance [i] < minDistance && this.gameObject!=competitors[i]) {
				minDistance = competitorDistance [i];
				index = i;
			}
		}
		return index;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Competitor" && col.transform.localScale.x<transform.localScale.x) {
			Destroy (col.gameObject);
		}
	}
}