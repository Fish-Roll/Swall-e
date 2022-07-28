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
    [SerializeField] private AudioSource jumpSound;
    private Movement _movement;
    private IEnumerator JumpEf;
    public float jumpCurrentTime;
    private int maxCountJump = 2;
    
    public override void Activate(GameObject obj)
    {
        _movement = obj.GetComponent<Movement>();
        if (!_movement.grounded && _movement.countJump < maxCountJump && jumpEffect!=null)
        {
            jumpSound.Play();
            StartCoroutine("JumpEffect");
            //playerAnimator.SetTrigger("jump");
        }
    }
    private IEnumerator JumpEffect()
    {
        jumpCurrentTime = 0;
        jumpEffect.SetActive(true);
        _movement.Jump();
        while (true)
        {
            jumpCurrentTime += Time.deltaTime;
            if (jumpCurrentTime >= jumpEffectTime)
            {
                jumpEffect.SetActive(false);
                StopCoroutine("JumpEffect");
            }
            yield return null;
        }
    }
}