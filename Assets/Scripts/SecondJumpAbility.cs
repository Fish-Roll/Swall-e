using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Assets.Scripts.Infrastructure;
using UnityEngine;

public class SecondJumpAbility : Ability
{
    [SerializeField] private GameObject jumpEffect;
    [SerializeField] private float jumpEffectTime;
    private IEnumerator JumpEf;
    public float jumpCurrentTime;
    private int maxCountJump = 2;
    
    public override void Activate(GameObject obj)
    {
        Movement movement = obj.GetComponent<Movement>();
        if (!movement.grounded && movement.countJump < maxCountJump && jumpEffect!=null)
        {
            JumpEf = JumpEffect(movement);
            StartCoroutine(JumpEf);
            //playerAnimator.SetTrigger("jump");
        }
    }
    private IEnumerator JumpEffect(Movement movement)
    {
        jumpEffect.SetActive(true);
        jumpCurrentTime = 0;
        movement.Jump();
        while (true)
        {
            jumpCurrentTime += Time.deltaTime;
            if (jumpCurrentTime >= jumpEffectTime)
            {
                jumpEffect.SetActive(false);
                StopCoroutine(JumpEf);
            }
            yield return null;
        }
    }
}
