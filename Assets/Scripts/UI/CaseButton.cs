using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CaseButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Text levelText;
    [SerializeField] Transform starParent;
    [SerializeField] Image[] stars;

    public Button Button
    {
        get
        {
            return button;
        }
    }

    public Image[] CreateStars(int amount, Sprite defaultSprite = null)
    {
        // Clear all stars
        starParent.Clear();

        stars = new Image[amount];

        for (int i = 0; i < amount; i++)
        {
            // Instantiate gameObject
            GameObject star = Instantiate(new GameObject("Star" + i)) as GameObject;
            star.transform.SetParent(starParent);

            // Initialize stars
            Image image = star.AddComponent<Image>();
            image.sprite = defaultSprite;
            image.raycastTarget = false;
            image.preserveAspect = true;
            stars[i] = image;
        }

        return stars;
    }

    public void SetLevelText(string level)
    {
        levelText.text = level;
    }

    public void SetLevelText(int level)
    {
        levelText.text = level.ToString();
    }

    public void SetScore(int score, Sprite enabledStar, Sprite disabledStar)
    {        
        for(int i = 0; i < stars.Length; i++)
        {
            stars[i].sprite = i < score ? enabledStar : disabledStar;
        }
    }

    public void SetName(string name)
    {
        this.name = name;
    }
}
