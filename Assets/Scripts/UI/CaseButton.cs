using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaseButton : MonoBehaviour
{
    public Button button;  
    public Text levelText;
    public Image[] stars;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {

    }

    public Button Button { get { return button; } }
    public Text LevelText { get { return levelText; } }
    public Image[] Stars { get { return stars; } }

    public Image[] CreateStars(int amount)
    {
        stars = new Image[amount];
        return stars;
    }

    public void SetLevelText(string level)
    {
        levelText.text = level;
    }

    public void SetScore(int score, Sprite enabledStar, Sprite disabledStar)
    {
        for(int i = 0; i < score; i++)
        {
            stars[i].sprite = enabledStar;
        }
    }

    public void SetObjectName(string name)
    {
        this.name = name;
    }
}
