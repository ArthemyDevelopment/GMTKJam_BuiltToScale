using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReordeableElementToWorldPosition : MonoBehaviour
{


    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(transform.localPosition);

        target.transform.position = worldPosition;
        
        Debug.Log(worldPosition);
    }
}
