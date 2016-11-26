using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuView : MonoBehaviour {

    [SerializeField] Button creditsButton;

    [TextArea]
    public string CreditsText;

	// Use this for initialization
	void Start ()
    {
        creditsButton.onClick.AddListener(ShowCredits);
	}

    private void OnDestroy()
    {
        creditsButton.onClick.RemoveListener(ShowCredits);
    }

    void ShowCredits()
    {
        NeuroApp.GUIManager.Instance.SetContext(CreditsText, TextAnchor.MiddleLeft);
    }
}
