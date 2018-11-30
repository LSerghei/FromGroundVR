using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour {

	public Transform doorTransform1, doorTransform2;
    public float raiseHeight = 1f;
    public float speed = 3f;
    private Vector3 _closedPosition1, _closedPosition2;

    // Use this for initialization
    void Start () {
		foreach (Component comp in transform){
			if (comp.name == "Door1")
				doorTransform1 = comp.transform;
			
			if (comp.name == "Door2")
				doorTransform2 = comp.transform;

		}
        _closedPosition1 = doorTransform1.position;
		_closedPosition2 = doorTransform2.position;
    }

    void OnTriggerEnter (Collider other) {
        StopCoroutine("MoveDoor1");
		Vector3 endpos = _closedPosition1 - new Vector3(raiseHeight, 0f, 0f);
        StartCoroutine("MoveDoor1", endpos);
		        
		StopCoroutine("MoveDoor2");
		endpos = _closedPosition2 + new Vector3(raiseHeight, 0f, 0f);
        StartCoroutine("MoveDoor2", endpos);
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
}