using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotationTask : MonoBehaviour
{
    
	public Transform head;
	public bool alwaysActive;
	public AudioSource sound;

	private bool isInRange;
	private string lastDirection;


	void Start() {
		string[] directions = new string[] {"left", "right"};
		lastDirection = directions[Random.Range(0,2)]; //initializing lastDirection so whichever side can be first
		Debug.Log("initial direction " + lastDirection);
	}

    // Update is called once per frame
    void Update()
    {
		if(!isInRange){
			
			if(lastDirection == "right")
				if(head.eulerAngles.y < 90 && head.eulerAngles.y > 45)
					StartCoroutine(Trial("left")); 
			
			if(lastDirection == "left") {
				if(head.eulerAngles.y > 270 && head.eulerAngles.y < 315){
					Debug.Log("left");
					StartCoroutine(Trial("right"));
					}
			}
		}
		
    }

	public IEnumerator Trial(string side){
		
		int trialOrNot = Random.Range(0,2);
		if(alwaysActive) trialOrNot = 1;

		isInRange = true;
		//start timer

		if(trialOrNot == 1) {
			//Debug.Log("happen");
			Debug.Log("start " + side );
			//sound.Play();

			if(side == "left") 
				while(head.eulerAngles.y < 90 && head.eulerAngles.y > 45 )
					yield return null;	
			else  
				while(head.eulerAngles.y > 270 && head.eulerAngles.y < 315 )
					yield return null;	

			Debug.Log("stop " + side);
		}

		else {
			Debug.Log("not happen");
			yield return null;
		}

		lastDirection = side;
		isInRange = false;
		
	}

}
