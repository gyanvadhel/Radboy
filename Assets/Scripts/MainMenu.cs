using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingMenu()
    {
        SceneManager.LoadScene("ControlsMenu");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SureQuit()
    {
        SceneManager.LoadScene("Quit");   
    }
}
