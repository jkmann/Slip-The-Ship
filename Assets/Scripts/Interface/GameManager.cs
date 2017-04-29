using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;
	public int current = 0;
	public bool[] hasBeatLevel;
	public Button[] levelButtons;
	public int counter;
	public Button reset;



	void Awake ()
	{
		redoButtons ();
		reset.onClick.AddListener (() => ResetProgress ());
	}

	// Use this for initialization
	void Start ()
	{
		reset.onClick.AddListener (() => ResetProgress ());

		redoButtons ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ResetProgress ()
	{
		PlayerPrefs.SetInt ("deaths", 0);
		PlayerPrefs.SetInt ("CurLevel", 0);
		redoButtons ();
	}

	public void redoButtons ()
	{

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
}
