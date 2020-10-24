using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour{

    public float min_X = -2f, max_X = 2f, min_Y = -6f, max_Y = 6f;

    void Update(){
        CheckBounds();
    }

    void CheckBounds() {
        Vector2 temp = transform.position;
        bool bounds = false;

        if (temp.x > max_X) 
            temp.x = max_X;
        
        if (temp.x < min_X)
            temp.x = min_X;
        
        transform.position = temp;

        if (temp.y <= min_Y){ 
            if(!bounds){
                bounds = true;
                GameManager.instance.RestartAfterTime();
            }
        }
        if (temp.y >= max_Y){
            if (!bounds){
                bounds = true;
                GameManager.instance.RestartAfterTime();
            }
        } 
    }
}
