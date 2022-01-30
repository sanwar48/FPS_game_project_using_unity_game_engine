using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeHighlights : MonoBehaviour {
	public GameObject[] objects;

	void OnGUI(){

		foreach (GameObject go in objects) {
			bool active = GUILayout.Toggle (go.activeSelf, go.name);
			if (active != go.activeSelf)
				go.SetActive (active);
		}
	}

}
