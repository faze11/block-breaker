using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadLevelByName(string sceneName)
    {
        print("Loading level " + sceneName);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(sceneName);
    }
    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        print("Quitting...");
        Application.Quit();
    }
}
