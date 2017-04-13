using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaY = Input.GetAxis ("Vertical") * speed;
		Vector3 newPosition = transform.position;
		newPosition.x += deltaX * Time.deltaTime;
		newPosition.z += deltaY * Time.deltaTime;
		transform.position = newPosition;
	}
}
