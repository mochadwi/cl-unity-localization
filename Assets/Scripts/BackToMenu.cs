using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour {

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		LocalizationManager.instance.SetIsReady(false);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PreviousMenu()
	{
		SceneManager.LoadScene("LoadingScreen");
		Debug.Log("Go to previous menu!");
	}
}