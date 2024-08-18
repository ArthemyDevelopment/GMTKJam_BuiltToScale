using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimsController : MonoBehaviour
{
    enum AnimState
    {
        Idle,
        Walk,
        Fall
    }

    private AnimState animState;
    
    
    private Animator anim;
    private SpriteRenderer renderer;
    private bool isMirror;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        renderer= GetComponent<SpriteRenderer>();
        isMirror = renderer.flipX;
    }

    public void Update()
    {
        
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == animState.ToString()) return;
        
        switch (animState)
        {
            case AnimState.Idle:
                anim.SetTrigger("Idle");
                break;
            case AnimState.Walk:
                anim.SetTrigger("Walk");
                break;
            case AnimState.Fall:
                anim.SetTrigger("Fall");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    public void PlayFalling() { animState = AnimState.Fall; }

    public void PlayWalking() { animState = AnimState.Walk; }

    public void PlayStop() { animState = AnimState.Idle; }

    public bool IsCharMirror() { return isMirror; } 
    
    public void ChangeDirection()
    {
        renderer.flipX = !isMirror;
        isMirror = renderer.flipX;
    }

}
