using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using NeuroApp;

[System.Serializable]
public class PinObject : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public HeadReaction head;
    public Text header;
    public Image mainPanel;
    public Color reactionColor = new Color32(251, 221, 97, 255);
    public Color noReactionColor = new Color32(36, 36, 36, 255);
    public float activationRadius = 50.0f;

    public bool canFeel = true;
    public string positiveMessage = "Oww!";
    public string negativeMessage = "...";

    Color m_OriginalColor;
    Image m_Image;
    FaceState m_ReactionState;
    Color m_VisibleColor = new Color(1, 1, 1, 1);
    Color m_InvisibleColor = new Color(1, 1, 1, 0);

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
        m_OriginalColor = mainPanel.color;
        m_Image = GetComponent<Image>();
        m_Image.color = m_Image.color = m_InvisibleColor;
        m_ReactionState = canFeel ? FaceState.NoReaction : FaceState.Shocked;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Image.color = m_VisibleColor;
        if(!_isPoking)
            head.Reaction(FaceState.Shocked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PinReaction());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Image.color = m_InvisibleColor;
        if(!_isPoking)
            head.Reaction(FaceState.Neutral);
    }

    static bool _isPoking = false;
    IEnumerator PinReaction()
    {
        if (_isPoking)
            yield break;

        _isPoking = true;

        head.Reaction(m_ReactionState);
        mainPanel.color = canFeel ? reactionColor : noReactionColor;
        header.text = canFeel ? positiveMessage : negativeMessage;
        head.testEyeManager.TrackMouse = false;

        yield return new WaitForSeconds(Constants.const_reaction_delay);

        head.Reaction(FaceState.Neutral);
        mainPanel.color = m_OriginalColor;
        header.text = string.Empty;
        head.testEyeManager.TrackMouse = true;

        _isPoking = false;
    }
}
