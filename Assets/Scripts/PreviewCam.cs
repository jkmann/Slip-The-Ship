using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewCam : MonoBehaviour {

	public Camera mainCamera;
	public Camera previewCam;
	public Camera tempCam;
	//mainCamera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
	//previewCam = GameObject.FindWithTag ("previewCam").GetComponent<Camera>();
	//GameObject g = GameObject.FindWithTag("cameraSwitch").GetComponent<Camera>();
	//MeshRenderer m = GameObject.FindGameObjectWithTag("cameraSwitch").GetComponent<MeshRenderer>();
	//MeshRenderer m = g.GetComponent<MeshRenderer> ();
	//RenderTexture r = m;
	//RenderTexture r = PreviewCam.previewCam.targetTexture;
	//public Button cameraSwitch;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera>();
		tempCam = GameObject.FindWithTag ("temp").GetComponent<Camera>();
		previewCam = GameObject.FindWithTag ("previewCam").GetComponent<Camera>();
		mainCamera.targetTexture = null;

		tempCam.targetTexture = previewCam.targetTexture;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1")){
			if (mainCamera.targetTexture == null) {
				mainCamera.targetTexture = tempCam.targetTexture;
			} else {
				mainCamera.targetTexture = null;

			}

			if (previewCam.targetTexture == null) {
				previewCam.targetTexture = tempCam.targetTexture;
			} else {
				previewCam.targetTexture = null;
			}
		}
	}

	/*void MouseUp(){
		if (mainCamera.targetTexture == null) {
			mainCamera.targetTexture = tempCam.targetTexture;
		} else {
			mainCamera.targetTexture = null;

		}

		if (previewCam.targetTexture == null) {
			previewCam.targetTexture = tempCam.targetTexture;
		} else {
			previewCam.targetTexture = null;
		}
	}*/

}
