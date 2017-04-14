using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevelChecker : MonoBehaviour {


	bool hasKey = false;
	Color myColor = new Color(0f, 1f, 0f, 1f);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<Renderer> ().material.color.Equals(myColor) && hasKey == false){
			hasKey = true;	
		}
	}
		void OnCollisionEnter(Collision col){
		if (hasKey == true && col.gameObject.tag == "Player"){
			print("You beat the level!");
			SceneManager.LoadScene ("MainMenu");
		}
	}
}
