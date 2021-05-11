using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
   public void PlayGame()
    {
        Level.LevelNum = 1;
        SceneManager.LoadScene("Main");
    }

    public void PlayLevel2()
    {
        Level.LevelNum = 2;
        SceneManager.LoadScene("Main");
    }

    public void PlayLevel3()
    {
        Level.LevelNum = 3;
        SceneManager.LoadScene("Main");
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

}
