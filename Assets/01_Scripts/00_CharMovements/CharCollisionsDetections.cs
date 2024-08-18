using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CharCollisionsDetections : MonoBehaviour
{

    public UnityEvent OnHitWall = new UnityEvent();
    public UnityEvent OnHitFloor=new UnityEvent();
    public UnityEvent OnFalling= new UnityEvent();
    [SerializeField]private bool IsFalling;
    private bool CanDetect = true;
    private bool IsInFloor;
    public void StopDetections()
    {
        IsFalling = false;
        CanDetect = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!CanDetect) return;
        
        if (other.CompareTag("Wall"))
            OnHitWall?.Invoke();

        if (other.CompareTag("Floor") && IsFalling)
        {
            OnHitFloor?.Invoke();
            IsFalling = false;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!CanDetect) return;

        if (IsInFloor) return;
        
        if (other.CompareTag("Floor") && !IsFalling)
        {
            OnFalling?.Invoke();
            IsFalling = true;
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsFalling && other.CompareTag("Floor"))
        {
            OnHitFloor?.Invoke();
            IsFalling = false;
        }
    }

}
