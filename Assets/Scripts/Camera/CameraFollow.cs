using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject player;       
	public float distance;
    private Vector3 offset;        

    // Use this for initialization
    void Start()
    {
		offset = new Vector3 (transform.position.x, transform.position.y, transform.position.z + distance);
        
    }

    
    void Update()
    {
       
		transform.position = player.transform.position + offset;

    }

}
