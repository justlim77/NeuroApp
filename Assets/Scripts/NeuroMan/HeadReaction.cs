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
    public Sprite mouthSlanted;
    #endregion

    #region Eye Variables
    public Sprite ouchEyes;
    public Sprite squint;
    public Sprite defaultBrow;
    public Sprite slantedBrow;
    public Image[] eyes;
    public GameObject[] innerEyes;
    public GameObject[] middleEyes;
    public Eye[] eyeScripts;
    public RectTransform[] eyeBrows;
    public Image[] eyeBrowImages;
    public Image[] wrinkleImages;
    #endregion

    #region Serialized Private Fields
    [SerializeField] private float m_DefaultEyeSize = 8.0f;
    [SerializeField] private float m_EnlargedEyeSize = 10.0f;
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
        BothSquint    
    }
    public FaceState faceState;
    #endregion

    #region Private Variables
    Sprite _OriginalEyes;
    float _eyeBrowInitialY;
    #endregion

    #region Initialization Methods
    void Awake() {
        _OriginalEyes = eyes[0].sprite;
        m_DefaultEyeSize = eyes[0].GetComponent<RectTransform>().rect.width;
        _eyeBrowInitialY = eyeBrows[0].anchoredPosition.y;

        Init();
    }

    void Init() {
        foreach (var eye in eyes)
            eye.sprite = _OriginalEyes;
        foreach (var brow in eyeBrows)
            brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, _eyeBrowInitialY);
        foreach (var wrinkle in wrinkleImages)
            wrinkle.enabled = false;
    }
    #endregion

    #region Public Methods
    public void Reaction(FaceState _faceState) {
        switch (_faceState) {
            case FaceState.Smile:
                mouth.sprite = mouthSmile;
                ToggleEyes(_OriginalEyes, m_DefaultEyeSize);
                foreach (var wrinkle in wrinkleImages)                    
                    wrinkle.enabled = false;
                foreach (var brow in eyeBrows)                
                    brow.anchoredPosition = new Vector2(brow.anchoredPosition.x, _eyeBrowInitialY);
                foreach (var image in eyeBrowImages)
                    image.sprite = defaultBrow;
                break;
            case FaceState.Shocked:
                mouth.sprite = mouthShocked;
                ToggleEyes(_OriginalEyes, m_EnlargedEyeSize);
                break;
            case FaceState.OMG:
                mouth.sprite = mouthShocked;
                ToggleEyes(_OriginalEyes, m_EnlargedEyeSize, true, true, false);
                CenterEyes();
                break;
            case FaceState.Ouch:
                mouth.sprite = mouthSlanted;
                ToggleEyes(ouchEyes, m_DefaultEyeSize, false, false);
                break;
            case FaceState.Neutral:
                mouth.sprite = mouthSlanted;
                ToggleEyes(_OriginalEyes, m_DefaultEyeSize, true, true, false);
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
            default:
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Reaction(FaceState.Shocked);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Reaction(FaceState.Smile);
    }
    #endregion

    #region Private Methods
    void ToggleEyes(Sprite sprite, float size, bool showBrow = true, bool showInOutEyes = true, bool follow = true)
    {
        //Swap eye sprites
        foreach (Image eye in eyes)
        {
            eye.sprite = sprite;
        }

        //Toggle brow images
        foreach (Image brow in eyeBrowImages)
        {
            brow.enabled = showBrow;
        }

        //Toggle inner and middle eyes
        foreach (var innerEye in innerEyes)
        {
            innerEye.SetActive(showInOutEyes);
        }

        foreach (var middleEye in middleEyes)
        {
            middleEye.SetActive(showInOutEyes);
        }

        foreach (var eye in eyeScripts)
        {
            eye.enabled = follow;
        }
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
        ToggleEyes(_OriginalEyes, m_DefaultEyeSize, true, true, false);
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
        ToggleEyes(_OriginalEyes, m_DefaultEyeSize, true, false, false);
        CenterEyes();

        // Change to squint
        foreach (var eye in eyes)
            eye.sprite = squint;

        // Change brow
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

    #endregion
}