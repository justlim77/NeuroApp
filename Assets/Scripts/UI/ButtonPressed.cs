using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class ButtonPressed : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
    [SerializeField] bool _Reversed = false;
    private float _xDownScale = 0.9f;
    private float _yDownScale = 0.9f;
    private float _xUpScale = 1.1f;
    private float _yUpScale = 1.1f;
    private float _ScaleToTime = 0.8f;
    private float _ScaleBackTime = 0.2f;

    void Start()
    {
        if (_Reversed)
        {
            _xDownScale *= -1;
            _xUpScale *= -1;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(_xDownScale, _yDownScale, 0), "time", _ScaleToTime));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(Mathf.Sign(_xDownScale), 1, 0), "time", _ScaleBackTime));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(_xUpScale, _yUpScale, 0), "time", _ScaleToTime));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(Mathf.Sign(_xDownScale), 1, 0), "time", _ScaleBackTime));
    }
}
