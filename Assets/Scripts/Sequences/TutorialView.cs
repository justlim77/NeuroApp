using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialView : MonoBehaviour
{
    [System.Serializable]
    public class TutorialSet
    {
        public Rect MaskRect;
        public Sprite MaskSprite;
        public Vector2 HeadPosition;
        public string Message;
        public Vector2 ArrowPosition;
        public Vector2 ArrowFacing;
    }

    #region public variables
    [Header("Tutorial Sets")]
    public TutorialSet[] TutorialSets;

    [Header("UI Elements")]
    public RectTransform MaskRect;
    public Image MaskImage;
    public RectTransform HeadRect;
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
    #endregion

    #region private methods
    // Use this for initialization
    void Start()
    {
        m_tutorialSetCount = TutorialSets.Length;

        PrevBtn.onClick.AddListener(PrevPage);
        NextBtn.onClick.AddListener(NextPage);
        CloseBtn.onClick.AddListener(ClosePage);

        PrevBtn.gameObject.SetActive(false);

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
        TutorialSet set = TutorialSets[index];
        MaskImage.sprite = set.MaskSprite;
        MaskRect.anchoredPosition = set.MaskRect.position;
        HeadRect.anchoredPosition = set.HeadPosition;
        ContextLabel.text = set.Message;
        Arrow.anchoredPosition = set.ArrowPosition;
        Arrow.localScale = set.ArrowFacing;
}
    #endregion
}