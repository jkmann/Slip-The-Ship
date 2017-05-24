using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Basic/easy level AI */

public class MrGrey : MonoBehaviour
{

	/* Waypoints for alien to travel to */
	public Transform[] waypoints;

	/* Current waypoint */
	int cur = 0;

	/* Control the enemy speed */
	public float m_speed = .03f;

	/* Current direction that the alien is facing */
	private Vector3 direction;

	/* Change direction */
	private Quaternion look;

	void Start ()
	{

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		
		if (transform.position != waypoints [cur].position) {
			Vector3 p = Vector3.MoveTowards (transform.position,
				             waypoints [cur].position,
				             m_speed);
			GetComponent<Rigidbody> ().MovePosition (p);
		} else {
			cur = (cur + 1) % waypoints.Length;
		}
		direction = (waypoints [cur].position - transform.position).normalized;
		look = Quaternion.LookRotation (direction);
		transform.rotation = Quaternion.Slerp (transform.rotation, look, Time.deltaTime * 2.0f);


			

	}

}