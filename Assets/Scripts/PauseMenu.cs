using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isMuted = false;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject PauseButton;

    public void ClickedPause()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }


    public void Resume()
    {
        //FindObjectOfType<AudioManager>().Play("Button");
        //FindObjectOfType<AudioManager>().Play("Theme");
        //FindObjectOfType<AudioManager>().StopMusic("PauseMusic");
        PauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        //FindObjectOfType<AudioManager>().Play("Button");
        //FindObjectOfType<AudioManager>().Play("PauseMusic");
        //FindObjectOfType<AudioManager>().StopMusic("Theme");
        PauseButton.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        PauseButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        //PauseButton.SetActive(true);
        //pauseMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Button");
        GameIsPaused = false;
        Application.Quit();
    }

    public void Mute()
    {
        if (AudioListener.pause)//isMuted == true)
        {
            isMuted = false;
            AudioListener.pause = false;
        }
        else
        {
            isMuted = true;
            AudioListener.pause = true;
        }

    }

}