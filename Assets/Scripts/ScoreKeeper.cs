using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text deathCount;
	// Use this for initialization
	void Start () {
		//deaths = PlayerPrefs.GetInt ("deaths");
	}
	
	// Update is called once per frame
	void Update () {
		deathCount.text = "Deaths: " + PlayerPrefs.GetInt ("deaths").ToString();
	}


}
