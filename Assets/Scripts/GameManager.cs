using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject brickspreFab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GameManager instance = null;

	//public AudioSource audio;



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

	public void checkGameOver()
	{
		if (bricks < 1) 
		{
			youWon.SetActive (true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		}

		if (lives < 1) 
		{
			gameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke("Reset", resetDelay);
		} 
	}

	public void Reset ()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}
	
	// Update is called once per frame
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		checkGameOver();
	}

	public void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;

	}

	public void DestroyBrick()
	{
		bricks--;
		//audio.Play ();
		checkGameOver ();
	}
}
