using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script controls the camera to follow the player as he moves */

public class CameraFollow : MonoBehaviour
{

	/* Player */
	public GameObject player;

	/* Public variable to adjust distance */
	public float distance;

	/* offset to change camera position */
	private Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		offset = new Vector3 (transform.position.x, transform.position.y, transform.position.z + distance);
        
	}

    
	void Update ()
	{
       
		transform.position = player.transform.position + offset;

	}

}
