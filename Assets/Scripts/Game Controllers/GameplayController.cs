using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour{
  
    public void MoveLeft(){
        Debug.Log("levo");
        PlayerMovement.move = -1;
    }

    public void MoveRight(){
        Debug.Log("desno");
        PlayerMovement.move = 1;
    }

    public void Idle(){
        PlayerMovement.move = 0;
    }
}
