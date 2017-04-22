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
	bool hasKey = false;
	Color myColor = new Color (0f, 1f, 0f, 1f);


	void Awake ()
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		PlayerPrefs.SetInt ("CurLevel", 4);

		if (PlayerPrefs.GetInt("CurLevel") == 0) {
			for (int i = 1; i < levelButtons.Length; i++) {
				levelButtons [i].interactable = false;
			}
		} else {
			for (int j = 0; j <= PlayerPrefs.GetInt("CurLevel"); j++) { 
				Button button = levelButtons [j];
				Text text = button.GetComponentInChildren<Text> ();
				levelButtons [j].onClick.AddListener (() => LoadALevel (text.text));
			}
			for (int i = PlayerPrefs.GetInt("CurLevel"); i < levelButtons.Length; i++) {
				levelButtons [i].interactable = false;
			}

		}

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
		if (PlayerPrefs.GetInt("CurLevel") == 0) {
			for (int i = 1; i < levelButtons.Length; i++) {
				levelButtons [i].interactable = false;
			}
		} else {
			for (int j = 0; j <= PlayerPrefs.GetInt("CurLevel"); j++) { 
				Button button = levelButtons [j];
				Text text = button.GetComponentInChildren<Text> ();
				levelButtons [j].onClick.AddListener (() => LoadALevel (text.text));
			}
			for (int i = PlayerPrefs.GetInt("CurLevel"); i < levelButtons.Length; i++) {
				levelButtons [i].interactable = false;
			}

		}
	}

	public void LoadALevel (string name)
	{
		Debug.Log (name);
		SceneManager.LoadScene (name);
	}
}
