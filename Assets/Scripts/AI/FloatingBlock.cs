using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBlock : MonoBehaviour {

	public Transform[] waypoints;
	int cur = 0;
	public float m_speed = .03f;
	//private Vector3 direction;
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position != waypoints [cur].position) {
			Vector3 p = Vector3.MoveTowards (transform.position,
				waypoints [cur].position,
				m_speed);
			GetComponent<Rigidbody> ().MovePosition (p);
		} else {
			cur = (cur + 1) % waypoints.Length;
			print ("moving back");
		}
	}
}
