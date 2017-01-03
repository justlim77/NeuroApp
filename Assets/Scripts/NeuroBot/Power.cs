using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

namespace NeuroApp
{
    [System.Serializable]
    public class Power : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
    {
        public FaceState faceState;

        private Image m_image;

        void Start()
        {
            Init();
        }

        void OnEnable()
        {
            Init();
        }

        public void Init()
        {
            if (m_image == null)
                m_image = GetComponent<Image>();

            if (m_image != null)
                m_image.CrossFadeAlpha(0.0f, 0.0f, true);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            m_image.CrossFadeAlpha(1.0f, Constants.const_alpha_fade_duration, true);
            if (!m_Testing)
                GUIManager.GetMainHeadReaction().Reaction(FaceState.Shocked);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(PowerReaction(eventData.button));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            m_image.CrossFadeAlpha(0.0f, Constants.const_alpha_fade_duration, true);
            if (!m_Testing)
                GUIManager.GetMainHeadReaction().Reaction(FaceState.Neutral);
        }

        static bool m_Testing = false;
        IEnumerator PowerReaction(PointerEventData.InputButton button)
        {
            if (m_Testing)
                yield break;

            m_Testing = true;

            GUIManager.GetMainHeadReaction().testEyeManager.TrackMouse = false;

            switch (button)
            {
                case PointerEventData.InputButton.Left:
                    GUIManager.GetMainHeadReaction().Reaction(faceState);
                    break;
                // Deprecated in 0.3.
                //case PointerEventData.InputButton.Right:
                //    GUIManager.GetMainHeadReaction().testEyeManager.ConvergeTest = true;
                //    break;
            }

            yield return new WaitForSeconds(Constants.const_power_reaction_delay);

            GUIManager.GetMainHeadReaction().Reaction(FaceState.Neutral);
            GUIManager.GetMainHeadReaction().testEyeManager.TrackMouse = true;
            GUIManager.GetMainHeadReaction().testEyeManager.ConvergeTest = false;

            m_Testing = false;
        }
    }
}