using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    static public int levelIndex = 0;
    private string[] scenesNames;


    static public void ChangeLevel()
    {

        
        Application.LoadLevel(Application.loadedLevel +1);

        Debug.Log("Level index: " + Application.loadedLevel);

    }
}

