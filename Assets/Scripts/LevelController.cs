using UnityEngine;
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

    static public void ChangeLevel(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}

