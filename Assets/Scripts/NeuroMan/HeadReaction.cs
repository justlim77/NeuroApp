using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HeadReaction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    #region Mouth Variables
    public Image mouth;
    public Sprite mouthSmile;
    public Sprite mouthShocked;
    public Sprite mouthSlanted;
    #endregion

    #region Eye Variables
    public Image[] eyes;
    public GameObject[] innerEyes;
    public GameObject[] middleEyes;
    public Eye[] eyeScripts;
    public Sprite ouchEyes;
    public Image[] eyeBrows;
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
        Neutral
    }
    public FaceState faceState;
    #endregion

    #region Private Variables
    Sprite m_OriginalEyes;
    #endregion

    #region Initialization Methods
    private void Awake() {
        Init();
    }

    private void Init() {
        m_OriginalEyes = eyes[0].sprite;
        m_DefaultEyeSize = eyes[0].GetComponent<RectTransform>().rect.width;
    }
    #endregion

    #region Public Methods
    public void Reaction(FaceState _faceState) {
        switch (_faceState) {
            case FaceState.Smile:
                mouth.sprite = mouthSmile;
                ToggleEyes(m_OriginalEyes, m_DefaultEyeSize);
                break;
            case FaceState.Shocked:
                mouth.sprite = mouthShocked;
                ToggleEyes(m_OriginalEyes, m_EnlargedEyeSize);
                break;
            case FaceState.OMG:
                mouth.sprite = mouthShocked;
                ToggleEyes(m_OriginalEyes, m_EnlargedEyeSize, true, false);
                CenterEyes();
                break;
            case FaceState.Ouch:
                mouth.sprite = mouthSlanted;
                ToggleEyes(ouchEyes, m_DefaultEyeSize, false);
                break;
            case FaceState.Neutral:
                mouth.sprite = mouthSlanted;
                ToggleEyes(m_OriginalEyes, m_DefaultEyeSize, true, false);
                CenterEyes();
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
    private void ToggleEyes(Sprite sprite, float size, bool showBrow = true, bool follow = true) {
        //Swap eye sprites
        foreach (Image eye in eyes) {
            eye.sprite = sprite;

            //RectTransform rect = eye.GetComponent<RectTransform>();
            //rect.sizeDelta = new Vector2(size, size);
        }

        //Toggle brow images
        foreach (Image brow in eyeBrows)
            brow.enabled = showBrow;

        //Toggle inner and middle eyes
        foreach (GameObject innerEye in innerEyes)
            innerEye.SetActive(showBrow);
        foreach (GameObject middleEye in middleEyes)
            middleEye.SetActive(showBrow);

        foreach (Eye script in eyeScripts)
            script.enabled = follow;
    }

    private void CenterEyes() {
        foreach (GameObject middleEye in middleEyes)
        {
            RectTransform rect = middleEye.GetComponent<RectTransform>();
            if (rect)
                rect.localPosition = Vector2.zero;
        }
    }
    #endregion
}