using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject mainMenu;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject brickspreFab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GameManager instance = null;
	public AudioSource backgroundMusic;
    public AudioSource missPaddle;
    public AudioSource smashBricks;
  
 



	private GameObject clonePaddle;
	// Use this for initialization
	void Start () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		Setup ();
        backgroundMusic.Play();
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
            ScoreManager.score = ScoreManager.score + (lives * 750 - (int)(Time.time * 1.5));
			ShowMenuAndMessage (youWon);
		}

		if (lives < 1) 
		{
			ShowMenuAndMessage (gameOver);
		} 
	}

	public void ShowMenuAndMessage (GameObject o, bool unitTesting = false)
	{
		o.SetActive (true);
		if (unitTesting) return;
		mainMenu.SetActive (true);
		Time.timeScale = .25f;
		//Invoke("Reset", resetDelay);   now with menu, PLAY button calls it 
	}

	public void Reset ()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Quit ()
	{
		Debug.Log("In the Unity IDE & in web builds, there is no way to quit game from a script!");
		Application.Quit();
	}

	// Update is called once per frame
	public void LoseLife(bool unitTesting = false)
	{
		lives--;
		if (unitTesting) return;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
        missPaddle.Play();
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
		smashBricks.Play ();
		checkGameOver ();
	}

}
