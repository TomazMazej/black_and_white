using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour{

    public void GoToGameplay(){ //gremo na gameplay
        GameManager.instance.index = 0;
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToHelp(){ //gremo na help
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Help");
    }

    public void GoToShop(){ //gremo v shop
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame(){ //ugasnemo igro
        FindObjectOfType<AudioManager>().Play("Button");
        Application.Quit();
    }

    public void ShowLeaderboard(){
        FindObjectOfType<AudioManager>().Play("Button");
        Leaderboards.instance.ShowLeaderboardsUI();
    }
}
