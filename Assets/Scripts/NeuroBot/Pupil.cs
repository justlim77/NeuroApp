using UnityEngine;
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

    public bool Init(State state, float normal = 8, float half = 5, float dilate = 9, float constrict = 2)
    {
        pupilState = state;
        normalSize = normal;
        halfSize = half;
        dilatedSize = dilate;
        constrictedSize = constrict;
        return true;
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
                otherPupil.ResizeEyes(otherPupil.constrictedSize);
                break;
            case State.Abnormal:
                this.ResizeEyes(halfSize);
                otherPupil.ResizeEyes(otherPupil.halfSize);
                break;
        }

        head.SetMouth(MouthState.OMG);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.ResizeEyes(dilatedSize);
        otherPupil.ResizeEyes(otherPupil.dilatedSize);
        head.SetMouth(MouthState.Neutral);
    }
}
