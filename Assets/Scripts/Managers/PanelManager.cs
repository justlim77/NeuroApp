using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

        public static Image MainPanel = null;

        void Awake()
        {
            if (_Instance == null)
                _Instance = this;
            else if (_Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        // Use this for initialization
        void Start()
        {
            MainPanel = mainPanel;
        }

        public void PanelColor(PanelType panelType, Color color)
        {
            switch(panelType)
            {
                case PanelType.Main:
                    mainPanel.color = color;
                    break;
                default:
                    break;
            }
        }
    }
}

