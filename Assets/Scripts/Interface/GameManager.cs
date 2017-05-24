using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/* This script manages the games progress and main menu */

public class GameManager : MonoBehaviour
{

	/* For Singleton pattern */
	//public static GameManager instance = null;

	/* Level Buttons in scroll view stored in array */
	public Button[] levelButtons;

	/* Button to reset game progress */
	public Button reset;

	/* Button to go to level select screen */
	public Button playButton;

	/* Return to main screen */
	public Button returnButton;

	/* Display the highest current level*/
	public Text currentLevel;

	/* Initial Canvas*/
	public Transform startScreen;

	/* Select Canvas */
	public Transform selectScreen;

	/* Update progress when player returns to the main menu*/
	void Awake ()
	{
		redoButtons ();
		reset.onClick.AddListener (() => ResetProgress ());
		currentLevel.text = "Level: " + PlayerPrefs.GetInt ("CurLevel");
		playButton.onClick.AddListener (() => SwitchScreen ());
		returnButton.onClick.AddListener (() => ReturnScreen ());
	}

	/* Initalize menu when game starts up */
	void Start ()
	{
		reset.onClick.AddListener (() => ResetProgress ());
		redoButtons ();
		playButton.onClick.AddListener (() => SwitchScreen ());
		returnButton.onClick.AddListener (() => ReturnScreen ());

	}
	

	void Update ()
	{
		//Always display the current level
		currentLevel.text = "Level: " + PlayerPrefs.GetInt ("CurLevel");


	}

	/* Reset PlayerPrefs variables to reset progress */
	public void ResetProgress ()
	{
		PlayerPrefs.SetInt ("deaths", 0);
		PlayerPrefs.SetInt ("CurLevel", 0);
		redoButtons ();
	}

	/* Redo buttons given PlayerPrefs variable 'CurLevel' */
	public void redoButtons ()
	{
		//hard coded if check in case player level exceeds the total number of levels
		if (PlayerPrefs.GetInt ("CurLevel") >= 10) {
			PlayerPrefs.SetInt ("CurLevel", 9);		
		}
		for (int j = 0; j <= PlayerPrefs.GetInt ("CurLevel"); j++) { 
			Button button = levelButtons [j];
			Text text = button.GetComponentInChildren<Text> ();
			levelButtons [j].onClick.AddListener (() => LoadALevel (text.text));
		}
		for (int i = PlayerPrefs.GetInt ("CurLevel") + 1; i < levelButtons.Length; i++) {
			levelButtons [i].interactable = false;
		}


	}

	/* Quickly load level based on text/name*/
	public void LoadALevel (string name)
	{
		Debug.Log (name);
		SceneManager.LoadScene (name);
	}

	/* Switich to level select*/
	public void SwitchScreen ()
	{

		startScreen.gameObject.SetActive (false);
		selectScreen.gameObject.SetActive (true);

	}

	/* Switch back to main menu */
	public void ReturnScreen ()
	{

		startScreen.gameObject.SetActive (true);
		selectScreen.gameObject.SetActive (false);

	}
}
