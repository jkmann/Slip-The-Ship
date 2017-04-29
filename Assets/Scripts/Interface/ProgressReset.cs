using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ResetProgress(){
		PlayerPrefs.SetInt ("deaths", 0);
		PlayerPrefs.SetInt ("CurLevel", 0);

	}
}
