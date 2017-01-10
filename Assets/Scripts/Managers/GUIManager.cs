using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

namespace NeuroApp
{
    public class GUIManager : MonoBehaviour
    {
        public static GUIManager Instance { get; private set; }

        [Header("UI References")]
        [SerializeField] Canvas MainCanvas;
        [SerializeField] Image mainPanel;
        [SerializeField] Text header;
        [SerializeField] HeadReaction mainHeadReaction;
        [SerializeField] Button ClinicalExamButton;
        [SerializeField] Button SpeechButton;

        [Header("Patient View")]
        [SerializeField] RectTransform BedRectTrans;
        [SerializeField] Vector2 BedOriginalOffsetMin;
        [SerializeField] Vector2 BedOriginalOffsetMax;
        [SerializeField] Vector2 CranialBedPos;
        [SerializeField] Vector2 CranialBedScale;
        [SerializeField] Graphic[] ToggleableGraphics;

        public TutorialView TutorialView;

        [Header("Context Popup")]
        [SerializeField] GameObject popupPrefab;

        [Header("Animation Parameters")]
        [SerializeField] bool animate = true;

        private static Image _MainPanel = null;
        private static Text _Header = null;
        private static HeadReaction _MainHeadReaction = null;
        private static bool _Animate = true;
        private Vector2 _bedOriginalScale = Vector2.zero;
        private static CanvasScaler _canvasScaler = null;

        private ContextPopup contextPopup = null;
        public ContextPopup ContextPopup
        {
            get
            {
                if (contextPopup == null)
                {
                    contextPopup = CreateContextPopup();
                }
                return contextPopup;
            }
        }

        private string m_clinicalExamContext = string.Empty;
        private string m_speechContext = string.Empty;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            _bedOriginalScale = BedRectTrans.localScale;
            _canvasScaler = MainCanvas.GetComponent<CanvasScaler>();
        }

        private void OnDestroy()
        {
            ClinicalExamButton.onClick.RemoveAllListeners();
            SpeechButton.onClick.RemoveAllListeners();

            if (Instance != null)
                Instance = null;
        }

        private void Start()
        {
            contextPopup = CreateContextPopup();

            ClinicalExamButton.onClick.AddListener(() => { SetContext(m_clinicalExamContext, TextAnchor.MiddleCenter); });
            SpeechButton.onClick.AddListener(() => { SetContext(m_speechContext, TextAnchor.MiddleCenter); });
        }

        private void ShowClinicalExam()
        {
            SetContext(m_clinicalExamContext, TextAnchor.MiddleLeft);
        }

        private void ShowSpeech()
        {
            SetContext(m_speechContext, TextAnchor.MiddleCenter);
        }

        private ContextPopup CreateContextPopup()
        {
            GameObject popupObject = Instantiate(popupPrefab, MainCanvas.transform) as GameObject;
            ContextPopup popup = popupObject.GetComponent<ContextPopup>();
            return popup;
        }

        public bool Initialize()
        {
            if (_MainPanel == null)
            {
                _MainPanel = mainPanel;
                //_MainPanel.CrossFadeColor(Constants.const_background_color, 0.0f, true, true, true);
                _MainPanel.color = Constants.const_background_color;
            }
            if (_Header == null)
                _Header = header;
            if (_MainHeadReaction == null)
                _MainHeadReaction = mainHeadReaction;

            // Set clinical exam button to show context
            m_clinicalExamContext = string.Format("Tone\n{0}\n\nPlantars\n{1}\n\nCerebellar Examination\n{2}\n\nOther important tests\n{3}",
                Patient.CaseData.tone, Patient.CaseData.plantars, Patient.CaseData.cerebellar, Patient.CaseData.otherTests);

            // Set speech dialog button to show context
            m_speechContext = Patient.CaseData.speech;

            _Animate = animate;

            return true;
        }

        public static void ChangePanelColor(Color targetColor)
        {
            if (_MainPanel != null)
            {
                _MainPanel.color = targetColor;
            }
        }

        public void DimPanelColor()
        {
            _MainPanel.color = Constants.const_areflexia_color;
        }

        public void SetCheatContext(Sprite context)
        {
            SetContext(context, Alignment.BottomLeft);
        }

        public void SetPeronealContext(Sprite context)
        {
            SetContext(context, true);
        }

        public static void RevertPanelColor()
        {
            ChangePanelColor(Constants.const_background_color);
        }

        public static void ChangeReactionText(string text)
        {
            if (_Header != null)
            {
                _Header.text = text;
            }
        }

        public static HeadReaction GetMainHeadReaction()
        {
            return _MainHeadReaction;
        }

        public void SetPatientView(PatientView view)
        {
            switch (view)
            {
                case PatientView.Full:
                    BedRectTrans.offsetMin = BedOriginalOffsetMin;
                    BedRectTrans.offsetMax = BedOriginalOffsetMax;
                    BedRectTrans.localScale = Vector3.one;
                    SetToggleableVisibility(true);
                    break;
                case PatientView.Face:
                    BedRectTrans.anchoredPosition = CranialBedPos;
                    BedRectTrans.localScale = CranialBedScale;
                    SetToggleableVisibility(false);
                    break;
            }
        }

        public void SetToggleableVisibility(bool value = true)
        {
            foreach (var graphic in ToggleableGraphics)
            {
                graphic.enabled = value;
            }
        }

        public static Vector2 GetReferenceResolution()
        {
            return _canvasScaler.referenceResolution;
        }

        #region Wrapper functions
        public void SetContext(Sprite context)
        {
            ContextPopup.SetContext(context);
        }

        public void SetContext(Sprite context, bool setNativeSize)
        {
            ContextPopup.SetContext(context, setNativeSize);
        }

        public void SetContext(Sprite context, Alignment alignment)
        {
            ContextPopup.SetContext(context, alignment);
        }

        public void SetContext(string context, TextAnchor textAnchor)
        {
            ContextPopup.SetContext(context, textAnchor);
        }
        #endregion
    }
}

