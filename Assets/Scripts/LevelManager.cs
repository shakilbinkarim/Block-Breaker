using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void LoadLevel(string name)
    {
        Debug.Log("Level Requested:" + name);
        BrickScript.NUMBER_OF_BREAKABLE_BRICKS = 0;
        SceneManager.LoadScene(name);
        ///<summary>
        ///Depricated
        ///</summary>
        //Application.LoadLevel(name); 
    }

    public void QuitRequest()
    {
        Application.Quit();
        Debug.Log("I wanna quit!");
    }

    public void LoadNextLevel()
    {
        BrickScript.NUMBER_OF_BREAKABLE_BRICKS = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyedMessage()
    {
        if (BrickScript.NUMBER_OF_BREAKABLE_BRICKS <= 0)
        {
            LoadNextLevel();
        }
    }

}
