using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOnOff : MonoBehaviour {

	public bool LightOn = true;
	
	private GameObject[] Lights;
	private bool inLightOn = true;
	// Use this for initialization
	void Start () {
		//Lights = this.transform.Find("Lamps").GetComponent<Component>();
		Lights = GetComponents<GameObject>();
		Debug.Log(Lights);
	}
	
	// Update is called once per frame
	void Update () {
		//if (inLightOn != LightOn)
		//{
		//	foreach(GameObject gam in Lights)
		//	{
		//		gam.GetComponent<Light>.enabled = !gam.enabled;
		//		inLightOn = !inLightOn;
		//	}
		//}
	}
}
