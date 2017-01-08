using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NeuroApp
{
    public class LocaliseView : MonoBehaviour
    {
        public Image localisingImage;
        public Button explanationButton;

        private string m_explanation;

        private void Start()
        {
            explanationButton.onClick.AddListener(ShowExplanation);
        }

        private void OnDestroy()
        {
            explanationButton.onClick.RemoveAllListeners();
        }

        public bool Initialize(Sprite localiseTexture, string explanation)
        {
            localisingImage.sprite = localiseTexture;
            m_explanation = explanation;

            return true;
        }

        public void ShowExplanation()
        {
            GUIManager.Instance.ContextPopup.SetContext(m_explanation, textAnchor:TextAnchor.MiddleLeft);            
        }
    }
}
