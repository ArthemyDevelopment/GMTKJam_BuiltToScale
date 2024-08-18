using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            LevelManager.current.CharReachGoal();
            var charCont = LevelManager.current.GetCharController(col.gameObject);
            charCont.StopChar();
        }
    }
}
