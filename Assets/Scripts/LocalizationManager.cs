﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour {

	public static LocalizationManager instance;

	private Dictionary<string, string> localizedText;

	private bool isReady = false;

	// Use this for initialization
	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		} else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void LoadLocalizationText(string fileName)
	{
		localizedText = new Dictionary<string, string>();
		string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

		if (File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath);
			LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

			for (int i = 0; i < loadedData.items.Length; i++)
			{
				localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
			}

			Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entreis");
		} else
		{
			Debug.LogError("Cannot find file!");
		}

		isReady = true;
	}

	public bool GetIsReady()
	{
		return isReady;
	}
}
