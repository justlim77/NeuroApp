using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using NeuroApp;

[System.Serializable]
public class Dermatome : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public HeadReaction head;
    public Text header;
    public Image mainPanel;

    public bool canFeel = true;

    Color m_originalColor;
    Image m_image;
    FaceState m_reactionState;

    void OnEnable()
    {
        Init();
    }

    void Start()
    {
        Init();
    }

    public void Init()
    {
        m_originalColor = mainPanel.color;
        m_image = GetComponent<Image>();

        if(m_image != null)
            m_image.CrossFadeAlpha(0.0f, 0.0f, true);

        m_reactionState = canFeel ? FaceState.NoReaction : FaceState.Shocked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_image.CrossFadeAlpha(1.0f, Constants.const_alpha_fade_duration, true);
        if (!_isPoking)
            head.Reaction(FaceState.Shocked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            StartCoroutine(PinReaction());
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_image.CrossFadeAlpha(0.0f, Constants.const_alpha_fade_duration, true);
        if(!_isPoking)
            head.Reaction(FaceState.Neutral);
    }

    static bool _isPoking = false;
    IEnumerator PinReaction()
    {
        if (_isPoking)
            yield break;

        _isPoking = true;

        head.Reaction(m_reactionState);
        mainPanel.color = canFeel ? Constants.const_areflexia_color : Constants.const_normal_color;
        header.text = canFeel ? Constants.const_norm_msg : Constants.const_absent_msg;
        head.testEyeManager.TrackMouse = false;

        yield return new WaitForSeconds(Constants.const_pin_reaction_delay);

        head.Reaction(FaceState.Neutral);
        mainPanel.color = m_originalColor;
        header.text = string.Empty;
        head.testEyeManager.TrackMouse = true;

        _isPoking = false;
    }
}
