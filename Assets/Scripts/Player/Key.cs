using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
	public static bool des;
	// Use this for initialization
	void Start () {
		des = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			
				Destroy(gameObject);
				des = true;

		}
	}
	
}

