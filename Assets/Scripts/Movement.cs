﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float paddleSpeed = 1f;
   // GameManager gm = new GameManager();

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);
   
    // Update is called once per frame
    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, +8f), -9.5f, 0f);
        transform.position = playerPos;
    }

    void OnCollsionEnter(Collision other)
    {
        Debug.Log("inside collision");
        if (other.gameObject.tag == "Ball")
        {
            Debug.Log("HIt");

            //gm.paddleHit.Plays

        }
    }
}