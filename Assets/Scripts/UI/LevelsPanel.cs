using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelsPanel : MonoBehaviour
{
    public Sprite starEnabledSprite;
    public Sprite starDisabledSprite;

    [Header("WARNING: Bonus star reset!")]
    [SerializeField] bool reset = false;

    [SerializeField] Transform[] children;
    [SerializeField] Image[] starImages;

    [SerializeField] CaseButton[] caseButtons;

    private int m_childCount = 0;

	// Use this for initialization
	void Start ()
    {
        m_childCount = CaseDatabase.Instance.caseList.caseList.Count;

        LogInfo(m_childCount);

        children = new Transform[m_childCount];

        Init();
	}

    public bool Init()
    {
        starImages = new Image[m_childCount];
        for (int i = 0; i < m_childCount; i++)
        {
            if(reset)
                CaseDatabase.Instance.caseList.caseList[i].bonusCorrect = false;
            children[i] = transform.GetChild(i);
            starImages[i] = children[i].GetChild(1).GetChild(0).GetComponent<Image>();
            starImages[i].sprite = CaseDatabase.Instance.caseList.caseList[i].bonusCorrect ? starEnabledSprite : starDisabledSprite;
        }

        return true;
    }

    private void LogInfo(object message)
    {
        Debug.Log(message);
    }
}
