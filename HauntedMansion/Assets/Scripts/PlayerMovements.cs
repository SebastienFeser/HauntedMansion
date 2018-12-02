using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour {
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] float playerSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, 0);
        }
        else if (Input.GetAxisRaw("Vertical") == 0)
        {
            playerRigidbody.velocity = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            playerRigidbody.velocity = new Vector2(0, Input.GetAxisRaw("Vertical") * playerSpeed);
        }
        else if (Input.GetAxisRaw("Horizontal") == 0)
        {
            playerRigidbody.velocity = new Vector2(0, 0);
        }
    }
    
}
