using UnityEngine;
using System.Collections;
using System;

public class CaseLoader : MonoBehaviour
{
    public GameObject[] playPanels;
    public GameObject nextPanel;
    public Patient patient;
    public Utilities utilities;

    // Reinitialize from scenario selection
    public LevelsPanel levelsPanel;
    public GameObject localiseButton;
    public ToolControl toolControl;
    public ToolControl cranialToolControl;
    public NeuraxisTest neuraxisTest;
    public ConcludingTest concludeTest;

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
        while (localiseButton.activeInHierarchy == true)
            localiseButton.SetActive(false);
        result = !localiseButton.activeInHierarchy;
        if (result == false)
            print("Failed to disable localise button!");

        // Reinitialize Tool Control
        result = toolControl.Init();
        if (result == false)
            print("Failed to reinitialize ToolControl!");

        // Reinitialize Cranial Tool Control
        result = cranialToolControl.Init();
        if (result == false)
            print("Failed to reinitialize Cranial ToolControl!");

        // Reinitialize Neuraxis Test
        result = neuraxisTest.Init();
        if (result == false)
            print("Failed to reinitialize NeuraxisTest!");

        // Reinitialize Concluding Test
        result = concludeTest.Init();
        if (result == false)
            print("Failed to reinitialize ConcludingTest!");

        // Initialize Scroll Bars
        result = ScrollManager.Instance.Init();
        if (result == false)
            print("Failed to reinitialize Scroll bars!");

        return result;
    }
}
