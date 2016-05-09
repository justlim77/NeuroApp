using UnityEngine;
using UnityEngine.EventSystems;
using NeuroApp;

public class FaceReaction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject m_Head;
    [SerializeField] FaceState m_FaceState;

    HeadReaction m_HeadReaction;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        if (m_Head)
            m_HeadReaction = m_Head.GetComponent<HeadReaction>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_HeadReaction)
            m_HeadReaction.Reaction(m_FaceState);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (m_HeadReaction)
            m_HeadReaction.Reaction(FaceState.Smile);
    }
}
