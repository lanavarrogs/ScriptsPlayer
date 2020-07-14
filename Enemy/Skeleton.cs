using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamagable
{
    public int Health {get;set;}
    public override void Init(){
        Health = base.health;
        base.Init();
    }

    public void Damage(){
        Health--;
        anim.SetTrigger("Hit");
        if(Health < 1){
            Destroy(this.gameObject);
        }
    }
}
