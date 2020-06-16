using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotationTask : MonoBehaviour
{
    
	public Transform head;
	public bool activateRandomly;
	public AudioSource sound;
    public int lMinThres, lMaxThres, rMinThres, rMaxThres;


	private bool isInRange;
	private string lastDirection;


	void Start() {
		string[] directions = new string[] {"left", "right"};
		lastDirection = directions[Random.Range(0,2)]; //initializing lastDirection randomly so either side can be first
	}

    // Update is called once per frame
    void Update()
    {
		if(!isInRange){
            
			if(lastDirection == "right")
				if(head.eulerAngles.y < lMaxThres && head.eulerAngles.y > lMinThres)
					StartCoroutine(Trial("left")); 
			
			if(lastDirection == "left") 
				if(head.eulerAngles.y < rMaxThres && head.eulerAngles.y > rMinThres)
					StartCoroutine(Trial("right"));			
		}	
    }

	public IEnumerator Trial(string side){
       
        int trialOrNot;

        if (activateRandomly) trialOrNot = Random.Range(0, 2);
        else trialOrNot = 1;

        isInRange = true;
		//start timer

		if(trialOrNot == 1) {
		    //Debug.Log("start " + side );
			sound.Play();

			if(side == "left") 
				while(head.eulerAngles.y < lMaxThres && head.eulerAngles.y > lMinThres)
					yield return null;	
			else  
				while(head.eulerAngles.y < rMaxThres  && head.eulerAngles.y > rMinThres)
					yield return null;

            //Debug.Log("stop " + side);
		}

		else yield return null;
		
		lastDirection = side;
		isInRange = false;
		
	}

}
