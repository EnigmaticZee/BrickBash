using UnityEngine;
using System.Collections;

public class BrickEasy : MonoBehaviour {
	public GameObject brickParticles;


	public void OnCollisionEnter(Collision other)
	{
		Instantiate (brickParticles, transform.position, Quaternion.identity); 
		GameManager.instance.DestroyBrick();
		Destroy(gameObject);
	}
}
