using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMove : MonoBehaviour {

    public float raiseHeight = 1.4f;
    public float speed = 3f;
	
	private Transform liftTransform;
    private Vector3 _closedPosition1, _closedPosition2;//, _closedPositionLift;
	private GameObject Player;
	//private bool LiftMoved = false;
	
	// Use this for initialization
	void Start () {
		liftTransform = GameObject.Find("Lift").transform;
		Player = GameObject.Find("Sphere");
		//_closedPositionLift = liftTransform.position;		
	}
	
	void OnTriggerEnter (Collider other) {
		Debug.Log("i enter " + liftTransform.position.y + " " + Player.transform.position.y);
		
        StopCoroutine("MoveLift");
		if ((liftTransform.position.y < 0.07f) && (Player.transform.position.y < 0.5f)) //0.065f 0.4307604f
		{
			Debug.Log("im here 1");
			Vector3 endpos = liftTransform.position + new Vector3(0f, (raiseHeight), 0f);
			StartCoroutine("MoveLift", endpos);
			//LiftMoved = true;
		}
		else if ((liftTransform.position.y > 1.4f) && (Player.transform.position.y > 1.7f)) //1.465f 1.822479
		{
			Debug.Log("im here 2");
			Vector3 endpos = liftTransform.position - new Vector3(0f, (raiseHeight), 0f);
			StartCoroutine("MoveLift", endpos);
			//LiftMoved = true;
		}
    }

    void OnTriggerExit (Collider other) {
        StopCoroutine("MoveLift");
		Debug.Log("i left");
		//LiftMoved = false;
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
