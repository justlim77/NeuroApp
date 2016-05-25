﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using NeuroApp;
using System;

public class Pupil : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public State pupilState = State.Normal;
    public Pupil otherPupil;
    public HeadReaction head;
    public RectTransform pupilImage;
    public float activationRadius = 40.0f;
    public float normalSize;
    public float halfSize;
    public float dilatedSize;
    public float constrictedSize;

    void Start()
    {        
    }

    public bool Init(State state)
    {
        pupilState = state;
        return true;
    }

    void Update()
    {        
    }

    public void ResizeEyes(float pupilSize)
    {
        pupilImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pupilSize);
        pupilImage.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pupilSize);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (pupilState)
        {
            case State.Normal:
                this.ResizeEyes(constrictedSize);
                otherPupil.ResizeEyes(constrictedSize);
                break;
            case State.Abnormal:
                this.ResizeEyes(halfSize);
                otherPupil.ResizeEyes(halfSize);
                break;
        }

        head.SetMouth(MouthState.OMG);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.ResizeEyes(normalSize);
        otherPupil.ResizeEyes(normalSize);
        head.SetMouth(MouthState.Neutral);
    }
}
