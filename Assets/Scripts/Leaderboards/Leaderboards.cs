using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Leaderboards : MonoBehaviour{

    public static Leaderboards instance;

    private void Awake(){
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start(){
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();
        SignIn();
    }

    private void SignIn(){
        Social.localUser.Authenticate(success => {
            // handle success or failure
        });
    }

    public void AddScoreToLeaderboard(string leaderboardId, long score){
        Social.ReportScore(score, leaderboardId, success => {

        });
    }

    public void ShowLeaderboardsUI(){
        Social.ShowLeaderboardUI();
    }
}