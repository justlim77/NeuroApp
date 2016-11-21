using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocaliseView : MonoBehaviour
{
    public Image localisingImage;
    public Button explanationButton;
    public Button closeExplanationButton;
    public GameObject explanationPanel;
    public Text explanationText;

    private void Start()
    {
        explanationButton.onClick.AddListener(ShowExplanation);
        closeExplanationButton.onClick.AddListener(HideExplanation);
    }

    private void OnDestroy()
    {
        explanationButton.onClick.RemoveAllListeners();
        closeExplanationButton.onClick.RemoveAllListeners();
    }

    public bool Initialize(Sprite localiseTexture, string explanation)
    {
        localisingImage.sprite = localiseTexture;
        explanationText.text = explanation;
        explanationButton.enabled = true;
        HideExplanation();

        return true;
    }

    public void ShowExplanation()
    {
        explanationPanel.SetActive(true);
    }

    public void HideExplanation()
    {
        explanationPanel.SetActive(false);
    }
}
