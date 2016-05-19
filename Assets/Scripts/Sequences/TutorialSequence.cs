using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialSequence : MonoBehaviour
{
    public CaseLoader caseLoader;
    public RectTransform tutorialLabel;
    public TextTyper textTyper;
    public string introMsg;
    public RectTransform bed;
    public RectTransform rightPanel;
    public string patientMsg;
    public RectTransform speechBubble;
    public string reactionMsg;
    public RectTransform descHeader;
    public RectTransform descText;
    public string descMsg;
    public RectTransform testPanel;
    public string testText;

    public Transform toolCursor;

    Button button;
    bool proceed = false;

    void Awake()
    {
        button = tutorialLabel.GetComponent<Button>();

        tutorialLabel.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        StartCoroutine(RunTutorial());
    }

    void Start() {
    }

    IEnumerator RunTutorial()
    {
        // Load case 1 : Peripheral neuropathy as tutorial stage
        caseLoader.LoadCase("Peripheral neuropathy");

        // Set parent to main panel > border panel render top
        transform.SetParent(bed.parent);
        tutorialLabel.SetParent(bed.parent);
        tutorialLabel.SetAsLastSibling();
        transform.SetSiblingIndex(tutorialLabel.GetSiblingIndex() - 1);
        yield return Type(introMsg);

        // Highlight patient & bed
        tutorialLabel.SetAsLastSibling();
        bed.SetSiblingIndex(tutorialLabel.GetSiblingIndex() - 1);
        yield return Type(patientMsg);

        // Highlight speech bubble
        rightPanel.SetAsLastSibling();
        transform.SetParent(rightPanel);
        tutorialLabel.SetParent(rightPanel);
        speechBubble.SetAsLastSibling();
        tutorialLabel.SetAsLastSibling();
        transform.SetSiblingIndex(tutorialLabel.GetSiblingIndex() - 1);
        yield return Type(reactionMsg);

        // Highlight description header & text
        speechBubble.SetSiblingIndex(bed.GetSiblingIndex() + 1);
        descHeader.SetAsLastSibling();
        descText.SetAsLastSibling();
        yield return Type(descMsg);

        // Highlight test panel
        descHeader.SetAsFirstSibling();
        descText.SetAsFirstSibling();
        testPanel.SetAsLastSibling();
        yield return Type(testText);

        // Set tool cursor to highest layer
        toolCursor.SetAsLastSibling();

        // End
        tutorialLabel.gameObject.SetActive(false);
        gameObject.SetActive(false);

        yield break;
    }

    public void Proceed()
    {
        proceed = true;
    }

    IEnumerator Type(string msg)
    {
        button.interactable = false;
        proceed = false;
        print(msg);
        yield return textTyper.RunTypeText(msg);
        button.interactable = true;
        while (!proceed)
            yield return 0;
    }
}
