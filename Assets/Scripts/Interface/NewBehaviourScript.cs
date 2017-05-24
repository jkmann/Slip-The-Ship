using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script controls lights on doors */

public class NewBehaviourScript : MonoBehaviour {

    public Material[] material;
    public Renderer rend;
    private bool hasKey;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Key") == null && hasKey == false)
        {
            rend.sharedMaterial = material[1];

        }
    }
}
