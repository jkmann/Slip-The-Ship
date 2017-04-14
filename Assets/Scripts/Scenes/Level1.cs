using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag("Exit").GetComponent<Renderer>().material.SetColor("_Color", Color.green);
				Destroy(gameObject);
		}
	}
	
}

