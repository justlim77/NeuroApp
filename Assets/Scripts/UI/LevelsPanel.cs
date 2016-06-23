using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelsPanel : MonoBehaviour
{
    public Sprite starEnabledSprite;
    public Sprite starDisabledSprite;

    [SerializeField] Transform[] children;
    [SerializeField] Image[] starImages;

	// Use this for initialization
	void Start ()
    {
        Init();
	}

    public bool Init()
    {
        int childCount = transform.childCount;
        children = new Transform[childCount];
        starImages = new Image[childCount];
        for (int i = 0; i < childCount; i++)
        {
            children[i] = transform.GetChild(i);
            starImages[i] = children[i].GetChild(1).GetChild(0).GetComponent<Image>();
            starImages[i].sprite = CaseDatabase.Instance.caseList.caseList[i].bonusCorrect ? starEnabledSprite : starDisabledSprite;
        }

        return true;
    }
}
