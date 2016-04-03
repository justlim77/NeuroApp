using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HeadReaction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Mouth Variables
    public Image mouth;
    public Sprite mouthSmile;
    public Sprite mouthShocked;
    public Sprite mouthWideO;
    public Sprite mouthSlanted;
    public Image teeth;
    public Sprite mouthTeethDefault;
    public Sprite mouthTeethCurved;
    #endregion

    #region Eye Variables
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
    #endregion

    #region Serialized Private Fields
    [SerializeField] private float _defaultEyeSize = 8.0f;
    [SerializeField] private float _enlargedEyeSize = 10.0f;
    #endregion

    #region Enumerations
    public enum FaceState {
        Smile,
        Shocked,
        OMG,
        Ouch,
        Neutral,
        RightEyebrowUp,
        LeftEyebrowUp,
        BothEyebrowsUp,        
        RightSquint,
        LeftSquint,
        BothSquint,
        RightGritTeeth,
        LeftGritTeeth,
        BothGritTeeth
    }
    public FaceState faceState;

    public enum MouthState {
        Smile,
        Shocked,
        OMG,
        Ouch,
        Neutral
    }
    public MouthState mouthState;
    #endregion

    #region Private Variables
    Sprite _originalEyes;
    float _eyeBrowInitialY;
    bool _isFrozen;
    #endregion

    #region Initialization Methods
    void Awake() {
        _originalEyes = eyes[0].sprite;
        _eyeBrowInitialY = eyeBrows[0].anchoredPosition.y;

        Init();
    }

    void Init() {
        foreach (var eye in eyes)
            eye.sprite = _originalEyes;
        foreach (var brow in eyeBrows)
            brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, _eyeBrowInitialY);
        foreach (var wrinkle in wrinkleImages)
            wrinkle.enabled = false;

        if(teeth != null)
            teeth.enabled = false;

        FreezeState(false);
    }
    #endregion

    #region Public Methods
    public void Reaction(FaceState _faceState) {
        switch (_faceState) {
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
                break;
            case FaceState.Ouch:
                mouth.sprite = mouthSlanted;
                ToggleEyes(ouchEyes, _defaultEyeSize, 3.0f, false, false);
                break;
            case FaceState.Neutral:
                mouth.sprite = mouthSlanted;
                ToggleEyes(_originalEyes, _defaultEyeSize, 3.0f, true, true, false);
                CenterEyes();
                break;
            case FaceState.RightEyebrowUp:
                RaiseBrow(10, eyeBrows[0]);
                break;
            case FaceState.LeftEyebrowUp:
                RaiseBrow(10, eyeBrows[1]);
                break;
            case FaceState.BothEyebrowsUp:
                RaiseBrow(10, eyeBrows);
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
                Grit(mouthTeethCurved, 1);
                break;
            case FaceState.RightGritTeeth:
                Grit(mouthTeethCurved, -1);
                break;
            case FaceState.BothGritTeeth:
                Grit(mouthTeethDefault);
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
        Reaction(FaceState.Smile);
    }
    #endregion

    #region Private Methods
    void ToggleEyes(Sprite sprite, float midSize = 8.0f, float pupilSize = 3.0f, bool showBrow = true, bool showInOutEyes = true, bool follow = true)
    {
        foreach (Image eye in eyes)
            eye.sprite = sprite;

        foreach (Image brow in eyeBrowImages)
            brow.enabled = showBrow;

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

    void RaiseBrow(float height = 10.0f, params RectTransform[] brows)
    {
        mouth.sprite = mouthSmile;
        ToggleEyes(_originalEyes, _defaultEyeSize, 3.0f, true, true, false);
        CenterEyes();

        foreach (var brow in brows)
        {
            brow.transform.GetChild(0).GetComponent<Image>().enabled = true;
            brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, brow.anchoredPosition.y + height); 
        }
    }

    void Squint(int browIndex, params Image[] eyes)
    {
        mouth.sprite = mouthSmile;
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

        ToggleEyes(ouchEyes, showBrow:false, showInOutEyes:false, follow:false);
    }

    public void FreezeState(bool state)
    {
        foreach (var pupil in pupils)
        {
            Pupil pupilScript = pupil.GetComponent<Pupil>();
            if (pupilScript != null)
                pupilScript.enabled = state;
        }

        if (state)
            ToggleEyes(_originalEyes, midSize: 12, pupilSize: 6, follow: false);
        else
            ToggleEyes(_originalEyes);

        SetMouth(MouthState.Smile);
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
            default:
                break;
        }
    }

    #endregion
}