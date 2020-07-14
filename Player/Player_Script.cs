                                                                                                                                                                                                                                                                                                using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float jump = 5.5f;
    [SerializeField]
    private float speed = 2.5f;
    [SerializeField]
    private Transform checkpoint;
    private bool flip = true;
    
    private  PlayerAnimation  playerAnimation;
    private SpriteRenderer playerSprite,swordSprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        IdleToJumping();
        Attack();
        Reset();
    }   

    void Movement(){
        //Movimiento en el eje x 
        float move = Input.GetAxisRaw("Horizontal");
        if(move>0){
            flip = true;
        }else if(move <0){
            flip = false;
        }
        Flip(flip);
        rb.velocity = new Vector2(move * speed,rb.velocity.y);
        playerAnimation.Move(move);
    }

    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()){
            rb.velocity = new Vector2(rb.velocity.x,jump);
        }   
    }

    bool IsGrounded(){
        if(Physics2D.Raycast(transform.position,Vector2.down,1.8f, 1 << 8)){
            return true;
            playerAnimation.Jumping(false);
        }
            return false;
    }

    void Flip(bool faceRight){
        if(faceRight == true){
            //Se vea el jugar a la derecha
            playerSprite.flipX = false;
            //Mover el ataque de la espada a la derecha
            swordSprite.flipX = false;
            swordSprite.flipY = false;

        }else if(faceRight == false){
            //Se vea el jugador a la izquierda
            playerSprite.flipX = true;
            //Mover el ataque de la espada a la izquierda
            swordSprite.flipX = true;
            swordSprite.flipY = true;
        }
    }

    //Cambiar la animacion de salto
    void IdleToJumping(){
        if(IsGrounded()){
            playerAnimation.Jumping(false); 
        }else{
            playerAnimation.Jumping(true);
        }
    }

    //
    void Attack(){
        if((Input.GetMouseButton(0) || Input.GetButton("Fire1")) && IsGrounded()){
            playerAnimation.Attack();
        }
    }

    void Reset(){
        if(Input.GetKeyDown(KeyCode.R)){
            transform.position = checkpoint.position;
        }
    }

}

