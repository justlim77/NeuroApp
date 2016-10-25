using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NeuroApp
{
    public class GUIManager : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] Image mainPanel;
        [SerializeField] Text header;
        [SerializeField] HeadReaction mainHeadReaction;

        [Header("Animation Parameters")]
        [SerializeField] bool animate = true;

        private static Image _MainPanel = null;
        private static Text _Header = null;
        private static HeadReaction _MainHeadReaction = null;
        private static bool _Animate = true;

        void Start()
        {
            Initialize();
        }

        public bool Initialize()
        {
            if (_MainPanel == null)
            {
                _MainPanel = mainPanel;
                _MainPanel.CrossFadeColor(Constants.const_background_color, 0.0f, true, true, true);
            }
            if(_Header == null)
                _Header = header;
            if(_MainHeadReaction == null)
                _MainHeadReaction = mainHeadReaction;

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
    }
}

