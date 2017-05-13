using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Tracking : MonoBehaviour {

	public Transform[] waypoints;
	int cur = 0;
	public float m_speed = .03f;
	private Vector3 direction;
	private Quaternion look;
	public Transform player;
	float speed = 1f;

	//bool inArea;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Player.inArea == false ) {


			if (transform.position != waypoints [cur].position) {
				Vector3 p = Vector3.MoveTowards (transform.position,
					waypoints [cur].position,
					m_speed);
				GetComponent<Rigidbody> ().MovePosition (p);
			} else {
				cur = (cur + 1) % waypoints.Length;
			}
			//transform.LookAt (waypoints [cur].position);
			direction = (waypoints [cur].position - transform.position).normalized;
			look = Quaternion.LookRotation (direction);
			transform.rotation = Quaternion.Slerp (transform.rotation, look, Time.deltaTime * 2.0f);
		}
		//} 
		else if(Player.inArea == true) {
			//	GameObject player = GameObject.FindGameObjectWithTag ("Player");
			Vector3 toTarget = player.transform.position - transform.position;
			transform.LookAt(player);

			transform.position += transform.forward * speed *Time.deltaTime;
		}
		//

	}

}

