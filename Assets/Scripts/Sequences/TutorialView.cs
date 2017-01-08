using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NeuroApp
{
    public class TutorialView : MonoBehaviour
    {
        [System.Serializable]
        public class TutorialSet
        {
            public string SegmentName = "";

            public Sprite MaskSprite = null;
            public RectOffset MaskOffset = new RectOffset();

            public bool ShowHead = true;
            public Vector2 HeadPosition = Vector2.zero;

            public ReflexType ReflexType = ReflexType.Nil;

            /// <summary>
            /// Choose to focus on body or head
            /// </summary>
            public PatientView PatientView = PatientView.Full;

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

        [Header("Head Component")]
        public HeadReaction HeadReaction;

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
            CloseBtn.onClick.AddListener(() => { GUIManager.Instance.SetPatientView(PatientView.Full); });

            SetTutorial(0);
        }

        private void OnDestroy()
        {
            PrevBtn.onClick.RemoveAllListeners();
            NextBtn.onClick.RemoveAllListeners();
            CloseBtn.onClick.RemoveAllListeners();
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
            // Reset to default state
            HeadReaction.FreezeState(false);
            HeadReaction.Reaction(FaceState.Smile);
            GUIManager.RevertPanelColor();

            this.gameObject.SetActive(false);
        }

        private void SetTutorial(int index)
        {
            // Resume eye tracking
            HeadReaction.ResumeEyeTracking();        

            // Set buttons
            PrevBtn.gameObject.SetActive(index <= 0 ? false : true);
            NextBtn.gameObject.SetActive(index >= m_tutorialSetCount - 1 ? false : true);

            // Set tutorial data set
            TutorialSet set = TutorialSets[index];

            // Set reaction and background color
            switch (set.ReflexType)
            {
                case ReflexType.Nil:
                    HeadReaction.DemoNilReaction();
                    break;
                case ReflexType.Normal:
                    HeadReaction.DemoNormalReflex();
                    break;
                case ReflexType.Areflexia:
                    HeadReaction.DemoAreflexia();
                    break;
                case ReflexType.Hyperreflexia:
                    HeadReaction.DemoHyperreflexia();
                    break;
            }

            // Set patient view
            GUIManager.Instance.SetPatientView(set.PatientView);

            // Set blocking rect size
            MaskImage.sprite = set.MaskSprite;
            MaskRect.offsetMin = new Vector2(set.MaskOffset.left, set.MaskOffset.bottom);
            MaskRect.offsetMax = new Vector2(set.MaskOffset.right, set.MaskOffset.top);

            // Set head
            HeadRect.gameObject.SetActive(set.ShowHead);
            HeadRect.anchoredPosition = set.HeadPosition;

            // Set context
            ContextRect.anchoredPosition = new Vector2(set.HeadPosition.x, set.HeadPosition.y - m_contextYOffset);
            ContextLabel.text = set.Message;

            // Set arrow
            Arrow.gameObject.SetActive(set.ShowArrow);        
            if (set.ShowArrow)
            {
                Arrow.anchoredPosition = set.ArrowPosition;
                Arrow.rotation = Quaternion.identity;
                if (set.ArrowRotation != Vector3.zero)
                    Arrow.Rotate(set.ArrowRotation);
                Arrow.localScale = set.ArrowFacing;
            }
        }
        #endregion

        #region public methods
        public bool Initialize()
        {
            m_pageIdx = 0;

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
}