using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	//public float speed;
	public float rotSpeed = 90; // rotate speed in degrees/second
	public int FPS = 0;

	private CharacterController fplayer;
	private PlayerLog eventLog;
	
	private float speed = 6.0f;
    private float jumpSpeed = 8.0f;//how high it jumps even though its called speed
    private float gravity = 20.0f;
    private float rotateSpeed = 3.0f;
	
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		fplayer = GetComponent<CharacterController>();
		eventLog = GetComponent<PlayerLog>();
	}
	
	// Update is called once per frame
	void Update() //FixedUpdate()
	{
		FPS = (int)(1.0f / Time.deltaTime);
		/*
		if (fplayer.isGrounded)
		{	
			Debug.Log("y");
		}
		else 
		{
			Vector3 down = Vector3.zero;
			down.y -= gravity * Time.deltaTime;
			fplayer.Move(down * Time.deltaTime * speed);
		}
		
		float Horizontal = Input.GetAxis ("Horizontal") * Time.deltaTime * rotSpeed;
		float Vertical = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;		
		
		transform.Rotate(0, Horizontal, 0);  
		var forward = transform.TransformDirection(Vector3.forward);
		float curSpeed = Vertical;
		//if (!fplayer.isGrounded)
		//	forward.y -= gravity * Time.deltaTime;
		
		//fplayer.Move(forward * curSpeed * speed);

		if (Input.GetKey(KeyCode.A))
			eventLog.AddEvent("Player Moves Left");

		if (Input.GetKey(KeyCode.W))
			eventLog.AddEvent("Player Moves Forward");
		
		// Apply gravity
        //moveDirection.y -= gravity * Time.deltaTime;
         
        // Move the controller
		//fplayer.Move(moveDirection * Time.deltaTime);
		*/
		
		if (fplayer.isGrounded) {
             // We are grounded, so recalculate
             // move direction directly from axes
             moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
             
             //rotate code
             transform.Rotate(0, Input.GetAxis("Horizontal")* rotateSpeed, 0);
             
             moveDirection = transform.TransformDirection(moveDirection);
             moveDirection *= speed;
             
             if (Input.GetButton ("Jump")) {
                 moveDirection.y = jumpSpeed;
             }
         }
 
         // Apply gravity
         moveDirection.y -= gravity * Time.deltaTime;
         
         // Move the controller
         fplayer.Move(moveDirection * Time.deltaTime);

	}
}