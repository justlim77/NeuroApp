using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] bool reversed = false;
    private float xScale = 0.9f;
    private float yScale = 0.9f;
    private float scaleTime = 0.8f;
    private float scaleBackTime = 0.2f;

    void Start()
    {
        if (reversed)
        {
            xScale *= -1;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(xScale, yScale, 0), "time", scaleTime));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(Mathf.Sign(xScale), 1, 0), "time", scaleBackTime));
    }
}
