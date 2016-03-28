using UnityEngine;
using UnityEngine.EventSystems;

public class FaceReaction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region Serialized Private Fields
    [SerializeField] private GameObject m_Head;
    [SerializeField] private HeadReaction.FaceState m_FaceState;
    #endregion

    #region Private Variables
    private HeadReaction m_HeadReaction;
    #endregion

    #region Initialization Methods
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if (m_Head)
            m_HeadReaction = m_Head.GetComponent<HeadReaction>();
    }
    #endregion

    #region Public Methods
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (m_HeadReaction)
            m_HeadReaction.Reaction(m_FaceState);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (m_HeadReaction)
            m_HeadReaction.Reaction(HeadReaction.FaceState.Smile);
    }
    #endregion
}
