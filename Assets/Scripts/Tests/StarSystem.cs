using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarSystem : MonoBehaviour
{
    public Image star;
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    void Awake()
    {
        Core.SubscribeEvent("OnUpdateBonus", OnUpdateBonus);
    }
    void OnDestroy()
    {
        Core.UnsubscribeEvent("OnUpdateBonus", OnUpdateBonus);
    }
    object OnUpdateBonus(object sender, object args)
    {
        if (args is bool)
        {
            bool bonusCorrect = (bool)args;
            Patient.CaseData.bonusCorrect = bonusCorrect;
            ToggleStar(bonusCorrect);
        }
        return null;
    }

    void ToggleStar(bool val)
    {
        if (val)
            star.sprite = enabledSprite;
        else
            star.sprite = disabledSprite;
    }
}
