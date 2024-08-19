using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnAndOff : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    
    public void Trigger()
    {
        Door.SetActive(!Door.activeSelf);
    }
}
