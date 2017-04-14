using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public static int deaths;
	// Use this for initialization
	void Start () {
		deaths = PlayerPrefs.GetInt ("deaths");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy") {
			deaths++;
			print ("dead!");
			PlayerPrefs.SetInt ("deaths", deaths);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

}
