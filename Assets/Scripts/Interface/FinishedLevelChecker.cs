using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishedLevelChecker : MonoBehaviour
{
    
	public Animation opendoor;
	public AudioClip doorSound;
	private bool hasKey;
	public Transform hud;
	public Transform lvlComplete;
	public Button nextLevel;
	public Button returnToMenu;

	// Use this for initialization
	void Start ()
	{
		hasKey = false;
		returnToMenu.onClick.AddListener (() => ReturnToMainMenu ());
		nextLevel.onClick.AddListener (() => goToNextLevel ());

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
			hud.gameObject.SetActive (false);
			lvlComplete.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
	}

	void OpenDoor ()
	{
		gameObject.GetComponent<Animation> ().Play ();
		AudioSource.PlayClipAtPoint (doorSound, Camera.main.transform.position);

	}

	void ReturnToMainMenu()
	{
		SceneManager.LoadScene(0);
		Time.timeScale = 1;

	}

	void goToNextLevel()
	{
		int index = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(index + 1);
		Time.timeScale = 1;
	}		
}
