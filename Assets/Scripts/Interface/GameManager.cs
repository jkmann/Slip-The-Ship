using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	//public static GameManager instance = null;
	public int current = 0;
	public bool[] hasBeatLevel;
	public Button[] levelButtons;
	public int counter;
	public Button reset;
	public Button playButton;
	public Button returnButton;
	public Text currentLevel;
	public Transform startScreen;
	public Transform selectScreen;

	void Awake ()
	{
		redoButtons ();
		reset.onClick.AddListener (() => ResetProgress ());
		currentLevel.text = "Level: " + PlayerPrefs.GetInt ("CurLevel");
		playButton.onClick.AddListener (() => SwitchScreen ());
		returnButton.onClick.AddListener (() => ReturnScreen ());
	}

	// Use this for initialization
	void Start ()
	{
		reset.onClick.AddListener (() => ResetProgress ());
		redoButtons ();
		playButton.onClick.AddListener (() => SwitchScreen ());
		returnButton.onClick.AddListener (() => ReturnScreen ());

	}
	
	// Update is called once per frame
	void Update ()
	{
		currentLevel.text = "Level: " + PlayerPrefs.GetInt ("CurLevel");


	}

	public void ResetProgress ()
	{
		PlayerPrefs.SetInt ("deaths", 0);
		PlayerPrefs.SetInt ("CurLevel", 0);
		redoButtons ();
	}

	public void redoButtons ()
	{
		if (PlayerPrefs.GetInt ("CurLevel") >= 10) {
			PlayerPrefs.SetInt ("CurLevel", 9);		
		}
			for (int j = 0; j <= PlayerPrefs.GetInt("CurLevel"); j++) { 
				Button button = levelButtons [j];
				Text text = button.GetComponentInChildren<Text> ();
				levelButtons [j].onClick.AddListener (() => LoadALevel (text.text));
			}
			for (int i = PlayerPrefs.GetInt("CurLevel") + 1; i < levelButtons.Length; i++) {
				levelButtons [i].interactable = false;
			}


	}

	public void LoadALevel (string name)
	{
		Debug.Log (name);
		SceneManager.LoadScene (name);
	}

	public void SwitchScreen()
	{

		startScreen.gameObject.SetActive (false);
		selectScreen.gameObject.SetActive (true);

	}
	public void ReturnScreen()
	{

		startScreen.gameObject.SetActive (true);
		selectScreen.gameObject.SetActive (false);

	}
}
