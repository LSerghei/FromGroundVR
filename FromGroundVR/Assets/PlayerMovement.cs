using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	
	//private Rigidbody rigid;
	private CharacterController fplayer;
	private PlayerLog eventLog;

	// Use this for initialization
	void Start () 
	{
		//rigid = GetComponent<Rigidbody>();
		fplayer = GetComponent<CharacterController>();
		eventLog = GetComponent<PlayerLog>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
        float Horizontal = Input.GetAxis("Horizontal");
		float Vertical = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(Horizontal, 0.0f, Vertical);

		fplayer.Move(move * speed);
		//rigid.AddForce(move * speed);

		if (Input.GetKey(KeyCode.A))
			eventLog.AddEvent("Player Moves Left");

		if (Input.GetKey(KeyCode.W))
			eventLog.AddEvent("Player Moves Right");
	}
}
