using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

    public Text DisplayCoins;
    public static int FullCoins;
    bool[] locked = {false, true, true, true, true, true};
    int[] prices = {0, 10, 100, 200, 500, 1000};

    void Start(){
        FullCoins = PlayerPrefs.GetInt("FullCoins", FullCoins);

        for (int i = 1; i < 6; i++){
            locked[i] = PlayerPrefsX.GetBoolArray("locked")[i];
        }

        for (int i = 1; i < 6; i++){
            if (locked[i] == false){
                GameObject image = GameObject.FindGameObjectWithTag(i.ToString());
                Destroy(image.gameObject);
            }
        }
    }

    void Update(){
        DisplayCoins.text = FullCoins.ToString();
        PlayerPrefs.SetInt("FullCoins", FullCoins);
        PlayerPrefsX.SetBoolArray("locked", locked);
    }

    public void SelectCharacter() {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (locked[int.Parse(name)] == false){
            FindObjectOfType<AudioManager>().Play("Button");
            GameManager.instance.index = int.Parse(name);
            SceneManager.LoadScene("Gameplay");
        }

        if (locked[int.Parse(name)] == true && FullCoins >= prices[int.Parse(name)]){
            FullCoins = FullCoins - prices[int.Parse(name)];
            locked[int.Parse(name)] = false;
            FindObjectOfType<AudioManager>().Play("Purchase");
            GameObject image = GameObject.FindGameObjectWithTag(name);
            Destroy(image.gameObject);
        }
    }

    public void GoToMainMenu(){
        FindObjectOfType<AudioManager>().Play("Button");
        SceneManager.LoadScene("Main Menu");
    }
}
