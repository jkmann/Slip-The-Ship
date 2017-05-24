using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Keep track of the player's score/deaths at all times */

public class ScoreKeeper : MonoBehaviour
{

	public Text deathCount;

	void Start ()
	{
	}

	void Update ()
	{
		deathCount.text = "Deaths: " + PlayerPrefs.GetInt ("deaths").ToString ();

	}


}
