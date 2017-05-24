using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Controls minimap camera*/

public class MiniMap : MonoBehaviour
{

	/* Player */
	public GameObject player;

	/* Public variable to adjust distance */
	public float distance;

	/* offset to change camera position */
	private Vector3 offset;

	void Start ()
	{
		offset = new Vector3 (transform.position.x, transform.position.y + distance, transform.position.z);
	}

	void Update ()
	{
		transform.position = player.transform.position + offset;
	}
}
