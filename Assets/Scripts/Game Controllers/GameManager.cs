using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] players;

    [HideInInspector]
    public int index;

    public static bool dead = false;

    void Awake(){
        MakeSingleton();
    }

    void OnEnable(){
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode){
        if (SceneManager.GetActiveScene().name == "Gameplay"){
            Instantiate(players[index], new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    void MakeSingleton(){
        if (instance != null){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /*public void RestartGame(){
        Invoke("RestartAfterTime", 1f);
    }*/

    public void RestartAfterTime(){
        dead = true;
        ShopController.FullCoins += Timer.Coins;
        //Debug.Log("FullCoins: " + Timer.FullCoins);
        //Timer.FullCoinsTXT = Timer.FullCoins.ToString();
        PlayerPrefs.SetInt("FullCoins", ShopController.FullCoins);
        //PlayerPrefs.SetString("FullCoinsTXT", Timer.FullCoinsTXT);
        //FindObjectOfType<AudioManager>().Play("GameOver");
        SceneManager.LoadScene("Gameover");
    }
}
