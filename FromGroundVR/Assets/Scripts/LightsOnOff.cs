using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOnOff : MonoBehaviour {

	public bool LightOn = true;
	
	private GameObject Light;
	//private bool inLightOn = true;
	// Use this for initialization
	void Start () {		
		Light = transform.Find("Lamps").gameObject;		
	}
	
	// Update is called once per frame
	void Update () {
		if (Light.activeSelf != LightOn)
		{
			Light.SetActive(LightOn);
		}
	}
}
