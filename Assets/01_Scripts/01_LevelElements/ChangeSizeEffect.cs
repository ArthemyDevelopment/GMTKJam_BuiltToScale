using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSizeEffect : CharacterEffects
{
    [SerializeField] private Vector3 ScaleToSet;
    
    public override void OnEffect()
    {
        G_Character.transform.localScale = ScaleToSet;
    }
}
