﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NeuroApp;
using System.Collections;

public class HeadReaction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image mouth;
    public Sprite mouthNeutral;
    public Sprite mouthSmile;
    public Sprite mouthShocked;
    public Sprite mouthWideO;
    public Sprite mouthSlanted;
    public Image teeth;
    public Image dimpleRight, dimpleLeft;
    public Sprite gritNormal, gritAbnormal;
    public Image palate;
    public Sprite palateNormal;
    public Sprite palateAbnormal;

    public Sprite ouchEyes;
    public Sprite squint;
    public Sprite defaultBrow;
    public Sprite slantedBrow;
    public Image[] eyes;
    public GameObject[] innerEyes;
    public GameObject[] middleEyes;
    public RectTransform[] pupils;
    public Eye[] eyeScripts;
    public RectTransform[] eyeBrows;
    public Image[] eyeBrowImages;
    public Image[] wrinkleImages;

    [SerializeField] private float _defaultEyeSize = 8.0f;
    [SerializeField] private float _enlargedEyeSize = 10.0f;

    public FaceState faceState;
    public MouthState mouthState;

    Sprite _originalEyes;
    float _eyeBrowInitialY;
    bool _isFrozen;

    void Awake()
    {
        _originalEyes = eyes[0].sprite;
        _eyeBrowInitialY = eyeBrows[0].anchoredPosition.y;

        Init();
    }

    void Init()
    {
        foreach (var eye in eyes)
            eye.sprite = _originalEyes;
        foreach (var brow in eyeBrows)
            brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, _eyeBrowInitialY);
        foreach (var wrinkle in wrinkleImages)
            wrinkle.enabled = false;

        if (teeth != null)
            teeth.enabled = false;

        if (dimpleLeft != null)
            dimpleLeft.enabled = false;
        
        if (dimpleRight != null)
            dimpleRight.enabled = false;

        FreezeState(false);
    }

    public void Reaction(FaceState _faceState)
    {
        switch (_faceState)
        {
            case FaceState.Smile:
                mouth.sprite = mouthSmile;
                ToggleEyes(_originalEyes, _defaultEyeSize);
                foreach (var wrinkle in wrinkleImages)                    
                    wrinkle.enabled = false;
                foreach (var brow in eyeBrows)                
                    brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, _eyeBrowInitialY);
                foreach (var image in eyeBrowImages)
                    image.sprite = defaultBrow;
                if (teeth != null)
                    teeth.enabled = false;  
                if (dimpleLeft != null)          
                    dimpleLeft.enabled = false;
                if (dimpleRight != null)
                    dimpleRight.enabled = false;
                FreezeState(false);
                break;
            case FaceState.Shocked:
                mouth.sprite = mouthShocked;
                ToggleEyes(_originalEyes, _enlargedEyeSize);
                break;
            case FaceState.OMG:
                mouth.sprite = mouthWideO;
                ToggleEyes(_originalEyes, _enlargedEyeSize, 3.0f, true, true, false);
                CenterEyes();
                if (teeth != null)
                    teeth.enabled = false;
                break;
            case FaceState.Ouch:
                mouth.sprite = mouthSlanted;
                ToggleEyes(ouchEyes, _defaultEyeSize, 3.0f, false, false);
                break;
            case FaceState.Neutral:
                mouth.sprite = mouthNeutral;
                ToggleEyes(_originalEyes, _defaultEyeSize, 3.0f, true, true, false);
                CenterEyes();
                if (teeth != null)
                    teeth.enabled = false;
                if (dimpleLeft != null)
                    dimpleLeft.enabled = false;
                if (dimpleRight != null)
                    dimpleRight.enabled = false;
                break;
            case FaceState.NoReaction:
                mouth.sprite = mouthSlanted;
                ToggleEyes(_originalEyes, _defaultEyeSize, 3.0f, true, true, false);
                CenterEyes();
                if (teeth != null)
                    teeth.enabled = false;
                if (dimpleLeft != null)
                    dimpleLeft.enabled = false;
                if (dimpleRight != null)
                    dimpleRight.enabled = false;
                break;
            case FaceState.RightEyebrowUp:
                StartCoroutine(RaiseBrow(10, eyeBrows[0]));
                break;
            case FaceState.LeftEyebrowUp:
                StartCoroutine(RaiseBrow(10, eyeBrows[1]));
                break;
            case FaceState.BothEyebrowsUp:
                StartCoroutine(RaiseBrow(10, eyeBrows));
                break;
            case FaceState.RightSquint:
                Squint(0, eyes[0]);
                break;
            case FaceState.LeftSquint:
                Squint(1, eyes[1]);
                break;
            case FaceState.BothSquint:
                Squint(2, eyes);
                break;
            case FaceState.LeftGritTeeth:
                Grit(gritAbnormal, -1);
                dimpleLeft.enabled = true;
                dimpleRight.enabled = false;
                break;
            case FaceState.RightGritTeeth:
                Grit(gritAbnormal, 1);
                dimpleLeft.enabled = false;
                dimpleRight.enabled = true;
                break;
            case FaceState.BothGritTeeth:
                Grit(gritNormal);
                dimpleLeft.enabled = true;
                dimpleRight.enabled = true;
                break;
            default:
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isFrozen)
            return;
        Reaction(FaceState.Shocked);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isFrozen)
            return;
        Reaction(FaceState.Neutral);
    }

    void ToggleEyes(Sprite sprite, float midSize = 8.0f, float pupilSize = 3.0f, bool showBrow = true, bool showInOutEyes = true, bool follow = true)
    {
        foreach (Image eye in eyes)
            eye.sprite = sprite;

        foreach (Image brow in eyeBrowImages)
        {
            brow.sprite = defaultBrow;
            brow.enabled = showBrow;
        }

        foreach (var innerEye in innerEyes)
            innerEye.SetActive(showInOutEyes);

        foreach (var middleEye in middleEyes)
        {
            middleEye.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, midSize);
            middleEye.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, midSize);
            middleEye.SetActive(showInOutEyes);
        }

        foreach (var pupil in pupils)
        {
            if (pupil != null)
            {
                pupil.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pupilSize);
                pupil.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pupilSize);
            }
        }

        foreach (var eye in eyeScripts)
            eye.enabled = follow;
    }

    void CenterEyes()
    {
        foreach (GameObject middleEye in middleEyes)
        {
            RectTransform rect = middleEye.GetComponent<RectTransform>();
            if (rect)
                rect.localPosition = Vector2.zero;
        }
    }

    bool _isRaising = false;
    IEnumerator RaiseBrow(float height = 10.0f, params RectTransform[] brows)
    {
        if (_isRaising)
            yield break;

        _isRaising = true;
        mouth.sprite = mouthNeutral;
        ToggleEyes(_originalEyes, _defaultEyeSize, 3.0f, true, true, false);
        CenterEyes();

        foreach (var brow in brows)
        {
            brow.transform.GetChild(0).GetComponent<Image>().enabled = true;
            brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, brow.anchoredPosition.y + height); 
        }

        yield return new WaitForSeconds(Constants.const_reaction_delay);

        foreach (var brow in brows)
        {
            brow.transform.GetChild(0).GetComponent<Image>().enabled = false;
            brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, brow.anchoredPosition.y - height);
        }

        _isRaising = false;
    }

    void Squint(int browIndex, params Image[] eyes)
    {
        mouth.sprite = mouthNeutral;
        ToggleEyes(_originalEyes, _defaultEyeSize, 3.0f, true, false, false);
        CenterEyes();

        foreach (var eye in eyes)
            eye.sprite = squint;

        switch (browIndex)
        {
            case 0:
                eyeBrowImages[0].sprite = slantedBrow;
                innerEyes[1].SetActive(true);
                middleEyes[1].SetActive(true);
                break;
            case 1:
                eyeBrowImages[1].sprite = slantedBrow;
                innerEyes[0].SetActive(true);
                middleEyes[0].SetActive(true);
                break;
            case 2:
                eyeBrowImages[0].sprite = slantedBrow;
                eyeBrowImages[1].sprite = slantedBrow;
                break;
        }
    }

    void Grit(Sprite sprite, int facing = 1)
    {
        mouth.rectTransform.localScale = new Vector2(facing, 1);
        mouth.sprite = sprite;
        teeth.enabled = true;

        ToggleEyes(_originalEyes, follow:false);
    }

    public void FreezeState(bool state)
    {
        foreach (var pupil in middleEyes)
        {
            Pupil pupilScript = pupil.GetComponent<Pupil>();
            if (pupilScript != null)
            {
                pupilScript.enabled = state;
            }
        }

        foreach (var pupil in pupils)
        {
            pupil.gameObject.SetActive(!state);
        }

        if (state)
        {
            ToggleEyes(_originalEyes, midSize: 9, pupilSize: 6, follow: false);
            SetMouth(MouthState.Neutral);
        }
        else
        {
            ToggleEyes(_originalEyes);
            SetMouth(MouthState.Smile);
        }

        _isFrozen = state;
    }

    public void SetMouth(MouthState mouthState)
    {
        switch (mouthState)
        {
            case MouthState.OMG:
                mouth.sprite = mouthWideO;
                break;
            case MouthState.Smile:
                mouth.sprite = mouthSmile;
                break;
            case MouthState.Ouch:
                mouth.sprite = mouthSlanted;
                break;
            case MouthState.Neutral:
                mouth.sprite = mouthNeutral;
                break;
            default:
                break;
        }
    }
}