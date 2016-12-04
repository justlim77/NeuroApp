using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialView : MonoBehaviour
{
    [System.Serializable]
    public class TutorialSet
    {
        public string SegmentName = "";

        public Sprite MaskSprite = null;
        public RectOffset MaskOffset = new RectOffset();
        public Vector2 HeadPosition = Vector2.zero;

        [TextArea]
        public string Message = "";

        public bool ShowArrow = false;
        public Vector2 ArrowPosition = Vector2.zero;
        public Vector3 ArrowRotation = Vector3.zero;
        public Vector2 ArrowFacing = Vector2.one;
    }

    #region public variables
    [Header("Tutorial Sets")]
    public TutorialSet[] TutorialSets;

    [Header("UI Elements")]
    public RectTransform MaskRect;
    public Image MaskImage;
    public RectTransform HeadRect;
    public RectTransform ContextRect;
    public Text ContextLabel;    
    public RectTransform Arrow;

    [Header("Buttons")]
    public Button PrevBtn;
    public Button NextBtn;
    public Button CloseBtn;
    #endregion

    #region fields
    private int m_tutorialSetCount = 0;
    private int m_pageIdx = 0;
    private int m_contextYOffset = 200;
    #endregion

    #region private methods
    // Use this for initialization
    void Start()
    {
        m_tutorialSetCount = TutorialSets.Length;

        PrevBtn.onClick.AddListener(PrevPage);
        NextBtn.onClick.AddListener(NextPage);
        CloseBtn.onClick.AddListener(ClosePage);

        SetTutorial(0);
    }

    private void PrevPage()
    {
        m_pageIdx--;
        Mathf.Clamp(m_pageIdx, 0, m_tutorialSetCount);
        SetTutorial(m_pageIdx);
    }

    private void NextPage()
    {
        m_pageIdx++;
        Mathf.Clamp(m_pageIdx, 0, m_tutorialSetCount);
        SetTutorial(m_pageIdx);
    }

    private void ClosePage()
    {
        this.gameObject.SetActive(false);
    }

    private void SetTutorial(int index)
    {
        // Set buttons
        PrevBtn.gameObject.SetActive(index <= 0 ? false : true);
        NextBtn.gameObject.SetActive(index >= m_tutorialSetCount - 1 ? false : true);

        // Set tutorial data set
        TutorialSet set = TutorialSets[index];

        // Set blocking rect size
        MaskImage.sprite = set.MaskSprite;
        MaskRect.offsetMin = new Vector2(set.MaskOffset.left, set.MaskOffset.bottom);
        MaskRect.offsetMax = new Vector2(set.MaskOffset.right, set.MaskOffset.top);

        HeadRect.anchoredPosition = set.HeadPosition;
        ContextRect.anchoredPosition = new Vector2(set.HeadPosition.x, set.HeadPosition.y - m_contextYOffset);
        ContextLabel.text = set.Message;
        Arrow.anchoredPosition = set.ArrowPosition;
        Arrow.rotation = Quaternion.identity;
        if(set.ArrowRotation != Vector3.zero)
            Arrow.Rotate(set.ArrowRotation);
        Arrow.localScale = set.ArrowFacing;
    }
    #endregion

    #region public methods
    public bool Initialize()
    {
        SetTutorial(0);

        return true;
    }

    public void ShowTutorial(bool show)
    {
        this.gameObject.SetActive(show);

        if (show)
        {            
            Initialize();
            transform.SetAsLastSibling();
        }
    }

    #endregion
}