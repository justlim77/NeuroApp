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

        #region Unity functions
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
        #endregion

        #region Private methods
        private void ResetContext()
        {
            if (!m_initialized)
                Start();

            m_cachedImage.preserveAspect = false;
            m_cachedImage.raycastTarget = true;
            m_cachedImage.rectTransform.anchoredPosition = Vector2.zero;    // Reset position
            m_cachedImage.rectTransform.offsetMin = Vector2.zero;
            m_cachedImage.rectTransform.offsetMax = Vector2.zero;
            m_cachedImage.color = Color.white;
            text.text = string.Empty;

            this.transform.localScale = Vector3.one;    // Reset scale

            // Reset close button position
            m_cachedButtonRectTrans.anchoredPosition = m_cachedButtonPos;
        }

        private void ShowContext()
        {
            this.transform.SetAsLastSibling();

            this.gameObject.SetActive(true);
        }
        #endregion

        #region Public functions
        public void SetContext(Sprite context)
        {
            ResetContext();

            m_cachedImage.sprite = context;

            ShowContext();
        }

        public void SetContext(Sprite context, bool preserveAspect)
        {
            SetContext(context, new Vector2(0, 0.25f));

            m_cachedImage.preserveAspect = true;
            m_cachedImage.raycastTarget = false;
            m_cachedImage.rectTransform.anchoredPosition = new Vector2(0, 145);
        }

        public void SetContext(Sprite context, Alignment alignment)
        {
            SetContext(context);

            // Set close button alignment
            Vector2 pos = Vector2.zero;            

            switch (alignment)
            {
                case Alignment.TopCenter:
                    pos.x = 0;
                    pos.y = Screen.height * 0.9f;
                    break;
                case Alignment.MiddleCenter:
                    pos.x = 0;
                    pos.y = Screen.height * 0.5f;
                    break;
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

        public void SetContext(Sprite context, Vector2 scale)
        {
            SetContext(context);

            m_cachedButtonRectTrans.anchoredPosition = new Vector2(Screen.width * scale.x, Screen.height * scale.y);
        }

        public void SetContext(string context, TextAnchor textAnchor = TextAnchor.MiddleCenter)
        {
            ResetContext();

            m_cachedImage.color = backgroundColor;
            m_cachedImage.sprite = backgroundImage;

            text.alignment = textAnchor;
            text.text = context;

            ShowContext();
        }
        #endregion
    }
}
