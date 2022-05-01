using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{

    [SerializeField] RectTransform wind;
    [SerializeField] Canvas canvas;
    public void OnDrag(PointerEventData eventData)
    {
        wind.anchoredPosition += eventData.delta / canvas.scaleFactor; ;
    }
}
