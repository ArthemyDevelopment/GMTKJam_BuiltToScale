using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCharsController : SingletonManager<OrderCharsController>
{
    [SerializeField] private Transform StartRef;
    [SerializeField] private Transform EndRef;
    
    public float ConvertPosition(float mousePos, float maxPos)
    {
        float newPos = ScriptsTools.MapValues(mousePos, 0, maxPos, StartRef.localPosition.x,EndRef.localPosition.x);
        
        
        /*Debug.Log("mousePos: " + mousePos +"\n"+
                  "NewPos: " + newPos +"\n"+
                  "MaxPos: " + maxPos +"\n" +
                  "StartRef: " + StartRef.localPosition.x + "\n" +
                  "EndRef: " + EndRef.localPosition.x + "\n");*/
        
        
        return newPos;
        
        
    }
}
