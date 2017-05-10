using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishedLevelChecker : MonoBehaviour
{
    
	public Animation opendoor;
	private bool hasKey;
	// Use this for initialization
	void Start ()
	{
		hasKey = false;
        

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.FindGameObjectWithTag ("Key") == null && hasKey == false) {
			hasKey = true;
			OpenDoor ();
           
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (hasKey == true) {
			print("You beat the level!");
			if (PlayerPrefs.GetInt ("CurLevel") <= SceneManager.GetActiveScene ().buildIndex) {
				PlayerPrefs.SetInt ("CurLevel", PlayerPrefs.GetInt ("CurLevel") + 1);
			} 
			Debug.Log (PlayerPrefs.GetInt ("CurLevel"));
			SceneManager.LoadScene ("MainMenu");
		}
	}

	void OpenDoor ()
	{
		gameObject.GetComponent<Animation> ().Play ();
	}
}
