using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;

public class ReordableElement : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public RectTransform currentTransform;
    private GameObject mainContent;
    private Vector3 currentPosition;


    private void OnEnable()
    {
        currentTransform = GetComponent<RectTransform>();
    }

    private int totalChild;

    public void OnPointerDown(PointerEventData eventData)
    {
        currentPosition = currentTransform.localPosition;
        mainContent = currentTransform.parent.gameObject;
        totalChild = mainContent.transform.childCount;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currentTransform.localPosition =
            new Vector3(OrderCharsController.current.ConvertPosition(Input.mousePosition.x, Screen.width), currentTransform.localPosition.y, currentTransform.localPosition.z);

        for (int i = 0; i < totalChild; i++)
        {
            if (i != currentTransform.GetSiblingIndex())
            {
                Transform otherTransform = mainContent.transform.GetChild(i);
                int distance = (int) Vector3.Distance(currentTransform.localPosition, otherTransform.localPosition);
                if (distance <= 10)
                {
                    Vector3 otherTransformOldPosition = otherTransform.localPosition;
                    otherTransform.localPosition = new Vector3(currentPosition.x, otherTransform.localPosition.y, otherTransform.localPosition.z);
                    currentTransform.localPosition = new Vector3(otherTransformOldPosition.x, currentTransform.localPosition.y, currentTransform.localPosition.z);
                    currentTransform.SetSiblingIndex(otherTransform.GetSiblingIndex());
                    currentPosition = currentTransform.localPosition;
                }
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        currentTransform.localPosition = currentPosition;
    }
}
