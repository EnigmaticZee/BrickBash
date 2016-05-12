using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Ball") 
		{
			Destroy(this.gameObject);
		}		
	}
}
