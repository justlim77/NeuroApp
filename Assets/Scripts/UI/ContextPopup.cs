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
        private Vector2 m_cachedButtonPos = Vector2.zero;
        private RectTransform m_cachedButtonRectTrans = null;

        private bool m_initialized = false;

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

                m_cachedButtonRectTrans = closeButton.GetComponent<RectTransform>();
                m_cachedButtonPos = m_cachedButtonRectTrans.anchoredPosition;
                //print(m_cachedButtonPos);
            }
            else
            {
                Debug.LogError("ContextPopup close button reference is unassigned! Please assign it in the prefab.");
            }

            m_initialized = true;

            this.gameObject.SetActive(false);
        }

        public void SetContext(Sprite context)
        {
            if (!m_initialized)
                Start();

            m_cachedImage.color = Color.white;
            m_cachedImage.sprite = context;
            text.text = string.Empty;

            // Reset close button position
            m_cachedButtonRectTrans.anchoredPosition = m_cachedButtonPos;

            this.transform.SetAsLastSibling();

            this.gameObject.SetActive(true);
        }

        public void SetContext(Sprite context, Alignment alignment)
        {
            SetContext(context);

            // Set close button alignment
            Vector2 pos = Vector2.zero;            

            switch (alignment)
            {
                case Alignment.BottomCenter:
                    pos.x = 0;
                    pos.y = m_cachedButtonPos.y;
                    break;
                case Alignment.BottomLeft:
                    pos.x = -594;
                    pos.y = m_cachedButtonPos.y;
                    break;
                case Alignment.BottomRight:
                    pos.x = 594;
                    pos.y = m_cachedButtonPos.y;
                    break;
            }

            m_cachedButtonRectTrans.anchoredPosition = pos;
        }

        public void SetContext(string context, TextAnchor textAnchor = TextAnchor.MiddleCenter)
        {
            if (!m_initialized)
                Start();

            m_cachedImage.color = backgroundColor;
            m_cachedImage.sprite = backgroundImage;

            text.alignment = textAnchor;
            text.text = context;

            // Reset close button position
            m_cachedButtonRectTrans.anchoredPosition = m_cachedButtonPos;

            this.transform.SetAsLastSibling();

            this.gameObject.SetActive(true);
        }
    }
}
