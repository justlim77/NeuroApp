using UnityEngine;
using System.Collections;
using System;

namespace NeuroApp
{
    public class CaseLoader : MonoBehaviour
    {
        public delegate void LoadCaseEventHandler(object sender, EventArgs e);
        public static event LoadCaseEventHandler OnLoadCase;

        public static CaseLoader Instance { get; private set; }

        public GameObject[] playPanels;
        public GameObject nextPanel;
        public Patient patient;
        public Utilities utilities;

        // Reinitialize from scenario selection
        public LevelsPanel levelsPanel;
        public GameObject localiseButton;
        public ToolControl toolControl;
        public ToolControl cranialToolControl;
        public LocaliseView localiseView;
        public NeuraxisTest neuraxisTest;
        public ConcludingTest concludeTest;
        public StarSystem starSystem;
        public UnityEngine.UI.Text caseHeader;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public void LoadCase(int index)
        {
            StartCoroutine(RunLoadCase(index));
        }
        public void LoadNextCase()
        {
            int caseIdx = Patient.CaseIdx;
            caseIdx += 1;
            try
            {
                LoadCase(caseIdx);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                LoadCase(0);
            }

        }
        public void ReinitializeAll()
        {
            bool result = RunReinitializeAll();
            if (result == false)
                print("Failed to reinitialize!");
        }

        public IEnumerator RunLoadCase(int index, bool activateNextPanel = true)
        {
            try
            {
                patient.LoadCase(index);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                patient.LoadCase(0);
            }

            foreach (GameObject panel in playPanels)
            {
                panel.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }

            yield return RunReinitializeAll();

            if (activateNextPanel)
            {
                utilities.ActivatePanel(nextPanel);
            }
        }

        bool RunReinitializeAll()
        {
            bool result = true;

            result = levelsPanel.Init();
            if (result == false)
                print("Failed to reinitialize LevelsPanel");

            // Disable localise button
            //while (localiseButton.activeInHierarchy == true)
            //    localiseButton.SetActive(false);
            localiseButton.SetActive(true);
            result = localiseButton.activeInHierarchy;
            if (result == false)
                print("Failed to enable localise button!");

            // Reinitialize Tool Control
            result = toolControl.Init();
            if (result == false)
                print("Failed to reinitialize ToolControl!");

            toolControl.Activate();

            // Reinitialize Cranial Tool Control
            //result = cranialToolControl.Init();
            //if (result == false)
            //    print("Failed to reinitialize Cranial ToolControl!");

            // Reinitialize Neuraxis Test
            result = neuraxisTest.Init();
            if (result == false)
                print("Failed to reinitialize NeuraxisTest!");

            // Reinitialize Localising view
            result = localiseView.Initialize(patient.localisingDiagram, Patient.CaseData.localisingExplanation);
            if (result == false)
                print("Failed to reinitialize LocalisingView!");

            // Reinitialize Concluding Test
            result = concludeTest.Init();
            if (result == false)
                print("Failed to reinitialize ConcludingTest!");

            // Reinitialize Star System
            result = StarSystem.Instance.Init();
            if (result == false)
                print("Failed to reinitialize Star system!");

            // Initialize Scroll Bars
            result = ScrollManager.Instance.Init();
            if (result == false)
                print("Failed to reinitialize Scroll bars!");

            // Initialize GUI Manager
            result = GUIManager.Instance.Initialize();
            if (result == false)
                print("Failed to reinitialize GUIManager!");

            // Initialize case header for results screen
            caseHeader.text = Patient.CaseData.caseName;

            if (OnLoadCase != null)
                OnLoadCase(this, null);

            return result;
        }
    }
}
