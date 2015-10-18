using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    static public int levelIndex;
    private string[] scenesNames;
    // Use this for initialization
    void Awake()
    {
        Application.DontDestroyOnLoad(transform.gameObject);
    }
    void Start()
    {
        levelIndex = 0;
       
    }

    static public void ChangeLevel()
    {

        
        Application.LoadLevel(Application.loadedLevel +1);

        Debug.Log("Level index: " + Application.loadedLevel);

    }
}

