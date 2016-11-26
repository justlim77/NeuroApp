using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NeuroApp
{
    [RequireComponent(typeof(Image))]
    public class ContextPopup : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] Button closeButton;

        [SerializeField] Color backgroundColor = Color.white;
        [SerializeField] Sprite backgroundImage = null;

        private Image m_cachedImage = null;

        // Use this for initialization
        void Start()
        {
            m_cachedImage = GetComponent<Image>();

            RectTransform cachedRect = GetComponent<RectTransform>();
            cachedRect.offsetMin = Vector2.zero;
            cachedRect.offsetMax = Vector2.zero;

            if (closeButton != null)
            {
                closeButton.onClick.AddListener(() =>
                {
                    this.gameObject.SetActive(false);
                });
            }
            else
            {
                Debug.LogError("ContextPopup close button reference is unassigned! Please assign it in the prefab.");
            }

            this.gameObject.SetActive(false);
        }

        public void SetContext(Sprite context)
        {
            m_cachedImage.color = Color.white;
            m_cachedImage.sprite = context;
            text.text = string.Empty;

            this.transform.SetAsLastSibling();

            this.gameObject.SetActive(true);
        }

        public void SetContext(string context, TextAnchor textAnchor = TextAnchor.MiddleCenter)
        {
            m_cachedImage.color = backgroundColor;
            m_cachedImage.sprite = backgroundImage;

            text.alignment = textAnchor;
            text.text = context;

            this.transform.SetAsLastSibling();

            this.gameObject.SetActive(true);
        }
    }
}
