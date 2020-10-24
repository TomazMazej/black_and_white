using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour{

    public Text CoinsText;

    void Update() {
        CoinsText.text = Timer.CoinsTXT;
    }
}
