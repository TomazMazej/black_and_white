using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverController : MonoBehaviour{

    public void RestartGame(){ //gremo v game
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu(){ //gremo v Main menu
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame(){ //ugasnemo igro
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }
}
