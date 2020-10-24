using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour{
    public float move_Speed = 1f; //hitrost
    public float bound_Y = 6f; //do kam lahko gre

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform; //katera platforma je

    private Animator anim;

    void Awake(){
        if (is_Breakable){
            anim = GetComponent<Animator>();
        }
    }

    void Update(){
        Move();
    }

    void Move(){
        Vector2 temp = transform.position; //se premika navzgor
        temp.y += move_Speed * 1.5f * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= bound_Y){ //izgine ko pride ven iz meje
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate(){
        Invoke("DeactivateGameObject", 0.3f);
    }

    void DeactivateGameObject(){
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target){ //ce pademo na platformo z bodicami
        if (target.tag == "Player"){
            if (is_Spike){
                //target.transform.position = new Vector2(1000f, 1000f);
                GameManager.instance.RestartAfterTime();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D target){
        if (target.gameObject.tag == "Player"){
            FindObjectOfType<AudioManager>().Play("Hit");
            if (is_Breakable){
                anim.Play("Break");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D target){ //za premikajočo platformo
        if (target.gameObject.tag == "Player") {
            if (moving_Platform_Left) {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (moving_Platform_Right){
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }
}
