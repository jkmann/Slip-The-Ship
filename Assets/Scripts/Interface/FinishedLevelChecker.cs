using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Script on door to check whether or not the player has completed the objective */

public class FinishedLevelChecker : MonoBehaviour
{
	/* Bundled door animation */
	public Animation opendoor;

	/* Imported soundclip to match */
	public AudioClip doorSound;

	/* Does the player have the key/objective */
	private bool hasKey;

	/* current hud while playing */
	public Transform hud;

	/* level complete canvas view */
	public Transform lvlComplete;

	/* Button to go to the next level */
	public Button nextLevel;

	/* Button to return to the main menu */
	public Button returnToMenu;


	void Start ()
	{
		//player does not have key
		hasKey = false;
		//initialize buttons
		returnToMenu.onClick.AddListener (() => ReturnToMainMenu ());
		nextLevel.onClick.AddListener (() => goToNextLevel ());

	}

	void Update ()
	{
		//keep checking to see if player has retrieved the key
		if (GameObject.FindGameObjectWithTag ("Key") == null && hasKey == false) {
			hasKey = true;
			OpenDoor ();
           
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (hasKey == true) {
			print ("You beat the level!");
			if (PlayerPrefs.GetInt ("CurLevel") <= SceneManager.GetActiveScene ().buildIndex) {
				PlayerPrefs.SetInt ("CurLevel", PlayerPrefs.GetInt ("CurLevel") + 1);
			} 
			Debug.Log (PlayerPrefs.GetInt ("CurLevel"));
			hud.gameObject.SetActive (false);
			lvlComplete.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
	}

	/* Control door animation and sound */
	void OpenDoor ()
	{
		gameObject.GetComponent<Animation> ().Play ();
		AudioSource.PlayClipAtPoint (doorSound, Camera.main.transform.position);

	}

	/* Return to main menu */
	void ReturnToMainMenu ()
	{
		SceneManager.LoadScene (0);
		Time.timeScale = 1;

	}

	/* Advance to next level */
	void goToNextLevel ()
	{
		int index = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (index + 1);
		Time.timeScale = 1;
	}
}
