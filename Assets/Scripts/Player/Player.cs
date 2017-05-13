using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public static bool inArea;
	public static int deaths;
	// Use this for initialization
	void Start () {
		deaths = PlayerPrefs.GetInt ("deaths");
		inArea = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Trackzone") {
			inArea = true;
			print ("oh no! you're being tracked!!");
		} else {
			inArea = false;
			print ("safe zone.");
		}
		if (col.gameObject.tag == "Enemy") {
			deaths++;
			print ("dead!");
			PlayerPrefs.SetInt ("deaths", deaths);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

}
