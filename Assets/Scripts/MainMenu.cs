using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
  public AudioSource audioSource;

    public void PlayGame()
    {
        SceneManager.LoadScene("Start");
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

    public void Buttons()
    {
        audioSource.Play();
    }    
}