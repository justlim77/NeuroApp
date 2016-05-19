using UnityEngine;
using System.Collections;

public class CaseLoader : MonoBehaviour
{
    public GameObject[] playPanels;
    public GameObject nextPanel;
    public Patient patient;
    public Utilities utilities;

    // Reinitialize from scenario selection
    public GameObject localiseButton;
    public ToolControl toolControl;
    public ToolControl cranialToolControl;
    public NeuraxisTest neuraxisTest;
    public ConcludingTest concludeTest;

    public void LoadCase(string caseName)
    {
        StartCoroutine(RunLoadCase(caseName));
    }

    public void ReinitializeAll()
    {
        bool result = RunReinitializeAll();
        if (result == false)
            print("Failed to reinitialize!");
    }

    IEnumerator RunLoadCase(string caseName)
    {
        patient.LoadCase(caseName);

        foreach (GameObject panel in playPanels)
        {
            panel.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }

        yield return RunReinitializeAll();

        utilities.ActivatePanel(nextPanel);
    }

    bool RunReinitializeAll()
    {
        bool result = true;

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

        return result;
    }
}
