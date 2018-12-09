using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLog : MonoBehaviour 
{
	// Private VARS
	private List<string> Eventlog = new List<string>();
	private string localGuiText = "";

	// Public VARS
	public int maxLines = 10;

	void OnGUI()
	{
		GUI.Label(new Rect(0, Screen.height - (Screen.height / 3), Screen.width, Screen.height / 3), localGuiText, GUI.skin.textArea);
	}

	public void AddEvent(string eventString)
	{
		Eventlog.Add(eventString);

		if (Eventlog.Count >= maxLines)
			Eventlog.RemoveAt(0);

		localGuiText = "";

		foreach (string logEvent in Eventlog)
		{
			localGuiText += logEvent;
			localGuiText += "\n";
		}
	}
}
