using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace NeuroApp
{
    [System.Serializable]
    public class Dermatome : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
    {
        public bool canFeel = true;

        [Header("Compound parts")]
        public Dermatome[] compoundDermatomes;

        private Image m_image;
        private FaceState m_reactionState;

        private int compoundDermatomeCount = 0;

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
            if (m_image == null)
                m_image = GetComponent<Image>();

            if (m_image != null)
                CrossFadeAlpha(0.0f, 0.0f, true, true);

            m_reactionState = canFeel ? FaceState.NoReaction : FaceState.Shocked;

            compoundDermatomeCount = compoundDermatomes.Length;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {            
            CrossFadeAlpha(1.0f, Constants.const_alpha_fade_duration, true, true);
            if (!m_Testing)
                GUIManager.GetMainHeadReaction().Reaction(FaceState.Shocked);
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
            CrossFadeAlpha(0.0f, Constants.const_alpha_fade_duration, true, true);
            if (!m_Testing)
                GUIManager.GetMainHeadReaction().Reaction(FaceState.Neutral);
        }

        static bool m_Testing = false;
        IEnumerator PinReaction()
        {
            if (m_Testing)
                yield break;

            m_Testing = true;

            GUIManager.GetMainHeadReaction().Reaction(m_reactionState);
            GUIManager.ChangePanelColor(canFeel ?Constants.const_normal_color : Constants.const_areflexia_color);
            GUIManager.ChangeReactionText(canFeel ? Constants.const_norm_msg : Constants.const_absent_msg);
            //GUIManager.GetMainHeadReaction().testEyeManager.TrackMouse = false;

            yield return new WaitForSeconds(Constants.const_pin_reaction_delay);

            GUIManager.GetMainHeadReaction().Reaction(FaceState.Neutral);
            GUIManager.RevertPanelColor();
            GUIManager.ChangeReactionText(string.Empty);
            GUIManager.GetMainHeadReaction().testEyeManager.TrackMouse = true;

            m_Testing = false;
        }

        #region Wrapper Functions
        public void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
        {
            m_image.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
        }

        public void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale, bool includeCompounds)
        {
            m_image.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
            if (includeCompounds && compoundDermatomeCount != 0)
            {
                foreach (Dermatome dermatome in compoundDermatomes)
                {
                    dermatome.CrossFadeAlpha(alpha, duration, ignoreTimeScale);
                }
            }
        }
        #endregion
    }
}