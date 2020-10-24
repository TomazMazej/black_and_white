using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HelpController : MonoBehaviour{

    public void MainMenu(){ //gremo v Main menu
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Main Menu");
    }
}
