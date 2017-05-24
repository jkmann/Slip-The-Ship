using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Script to control functionality of pause menu */

public class PauseMenu : MonoBehaviour
{

	/* Pause menu */
	public Transform canvas;

	public Button pauseButton;
	public Button returnToMenu;
	public Button resumeButton;

	void Start ()
	{
		pauseButton.onClick.AddListener (() => PauseOptions ());
		returnToMenu.onClick.AddListener (() => ReturnToMainMenu ());
		resumeButton.onClick.AddListener (() => ResumePlay ());
	}

	void Update ()
	{
		
	}


	void PauseOptions ()
	{
		canvas.gameObject.SetActive (true);
		Time.timeScale = 0;
	}

	void ReturnToMainMenu ()
	{
		SceneManager.LoadScene (0);
		Time.timeScale = 1;

	}

	void ResumePlay ()
	{
		canvas.gameObject.SetActive (false);	
		Time.timeScale = 1;
	}
}