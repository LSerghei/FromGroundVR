using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour {

	private Component CurDoor;

	public bool DoorOpen;
	public bool PlayerNear; 
	public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 5f;

	// Use this for initialization
	void Start () 
	{
		DoorOpen = false;
		PlayerNear = false;

		foreach (Component comp in transform){
			if (comp.name == "Plane_001")
				CurDoor = comp;

		}
		Debug.Log(CurDoor);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerNear){
			if (!DoorOpen) {
				Quaternion targetRotation = Quaternion.Euler (0, 0, doorOpenAngle);
				CurDoor.transform.localRotation = Quaternion.Slerp (CurDoor.transform.localRotation, targetRotation, smooth * Time.deltaTime);

				if (CurDoor.transform.localRotation.z > doorOpenAngle) {
					DoorOpen = true;
				}
			}
		} else {
			if (DoorOpen) {

				Quaternion targetRotation2 = Quaternion.Euler (0, 0, doorCloseAngle);
				CurDoor.transform.localRotation = Quaternion.Slerp (CurDoor.transform.localRotation, targetRotation2, smooth * Time.deltaTime);
				if (CurDoor.transform.localRotation.z < doorCloseAngle) {
					DoorOpen = false;			
				}
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			PlayerNear = true;
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag == "Player")
		{
			PlayerNear = false;
		}
	}
}
