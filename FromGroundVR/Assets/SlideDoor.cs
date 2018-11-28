using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour {

	public Transform doorTransform;
    public float raiseHeight = 3f;
    public float speed = 3f;
    private Vector3 _closedPosition;

    // Use this for initialization
    void Start () {
		doorTransform = transform;
        _closedPosition = transform.position;
    }

	/*void Update(){

		if (Input.GetKeyDown (KeyCode.Q)) {
			StopCoroutine ("MoveDoor");
			Vector3 endpos = _closedPosition - new Vector3 (raiseHeight, 0f, 0f);
			StartCoroutine ("MoveDoor", endpos);
		} else if (Input.GetKeyDown (KeyCode.E)) {
			StopCoroutine ("MoveDoor");
			StartCoroutine ("MoveDoor", _closedPosition);
		}

	}*/

    void OnTriggerEnter (Collider other) {
        StopCoroutine("MoveDoor");
		Vector3 endpos = _closedPosition - new Vector3(raiseHeight, 0f, 0f);
        StartCoroutine("MoveDoor", endpos);
    }

    void OnTriggerExit (Collider other) {
        StopCoroutine("MoveDoor");
        StartCoroutine("MoveDoor", _closedPosition);
    }
    

    IEnumerator MoveDoor (Vector3 endPos) {
        float t = 0f;
        Vector3 startPos = doorTransform.position;
        while (t < 1f) {
		//while (doorTransform.position != endPos){
            t += Time.deltaTime * speed;
			doorTransform.position = Vector3.MoveTowards(startPos, endPos, t);
            yield return null;
        }
    }
}