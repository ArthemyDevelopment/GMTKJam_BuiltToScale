using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CharController : MonoBehaviour
{
    private HorizontalMovement HM_Movement;
    private CharCollisionsDetections CCD_Collisions;
    private AnimsController AC_Animations;
    [SerializeField] private Vector3 startSize;


    private void Start()
    {
        Init();
    }


    private void Init()
    {
        HM_Movement = GetComponent<HorizontalMovement>();
        CCD_Collisions = GetComponentInChildren<CharCollisionsDetections>();
        AC_Animations= GetComponent<AnimsController>();
        
        CCD_Collisions.OnHitWall.AddListener(HM_Movement.ChangeMoveDirection);
        CCD_Collisions.OnHitWall.AddListener(AC_Animations.ChangeDirection);
        CCD_Collisions.OnFalling.AddListener(HM_Movement.OnFall);
        CCD_Collisions.OnFalling.AddListener(AC_Animations.PlayFalling);
        CCD_Collisions.OnHitFloor.AddListener(HM_Movement.OnLand);
        CCD_Collisions.OnHitFloor.AddListener(AC_Animations.PlayWalking);

        LevelManager.current?.AddLevelChar(this);

    }

    public void StopChar()
    {
        HM_Movement.StopMovement();
        AC_Animations.PlayStop();
    }

    public void PlayChar()
    {
        transform.parent = null;
        transform.localScale = startSize;
        HM_Movement.StartMovement();
        AC_Animations.PlayFalling();
    }



}
