using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace NeuroApp
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField]
        Button tutorialButton;
        [SerializeField]
        Button creditsButton;

        [TextArea]
        public string CreditsText;

        // Use this for initialization
        void Start()
        {
            creditsButton.onClick.AddListener(ShowCredits);
            tutorialButton.onClick.AddListener(ShowTutorial);
        }

        private void OnDestroy()
        {
            creditsButton.onClick.RemoveListener(ShowCredits);
            tutorialButton.onClick.RemoveListener(ShowTutorial);
        }

        void ShowCredits()
        {
            NeuroApp.GUIManager.Instance.SetContext(CreditsText, TextAnchor.MiddleLeft);
        }

        void ShowTutorial()
        {
            StartCoroutine(RunShowTutorial());
        }
        IEnumerator RunShowTutorial()
        {
            yield return StartCoroutine(CaseLoader.Instance.RunLoadCase(0));

            yield return new WaitForEndOfFrame();

            GUIManager.Instance.TutorialView.ShowTutorial(true);
        }
    }

}
