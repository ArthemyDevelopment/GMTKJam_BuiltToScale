using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelButtonTrigger : MonoBehaviour
{
    public UnityEvent OnTrigger = new UnityEvent();

    [SerializeField] private bool SingleTrigger;
    [SerializeField] private bool AlreadyTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerEnergyTrigger"))
        {
            if (AlreadyTrigger) return;
            OnTrigger?.Invoke();
            AlreadyTrigger = SingleTrigger;

        }
    }
}
