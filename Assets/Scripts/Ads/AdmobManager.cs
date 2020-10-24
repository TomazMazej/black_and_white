using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour{

    private InterstitialAd interstitial;

    private void Awake(){
        RequestInterstitial();
    }

    void FixedUpdate(){
        if (this.interstitial.IsLoaded()){
            this.interstitial.Show();
        }
    }

    private void RequestInterstitial(){ //ca-app-pub-3940256099942544/1033173712
        #if UNITY_ANDROID
             string adUnitId = "ca-app-pub-4585950872793310/9730897393"; 
        #elif UNITY_IPHONE
             string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
}
