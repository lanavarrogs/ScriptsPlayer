﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MossGiant : Enemy, IDamagable
{

    public int Health {get; set;}

    public override void Init(){
        Health = base.health;
        base.Init();
    }

    public void Damage(){
        
    }
}
