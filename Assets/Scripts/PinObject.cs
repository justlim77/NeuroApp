using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

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
    HeadReaction.FaceState m_ReactionState;
    Color m_VisibleColor = new Color(1, 1, 1, 1);
    Color m_InvisibleColor = new Color(1, 1, 1, 0);

    void Awake() { }

    void OnEnable()
    {
        Init();
    }

    void Start()
    {
        Init();
        m_ReactionState = canFeel ? HeadReaction.FaceState.Ouch : HeadReaction.FaceState.Neutral;
    }

    void LateUpdate()
    {
        //m_Image.enabled = Vector2.Distance(Input.mousePosition, transform.position) < m_ActivationRadius;
    }

    public void Init()
    {
        m_OriginalColor = mainPanel.color;
        m_Image = GetComponent<Image>();
        m_Image.color = m_Image.color = m_InvisibleColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_Image.color = m_VisibleColor;
        head.Reaction(HeadReaction.FaceState.Shocked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        head.Reaction(m_ReactionState);
        mainPanel.color = canFeel ? reactionColor : noReactionColor;
        header.text = canFeel ? positiveMessage : negativeMessage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_Image.color = m_InvisibleColor;
        head.Reaction(HeadReaction.FaceState.Smile);
        mainPanel.color = m_OriginalColor;
        header.text = string.Empty;
    }
}
