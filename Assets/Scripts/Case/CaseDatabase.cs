using UnityEngine;

[System.Serializable]
public class CaseDatabase : MonoBehaviour
{
    static CaseDatabase _Instance;
    public static CaseDatabase Instance
    {
        get
        {
            return _Instance;
        }
    }
    public CaseList caseList;

    void Awake()
    {
        _Instance = this;
    }

    void OnDestroy()
    {
        _Instance = null;
    }
}
