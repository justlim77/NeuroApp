using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace NeuroApp
{
    public class PanelManager : MonoBehaviour
    {
        static PanelManager _Instance = null;
        public static PanelManager Instance
        {
            get { return _Instance; }
        }

        public Image welcomePanel;
        public Image selectLevelPanel;
        public Image mainPanel;
        public Image powerPanel;
        public Image clinicalExamPanel;

        public UIPanel[] uiPanels;

        Dictionary<PanelType, GameObject> _panelDict = new Dictionary<PanelType, GameObject>();

        public static Image MainPanel = null;

        void Awake()
        {
            if (_Instance == null)
                _Instance = this;

            foreach (UIPanel uiPanel in uiPanels)
            {
                _panelDict[uiPanel.panelType] = uiPanel.panel;
            }

            //DontDestroyOnLoad(gameObject);
        }

        void OnDestroy()
        {
            _Instance = null;
        }

        // Use this for initialization
        void Start()
        {
            MainPanel = mainPanel;
        }

        public void PanelColor(PanelType panelType, Color color)
        {
            switch (panelType)
            {
                case PanelType.Main:
                    mainPanel.color = color;
                    break;
                default:
                    break;
            }
        }

        public void EnablePanel(PanelType panelType, bool val = true)
        {
            GameObject panel = null;
            if (_panelDict.TryGetValue(panelType, out panel))
            {
                panel.SetActive(val);
            }
        }
    }

    [System.Serializable]
    public struct UIPanel
    {
        public PanelType panelType;
        public GameObject panel;
    }
}

