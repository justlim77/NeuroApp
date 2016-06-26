using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using NeuroApp;

public class NeuraxisTest : MonoBehaviour
{
    #region Serialized Private variables
    [SerializeField] private Dictionary<string, bool> neuraxisDict = new Dictionary<string, bool>();
    [SerializeField] private GameObject btnNext;
    [SerializeField] private Button btnCheat;
    [SerializeField] private Button btnHint;
    [SerializeField] private Button btnSubmit;
    [SerializeField] private Text hintText;
    [SerializeField] private string[] localisingSteps;

    [SerializeField] private int scorePerCorrect = 10;
    [SerializeField] private int numOfAllowedAttempts = 2;
    [SerializeField] private int numOfLocalisingSteps;
    [SerializeField] private int _hintCost;

    [SerializeField] private NeuraxisAnswerPanel answerPanel;
    [SerializeField] private Text headerLabel;
    [SerializeField] private Text scoreLabel;

    [SerializeField] private Color32 correctColor;
    [SerializeField] private string correctString = "Good job!";
    [SerializeField] private Color32 wrongColor = new Color32(232, 108, 95, 255);
    #endregion

    #region Private variables
    private int m_NumOfCorrect;
    private int m_RequiredCorrect;
    private int m_NumOfHintsUsed;
    private Text m_SubmitText;
    private int m_PrevHintIndex;
    private Image m_SubmitImage;
    private Color32 m_OriginalColor;
    private List<NeuraxisButton> m_ButtonList = new List<NeuraxisButton>();
    #endregion

    private void Awake() 
    {      
        m_SubmitText = btnSubmit.GetComponentInChildren<Text>();
        m_SubmitImage = btnSubmit.GetComponent<Image>();
        m_OriginalColor = m_SubmitImage.color;
    }

    private void Start()
    {
        // Add neuraxis elimination data to neuraxisDictionary
        neuraxisDict.Add("C", false);
        neuraxisDict.Add("SC", false);
        neuraxisDict.Add("BS", false);
        neuraxisDict.Add("SCORD", false);
        neuraxisDict.Add("AHC", false);
        neuraxisDict.Add("R", false);
        neuraxisDict.Add("P", false);
        neuraxisDict.Add("PN", false);
        neuraxisDict.Add("NMJ", false);
        neuraxisDict.Add("M", false);

        //Init();
    }

    public bool Init() 
    {
        bool result = true;

        // Re-initialize dictionary
        neuraxisDict["C"] = Patient.CaseData.neuraxis_C;
        neuraxisDict["SC"] = Patient.CaseData.neuraxis_SC;
        neuraxisDict["BS"] = Patient.CaseData.neuraxis_BS;
        neuraxisDict["SCORD"] = Patient.CaseData.neuraxis_SCORD;
        neuraxisDict["AHC"] = Patient.CaseData.neuraxis_AHC;
        neuraxisDict["R"] = Patient.CaseData.neuraxis_R;
        neuraxisDict["P"] = Patient.CaseData.neuraxis_P;
        neuraxisDict["PN"] = Patient.CaseData.neuraxis_PN;
        neuraxisDict["NMJ"] = Patient.CaseData.neuraxis_NMJ;
        neuraxisDict["M"] = Patient.CaseData.neuraxis_M;

        // Setup buttons
        m_ButtonList.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            NeuraxisButton btn = transform.GetChild(i).GetChild(0).GetComponent<NeuraxisButton>();
            m_ButtonList.Add(btn);
            btn.correctAnswer = neuraxisDict[btn.abbreviation];
        }

        // Add localising steps array
        localisingSteps = Patient.CaseData.localisingSteps;
        numOfLocalisingSteps = 0;

        // Count number of valid localising steps (empty fields excluded)
        for (int i = 0; i < localisingSteps.Length; i++)
        {
            string _string = localisingSteps[i];
            if (!string.IsNullOrEmpty(_string))
                numOfLocalisingSteps++;
        }

        // Reset buttons
        ToggleButtons(true);        

        // Reset 'Next' button
        while (btnNext.activeInHierarchy == true)
            btnNext.SetActive(false);
        result = !btnNext.activeInHierarchy;
        if (result == false)
            print("Failed to disable Neuraxis Next button!");

        // Reset 'Submit' button's color and text
        m_SubmitImage.color = m_OriginalColor;
        m_SubmitText.text = "Submit";

        // Require the player to match all neuraxis specifications as per condition
        m_RequiredCorrect = transform.childCount;

        // Reset hint text
        while(!string.IsNullOrEmpty(hintText.text))
            hintText.text = string.Empty;
        result = string.IsNullOrEmpty(hintText.text);
        if (result == false)
            print("Failed to clear hint label!");

        // Reset private variables
        m_PrevHintIndex = -1;   // Reset hint previous index
        m_NumOfHintsUsed = 0;   // Reset hints used
        m_NumOfCorrect = 0;
        numOfAllowedAttempts = 2;

        // Initialize buttons
        foreach (NeuraxisButton button in m_ButtonList)
            result = button.Init();

        // Initialize answer panel
        answerPanel.Init();

        // Reset header label
        headerLabel.text = "Eliminate the unlikely sites.";

        if (result == true)
            print("Successfully initialized Neuraxis Test!");

        return result;
    }

    public void UseHint()
    {
        m_NumOfHintsUsed++;
        m_NumOfHintsUsed = Mathf.Clamp(m_NumOfHintsUsed, 0, numOfLocalisingSteps);

        hintText.text = GetRandomLocalisation();

        //headerLabel.text = m_NumOfCorrect == m_RequiredCorrect
        //    ? string.Format("You correctly chose {0} out of {1} eliminations!", m_NumOfCorrect, m_RequiredCorrect) // All correct     
        //    : numOfAllowedAttempts > 0 ? GetRandomLocalisation()                              // Show random localising step hint
        //    : string.Format("You correctly chose {0} out of {1} eliminations. You'll do better next time!", m_NumOfCorrect, m_RequiredCorrect);
    }

    public void CheckMatches() 
    {
        numOfAllowedAttempts--;

        m_NumOfCorrect = 0;
        foreach(var btn in m_ButtonList)
        {
            if (btn.NeuraxisMatch())
                m_NumOfCorrect++;
        }

        headerLabel.text = m_NumOfCorrect == m_RequiredCorrect
            ? string.Format("You correctly chose {0} out of {1} eliminations!", m_NumOfCorrect, m_RequiredCorrect)
            //: numOfAllowedAttempts > 0 ? string.Format("You got {0} of {1} correct. Please try again.", m_NumOfCorrect, m_RequiredCorrect)            
            : numOfAllowedAttempts > 0 ? "You have one more try."
            : string.Format("You correctly chose {0} out of {1} eliminations. You'll do better next time!", m_NumOfCorrect, m_RequiredCorrect);

        bool hasWon = m_NumOfCorrect >= m_RequiredCorrect;
        StartCoroutine(ShowFeedback(hasWon));
        btnNext.SetActive(hasWon);

        // If run out of attempts or got all correct
        if (numOfAllowedAttempts <= 0 || hasWon) 
        {
            ToggleButtons(false);
            btnNext.SetActive(true);
            hintText.text = "";

            foreach (var btn in m_ButtonList)
            {
                btn.SetHighlight();
            }

            answerPanel.UpdateAnswers(m_ButtonList);

            scoreLabel.text = string.Format("You scored {0} out of 100.", Score);
        }
    }

    private IEnumerator ShowFeedback(bool value) 
    {
        if (!value)
        {
            m_SubmitImage.color = wrongColor;
            yield return new WaitForSeconds(1.0f);
            m_SubmitImage.color = m_OriginalColor;
            m_SubmitText.text = "Submit";
        }
        else 
        {
            m_SubmitImage.color = correctColor;
            m_SubmitText.text = correctString;
        }
    }

    private string GetRandomLocalisation() 
    {
        string localisationString = string.Empty;
        int arrayLength = localisingSteps.Length;
        
        m_PrevHintIndex++;
        if (m_PrevHintIndex >= arrayLength)
            m_PrevHintIndex = 0;

        localisationString = localisingSteps[m_PrevHintIndex];
        if (string.IsNullOrEmpty(localisationString))
        {
            m_PrevHintIndex = 0;
            localisationString = localisingSteps[m_PrevHintIndex];
        }

        return localisationString;
    }

    int Score
    {
        get
        {
           return Mathf.Clamp(((m_NumOfCorrect * scorePerCorrect) - (m_NumOfHintsUsed * _hintCost)), 0, 100);
        }
    }

    bool ToggleButtons(bool val)
    {
        btnCheat.interactable = val;
        btnCheat.GetComponent<PlaySFX>().enabled = val;
        btnCheat.GetComponent<ButtonPressed>().enabled = val;
        btnHint.interactable = val;
        btnHint.GetComponent<PlaySFX>().enabled = val;
        btnHint.GetComponent<ButtonPressed>().enabled = val;
        btnSubmit.interactable = val;
        btnSubmit.GetComponent<PlaySFX>().enabled = val;
        btnSubmit.GetComponent<ButtonPressed>().enabled = val;
        btnNext.SetActive(!val);
        return true;
    }
}
