using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HS : MonoBehaviour {

    public Text HSText;
  
	void Update (){
        HSText.text = Timer.HighScoreTXT;
    }
}
