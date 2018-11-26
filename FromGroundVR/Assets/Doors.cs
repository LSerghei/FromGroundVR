using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	private Animator animator;
	private bool doorOpen;

	void Start()
	{
		doorOpen = false;
		animator = GetComponent<Animator>();
		
	}
	
	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			doorOpen = true;
			DoorContorl("Open");
			DoorContorl2("Close");
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player")
			if(doorOpen)
			{
				doorOpen = false;
				DoorContorl("Close");
				DoorContorl2("Open");
			}
	}
	
	void DoorContorl(string direction)
	{
		animator.SetTrigger(direction);
	}
	
	void DoorContorl2(string direction)
	{
		animator.ResetTrigger(direction);
	}
}
