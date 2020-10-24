using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private Rigidbody2D myBody;
    public float moveSpeed = 10f;
    public static int move = 0;

    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        myBody.velocity = default(Vector2);
    }

    void FixedUpdate(){ //funkcija se znova in znova kliče
        Move();
    }

    void Move(){
        if (move > 0f)  //če je spremenljivka večja od 0 gre levo, če pa manjša pa desno
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        else if (move < 0f)
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        //else myBody.velocity = new Vector2(0, myBody.velocity.y);
    }

    public void PlatformMove(float x){ //dodamo hitrost stopnici
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}


