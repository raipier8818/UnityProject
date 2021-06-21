using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public Status status;

    SpriteRenderer PlayerSpriteRenderer;
    Rigidbody2D PlayerRigidbody;
    Animator PlayerAnimator;
    void Awake()
    {
        status.STATE = "Idle";
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
        PlayerRigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate(){

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Horizontal")){
            moveHorizontal();   
        }
        else{
            if(Time.timeScale != 0){
                stopHorizontal();
            }
        }

        if(Input.GetButtonDown("Jump")){
            moveVertical();
        }

        moveAnimation();
    }

    void moveAnimation(){
        if(PlayerRigidbody.velocity.y < 0){
            PlayerAnimator.SetBool("JumpUp", false);
            PlayerAnimator.SetBool("JumpDown", true);
        }
        if(PlayerRigidbody.velocity.y > 0){
            PlayerAnimator.SetBool("JumpUp", true);
            PlayerAnimator.SetBool("JumpDown", false);
        }

        if(PlayerAnimator.GetBool("JumpUp") || PlayerAnimator.GetBool("JumpDown") || PlayerRigidbody.velocity.y != 0){
            PlayerAnimator.SetBool("IsRunning", false);
            return;
        }

        if(PlayerRigidbody.velocity.x == 0 && PlayerRigidbody.velocity.y == 0){
            PlayerAnimator.SetBool("IsRunning", false);
        }
        if(PlayerRigidbody.velocity.x != 0 && PlayerRigidbody.velocity.y == 0){
            PlayerAnimator.SetBool("IsRunning", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "Floor"){
            Debug.Log("Floor Collision");
            PlayerAnimator.SetBool("JumpUp", false);
            PlayerAnimator.SetBool("JumpDown", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {

    }

    void idle(){
        PlayerAnimator.SetBool("JumpUp", false);
        PlayerAnimator.SetBool("JumpDown", false);
        PlayerAnimator.SetBool("IsRunning", false);
    }

    void moveHorizontal(){
        if(GameManager.instance.currentState != GameState.inGame) return;

        float movement = Input.GetAxis("Horizontal");
        if(movement > 0){
            PlayerSpriteRenderer.flipX = false;
            PlayerRigidbody.velocity = new Vector2(movement*status.SPEED, PlayerRigidbody.velocity.y);
        }else if(movement < 0){
            PlayerSpriteRenderer.flipX = true;
            PlayerRigidbody.velocity = new Vector2(movement*status.SPEED, PlayerRigidbody.velocity.y);
        }
    }


    void stopHorizontal(){
        PlayerAnimator.SetBool("IsRunning", false);
        PlayerRigidbody.velocity = new Vector2(0,PlayerRigidbody.velocity.y);
    }

    void moveVertical(){
        if(GameManager.instance.currentState != GameState.inGame) return;
        
        if(PlayerAnimator.GetBool("JumpUp") || PlayerAnimator.GetBool("JumpDown")) return;

        PlayerRigidbody.AddForce(new Vector2(0, status.JUMP), ForceMode2D.Impulse);
        Debug.Log("Jump");
    }


    public bool setName(string name){
        if(name == null) return false;
        
        status.NAME = name;
        return true;
    }

    public string getName(){
        return status.NAME;
    }
}
