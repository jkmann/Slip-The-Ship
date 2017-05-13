using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackzone : MonoBehaviour {
	public static bool playerInTerritory;
	public BoxCollider territory;
	GameObject player = GameObject.FindGameObjectWithTag ("Player");
	//transform.LookAt (player);
	//	transform.Translate(new Vector3 (m_speed * Time.deltaTime, 0, 0));;

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		
		playerInTerritory = false;

	}

	// Update is called once per frame
	void Update () {
		
//	if (playerInTerritory == true) {
	//		enemy.MoveToPlayer ();
	//	}
	//	if (playerInTerritory == false) {
	//		enemy.Rest ();

	//	}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject == GameObject.FindGameObjectWithTag ("Player")) {
			playerInTerritory = true;
		}

	}
	void OnTriggerExit(Collider other){
		if (other.gameObject == GameObject.FindGameObjectWithTag ("Player")) {
			playerInTerritory = false;
		}
	}

}
