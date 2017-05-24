using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script controls the moving platforms that the player can jump onto */

public class FloatingBlock : MonoBehaviour
{
	/* Waypoints for block to travel to */
	public Transform[] waypoints;

	/* Current Waypoint */
	int cur = 0;

	/* Public var to control speed */
	public float m_speed = .03f;


	void Start ()
	{
		
	}


	void FixedUpdate ()
	{
		//move towards next waypoint
		if (transform.position != waypoints [cur].position) {
			Vector3 p = Vector3.MoveTowards (transform.position,
				            waypoints [cur].position,
				            m_speed);
			GetComponent<Rigidbody> ().MovePosition (p);
			//return to previous waypoint
		} else {
			cur = (cur + 1) % waypoints.Length;
			print ("moving back");
		}
	}
}
