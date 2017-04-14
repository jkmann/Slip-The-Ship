using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MrGrey : MonoBehaviour {

	public Transform[] waypoints;
	int cur = 0;
    float m_speed = .03f;
	private Vector3 m_initialposition;
	private Animator m_animator;

	// Use this for initialization
	void Start () {
		m_initialposition = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position != waypoints [cur].position) {
			Vector3 p = Vector3.MoveTowards (transform.position,
				waypoints [cur].position,
				m_speed);
			GetComponent<Rigidbody> ().MovePosition (p);
		} else
			cur = (cur + 1) % waypoints.Length;
		
	}



}
