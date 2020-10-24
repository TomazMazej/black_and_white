using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;

    public static float Score;
    public static float HighScore = 0;
    public static string HighScoreTXT = "0:00";
    public static int Coins = 0;
    public static string CoinsTXT = "0";

    private float m;
    private float s;
    public static string minutes;
    public static string seconds;

    void Start (){
        GameManager.dead = false;
        startTime = Time.time;
        HighScore = PlayerPrefs.GetFloat("HighScore", HighScore);
        HighScoreTXT = PlayerPrefs.GetString("HighScoreTXT", HighScoreTXT);
        ShopController.FullCoins = PlayerPrefs.GetInt("FullCoins", ShopController.FullCoins);
    }

    void Update(){
        if (GameManager.dead){
            return;
        }

        Coins = (int)Score/5;
        Debug.Log(Coins);
        CoinsTXT = Coins.ToString();

        float t = Time.time - startTime;

        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f0");

        m = ((int)t / 60);
        s = (t % 60);

        if (int.Parse(seconds) < 10){
            seconds = "0" + seconds;
        }

        if (int.Parse(seconds) == 60){
            minutes = (m+1).ToString();
            seconds = "00";
        }

        timerText.text = minutes + ":" + seconds;

        Score = m * 60 + s;

        if (Score > HighScore){
            HighScore = Score;
            HighScoreTXT = minutes + ":" + seconds;
            PlayerPrefs.SetFloat("HighScore", HighScore);
            PlayerPrefs.SetString("HighScoreTXT", HighScoreTXT);
            Leaderboards.instance.AddScoreToLeaderboard(GPGSIds.leaderboard_score_leaderboard, (long)HighScore);
        }
    }
}
