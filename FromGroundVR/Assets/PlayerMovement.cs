using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//public float speed;
	public float rotSpeed = 90; // rotate speed in degrees/second

	private CharacterController fplayer;
	private PlayerLog eventLog;

	// Use this for initialization
	void Start () 
	{
		fplayer = GetComponent<CharacterController>();
		eventLog = GetComponent<PlayerLog>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		float Horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * rotSpeed;
		float Vertical = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, Horizontal, 0);  
		var forward = transform.TransformDirection(Vector3.forward);
		float curSpeed = Vertical;
		fplayer.Move(forward * curSpeed);

		if (Input.GetKey(KeyCode.A))
			eventLog.AddEvent("Player Moves Left");

		if (Input.GetKey(KeyCode.W))
			eventLog.AddEvent("Player Moves Forward");
	}
}
