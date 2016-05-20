using UnityEngine;
using System.Collections;

public class BrickEasy : MonoBehaviour {
	public GameObject brickParticles;
    public ScoreManager sm;



	public void OnCollisionEnter(Collision other)
	{
		Instantiate (brickParticles, transform.position, Quaternion.identity); 
		GameManager.instance.DestroyBrick();
		Destroy(gameObject);
        ScoreManager.score = ScoreManager.score + 100;

	}
}
