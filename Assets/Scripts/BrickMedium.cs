using UnityEngine;
using System.Collections;

public class BrickMedium : MonoBehaviour {
	public GameObject brickParticles;
	int hitsNeeded = 2;
	int hitsTaken;
	
	public void OnCollisionEnter(Collision other)
	{		
		Instantiate (brickParticles, transform.position, Quaternion.identity); 

		if (++hitsTaken >= hitsNeeded) {
			GameManager.instance.DestroyBrick(); // plays sound, and decrements brick count 
			Destroy(gameObject);
		}else{
			// TODO: you probably want to play a CLINK type of sound HERE
			// when ball bounces off this brick on the 1st hit 
			//audio.Play ("clink");
		}
	}
}
