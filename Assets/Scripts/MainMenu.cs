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
        audioSource.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
        audioSource.Play();
    }

    public void SettingMenu()
    {
        SceneManager.LoadScene("ControlsMenu");
        audioSource.Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        audioSource.Play();
    }

    public void SureQuit()
    {
        SceneManager.LoadScene("Quit");
        audioSource.Play();
    }
}
