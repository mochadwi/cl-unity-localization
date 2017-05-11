using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LocalizedTextEditor : EditorWindow {

	public LocalizationData localizationData;

	[MenuItem("Window/Localized Text Editor")]
	static void Init()
	{
		EditorWindow.GetWindow(typeof(LocalizedTextEditor)).Show();
	}

	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// This function can be called multiple times per frame (one call per event).
	/// </summary>
	private void OnGUI()
	{
		if (localizationData != null)
		{
			SerializedObject serializedObject = new SerializedObject(this);
			SerializedProperty serializedProperty = serializedObject.FindProperty("localizationData");
			EditorGUILayout.PropertyField(serializedProperty, true);
			serializedObject.ApplyModifiedProperties();

			if (GUILayout.Button("Save data"))
			{
				SaveLocalizedData();
			}
		}

		if (GUILayout.Button("Load data"))
		{
			LoadLocalizedData();
		}

		if (GUILayout.Button("Create new data"))
		{
			CreateLocalizedData();
		}
	}

	private void LoadLocalizedData()
	{
		string filePath = EditorUtility.OpenFilePanel("Select localization data file", Application.streamingAssetsPath, "json");

		if (!string.IsNullOrEmpty(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath);
			localizationData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
		}
	}

	private void SaveLocalizedData()
	{
		string filePath = EditorUtility.SaveFilePanel("Save localization data file", Application.streamingAssetsPath, "localizedText_",
						 "json");

		if (!string.IsNullOrEmpty(filePath))
		{
			string dataAsJson = JsonUtility.ToJson(localizationData);
			File.WriteAllText(filePath, dataAsJson);
		}
	}

	private void CreateLocalizedData()
	{
		localizationData = new LocalizationData();
	}
}
