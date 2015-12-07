﻿using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    static public int levelIndex = 0;
    //private string[] scenesNames;
	private static string lastScene;

	static public string getLastScene()
	{
		return lastScene;
	}

	static public void setLastScene(string level)
	{
		lastScene = level;
	}

	public void RestartLevel()
	{
		Application.LoadLevel (LevelController.getLastScene());
	}

    static public void ChangeLevel()
    {
		if (Application.loadedLevel == 3) 
			Application.LoadLevel ("WinScene");
        Application.LoadLevel(Application.loadedLevel +1);

        Debug.Log("Level index: " + Application.loadedLevel);
    }
}

