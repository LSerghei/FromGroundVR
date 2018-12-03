using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoorLift : MonoBehaviour {
	
    public float raiseHeight = 1f;
    public float speed = 3f;
	
	private Transform doorTransform1, doorTransform2;
	private Transform liftTransform;
    private Vector3 _closedPosition1, _closedPosition2, _closedPositionLift;
	private GameObject Player;

    // Use this for initialization
    void Start () {
		foreach (Component comp in transform){
			if (comp.name == "Door1")
				doorTransform1 = comp.transform;
			
			if (comp.name == "Door2")
				doorTransform2 = comp.transform;

		}
		
		liftTransform = GameObject.Find("Lift").transform;
		Player = GameObject.Find("Sphere");
		//Debug.Log(liftTransform);
		
        _closedPosition1 = doorTransform1.position;
		_closedPosition2 = doorTransform2.position;
		_closedPositionLift = liftTransform.position;
    }

    void OnTriggerEnter (Collider other) {
        StopCoroutine("MoveDoor1");
		Vector3 endpos = _closedPosition1 - new Vector3(raiseHeight, 0f, 0f);
        StartCoroutine("MoveDoor1", endpos);
		        
		StopCoroutine("MoveDoor2");
		endpos = _closedPosition2 + new Vector3(raiseHeight, 0f, 0f);
        StartCoroutine("MoveDoor2", endpos);
		
		StopCoroutine("MoveLift");
		if ((liftTransform.position.y != 0.065f) && (Player.transform.position.y < 0.5f)) //0.4307604f
		{
			endpos = _closedPositionLift + new Vector3(0f, -(raiseHeight + 0.4f), 0f);
			StartCoroutine("MoveLift", endpos);
		}
		else if ((liftTransform.position.y != 1.465f) && (Player.transform.position.y > 1.7f)) //1.822479
		{
			endpos = _closedPositionLift + new Vector3(0f, (raiseHeight + 0.4f), 0f);
			StartCoroutine("MoveLift", endpos);
		}
    }

    void OnTriggerExit (Collider other) {
        StopCoroutine("MoveDoor1");
        StartCoroutine("MoveDoor1", _closedPosition1);
		
        StopCoroutine("MoveDoor2");
        StartCoroutine("MoveDoor2", _closedPosition2);
    }
    

    IEnumerator MoveDoor1 (Vector3 endPos) {
        float t = 0f;
        Vector3 startPos = doorTransform1.position;
        while (t < 1f) {
		//while (doorTransform.position != endPos){
            t += Time.deltaTime * speed;
			doorTransform1.position = Vector3.MoveTowards(startPos, endPos, t);
            yield return null;
        }
    }
	
    IEnumerator MoveDoor2 (Vector3 endPos) {
        float t = 0f;
        Vector3 startPos = doorTransform2.position;
        while (t < 1f) {
		//while (doorTransform.position != endPos){
            t += Time.deltaTime * speed;
			doorTransform2.position = Vector3.MoveTowards(startPos, endPos, t);
            yield return null;
        }
    }
	
    IEnumerator MoveLift (Vector3 endPos) {
        float t = 0f;
        Vector3 startPos = liftTransform.position;
        while (t < 1.4f) {
		//while (doorTransform.position != endPos){
            t += Time.deltaTime * speed;
			liftTransform.position = Vector3.MoveTowards(startPos, endPos, t);
            yield return null;
        }
    }	
}