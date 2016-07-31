using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NeuraxisAnswerPanel : MonoBehaviour
{
    public EliminationButton[] buttons;
    public GameObject correctAnswerLabel;
    public Image AnswerBorder;

	void Start ()
    {
        Init();
	}

    public bool Init()
    {
        gameObject.SetActive(false);
        correctAnswerLabel.SetActive(false);
        foreach (var button in buttons)
        {
            button.Image.CrossFadeAlpha(1, 0, false);
            button.Text.CrossFadeAlpha(1, 0, false);
        }
        AnswerBorder.CrossFadeAlpha(0, 0, true);
        return true;
    }

    public void UpdateAnswers(List<NeuraxisButton> buttonList)
    {
        gameObject.SetActive(true);
        correctAnswerLabel.SetActive(true);

        int buttonCount = buttonList.Count;
        for (int i = 0; i < buttonCount; i++)
        {
            // Fade to half-opacity if not likely site
            if (buttonList[i].correctAnswer == false)
            {
                buttons[i].Image.CrossFadeAlpha(0, .5f, false);
                buttons[i].Text.CrossFadeAlpha(0.5f, .5f, false);
            }
            // Highlight fully if likely site
            else
            {
                buttons[i].Image.CrossFadeAlpha(1, .5f, false);
                buttons[i].Text.CrossFadeAlpha(1, .5f, false);
            }
        }
        AnswerBorder.CrossFadeAlpha(1, 1, false);
    }
}

[System.Serializable]
public struct EliminationButton
{
    public Image Image;
    public Text Text;
}
