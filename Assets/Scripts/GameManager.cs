using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int bricks = 20;

	public GameObject brickspreFab;
	public GameObject paddle;

	public static GameManager instance = null;
	

	
	
	
	private GameObject clonePaddle;
	// Use this for initialization
	void Start () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		Setup ();
	}
	
	public void Setup()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (brickspreFab, transform.position, Quaternion.identity);
	}



	
	public void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		
	}
	
	public void DestroyBrick()
	{

			bricks--;
			
	}
}
