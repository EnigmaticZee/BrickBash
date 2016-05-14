using UnityEngine;
using System.Collections;

public class BrickMedium : MonoBehaviour {
	public GameObject brickParticles;
	int hitsNeeded = 2;
	int hitsTaken;
	
	public void OnCollisionEnter(Collision other)
	{
		
		Instantiate (brickParticles, transform.position, Quaternion.identity); 
		
			GameManager.instance.DestroyBrick();
			if (++hitsTaken >= hitsNeeded)
				Destroy(gameObject);
		
		
	}
}
