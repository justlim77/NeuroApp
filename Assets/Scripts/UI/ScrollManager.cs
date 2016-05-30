using UnityEngine;
using System.Collections;

public class ScrollManager : MonoBehaviour {

    static ScrollManager _Instance = null;
    public static ScrollManager Instance
    {
        get { return _Instance; }
    }

    public ScrollUpdate[] scrollUpdaters;

    void Awake()
    {
        //if (_Instance == null)
            _Instance = this;
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDestroy()
    {
        _Instance = null;
    }

    public bool Init()
    {
        bool result = false;
        foreach (ScrollUpdate updater in scrollUpdaters)
        {
            result = updater.Init();
            if (result == false)
            {
                Debug.Log("Failed to initialize " + updater.gameObject.name);
                break;
            }
        }

        return result;
    }
}
