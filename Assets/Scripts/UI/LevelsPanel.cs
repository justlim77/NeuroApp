using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace NeuroApp
{
    public class LevelsPanel : MonoBehaviour
    {
        public GameObject caseButtonPrefab;
        public Sprite starSprite;

        [Header("WARNING: Bonus star reset!")]
        [SerializeField]
        bool reset = false;

        [SerializeField]
        CaseButton[] caseButtons;

        private List<Case> m_cases;
        private int m_childCount = 0;

        // Use this for initialization
        void Start()
        {
            m_cases = CaseDatabase.Instance.caseList.caseList;
            m_childCount = m_cases.Count;

            LogInfo(m_childCount);

            // Clear children
            transform.Clear();

            // Initialize case buttons
            caseButtons = CreateCaseButtons(m_cases.Count);

            Init();
        }

        public bool Init()
        {
            // Initialize stars
            SetScore();

            return true;
        }

        private void LogInfo(object message)
        {
            //Debug.Log(message);
        }

        CaseButton[] CreateCaseButtons(int amount)
        {
            CaseButton[] buttons = new CaseButton[amount];

            // Spawn buttons
            for (int i = 0; i < amount; i++)
            {
                GameObject button = Instantiate(caseButtonPrefab, this.transform) as GameObject;

                CaseButton caseButton = button.GetComponent<CaseButton>();
                caseButton.SetName(m_cases[i].caseName);
                caseButton.CreateStars(Constants.const_max_stars, starSprite);
                caseButton.SetLevelText(i + 1);
                int _idx = i;
                caseButton.Button.onClick.AddListener(() =>
                {
                    CaseLoader.Instance.LoadCase(_idx);
                });
                buttons[i] = caseButton;
            }
            return buttons;
        }

        void SetScore()
        {
            for (int i = 0; i < m_cases.Count; i++)
            {
                caseButtons[i].SetScore(m_cases[i].stars);
            }
        }
    }
}
