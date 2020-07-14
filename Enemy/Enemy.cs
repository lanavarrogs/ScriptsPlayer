using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA,pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;


    public virtual void Init(){
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Start(){
        Init();
    }

    public virtual void Update(){
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            return;
        }
        Movement();
    }

    public virtual void Movement(){

        if(transform.position == pointA.position){
                sprite.flipX = false;
                currentTarget = pointB.position;
                anim.SetTrigger("Idle");
            }else if(transform.position == pointB.position){
                anim.SetTrigger("Idle");
                currentTarget = pointA.position;
                sprite.flipX = true;     
            }
            transform.position = Vector3.MoveTowards(transform.position,currentTarget,speed * Time.deltaTime);
        }
}
    

