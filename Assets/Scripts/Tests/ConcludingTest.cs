using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using NeuroApp;

public class ConcludingTest : MonoBehaviour
{
    public TestType m_TestType = TestType.Single;
    public List<Text> optionsText = new List<Text>();
    public string[] optionsPrefix = { "A) ", "B) ", "C) ", "D) ", "E) " };
    public Color32 m_CorrectColor;
    public Color32 m_WrongColor;
    public float m_FlashDuration = 1.0f;
    public GameObject m_ButtonPrefab;
    public GameObject m_EndButton;
    public Text[] m_RationaleTexts;
    public GameObject scrollView;
    public GameObject showTableBtn;

    Answer m_Answer;
    bool m_FirstAttempt;
    int _optionCount;

	void Start ()
    {
        //Init();
	}

    public bool Init()
    {
        bool result = true;

        // Disable "Next" button
        if (m_EndButton.activeInHierarchy) m_EndButton.SetActive(false);

        // Disable rationale images
        foreach (Text text in m_RationaleTexts)
            text.enabled = false;

        // Disable scroll view
        scrollView.SetActive(false);

        // Disable peroneal table
        showTableBtn.SetActive(false);      

        // Clear any previous instantiated buttons
        transform.Clear();

        // Assign new answer
        m_Answer = Patient.CaseData.answer;

        // Iterate thru loop to create buttons...
        optionsText.Clear();

        _optionCount = 0;
        string[] testOptions = Patient.CaseData.concludingTests;

        foreach (string option in testOptions)
            if (option != string.Empty)
                _optionCount++;

        for (int i = 0; i < _optionCount; i++)
        {
            GameObject newButton = (GameObject) Instantiate(m_ButtonPrefab, Vector2.zero, Quaternion.identity);
            newButton.transform.SetParent(transform);
            ConcludingButton buttonScript = newButton.GetComponent<ConcludingButton>();
            buttonScript.Init();
            buttonScript.option = (Answer)i;
            buttonScript.correctColor = m_CorrectColor;
            buttonScript.wrongColor = m_WrongColor;
            buttonScript.buttonFlashDuration = m_FlashDuration;
            optionsText.Add(newButton.GetComponentInChildren<Text>());
            optionsText[i].text = optionsPrefix[i] + testOptions[i];
        }

        // Reset first attempt
        m_FirstAttempt = true;

        return result;
    }

    public bool ValidateAnswer(Answer answer)
    {
        bool bonusCorrect = false;

        switch (m_TestType)
        {
            case TestType.Single:
                if (answer == m_Answer)
                {
                    // Star system check
                    if (m_FirstAttempt)
                    {
                        bonusCorrect = true;

                        // Check if was able to localise (2-star)
                        if (StarSystem.Instance.StarReward == StarReward.Localised)
                        {
                            StarSystem.Instance.StarReward = StarReward.Localised | StarReward.MCQCorrect;
                            Debug.Log("2-star: Able to localise and first try MCQ correct");
                        }
                        else if(StarSystem.Instance.StarReward != (StarReward.LocaliseOnFirstTry | StarReward.NoHintsUsed))
                        {
                            StarSystem.Instance.StarReward = StarReward.MCQCorrect;
                            Debug.Log("1-star: Failed elimination test but first try MCQ correct");
                        }

                        m_FirstAttempt = false;
                    }

                    // Enable "Next" button
                    m_EndButton.SetActive(true);

                    // Enable rationale images
                    foreach (Text text in m_RationaleTexts)
                        text.enabled = true;

                    // Enable content
                    scrollView.SetActive(true);
                    ScrollManager.Instance.ResetScroll(ScrollPanelType.Explanation);

                    // TODO: Implement serialized field
                    if (Patient.CaseData.caseName == "Nerves")
                        showTableBtn.SetActive(true);

                    Core.BroadcastEvent("OnUpdateBonus", this, bonusCorrect);
                    return true;
                }
                else
                {
                    bonusCorrect = m_FirstAttempt = false;
                    Core.BroadcastEvent("OnUpdateBonus", this, bonusCorrect);
                    return false;
                }

            case TestType.Multiple:
                break;
        }

        return true;
    }
}