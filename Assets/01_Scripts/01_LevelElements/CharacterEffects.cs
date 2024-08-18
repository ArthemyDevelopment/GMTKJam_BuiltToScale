using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterEffects : MonoBehaviour
{ 
    [SerializeField] private bool B_UniqueUse;
    protected GameObject G_Character;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            G_Character = col.gameObject;
            OnEffect();
            if(B_UniqueUse) Destroy(this.gameObject);
        }
    }

    public virtual void SetUniqueUse(bool uniqueUse)
    {
        B_UniqueUse = uniqueUse;
    }

    public virtual void OnEffect()
    {
        
    }
}
