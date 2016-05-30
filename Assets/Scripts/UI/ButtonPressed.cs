using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    [SerializeField] private float xScale = 0.9f;
    [SerializeField] private float yScale = 0.9f;
    [SerializeField] private float scaleTime = 0.8f;
    [SerializeField] private float scaleBackTime = 0.2f;

    void Start() { }

    public void OnPointerDown(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(xScale, yScale, 0), "time", scaleTime));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(1, 1, 0), "time", scaleBackTime));
    }
}
