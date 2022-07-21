using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure;
using UnityEngine;

public class SecondJumpAbility : Ability
{
    private int maxCountJump = 2;
    public override void Activate(GameObject obj)
    {
        Movement movement = obj.GetComponent<Movement>();
        Debug.Log("Grounded: " + movement.grounded + " countJump: " + movement.countJump);
        
        if(!movement.grounded && movement.countJump < maxCountJump)
            movement.Jump();
    }
}
