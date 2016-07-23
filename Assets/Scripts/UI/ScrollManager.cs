using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScrollManager : MonoBehaviour {

    static ScrollManager _Instance = null;
    public static ScrollManager Instance
    {
        get { return _Instance; }
    }

    [SerializeField] ScrollablePanel[] _ScrollablePanels;

    [Range(0f, 1f)]
    [SerializeField] float _InitialScrollValue = 1.0f;

    private Dictionary<ScrollPanelType, ScrollablePanel> _ScrollablePanelDict = new Dictionary<ScrollPanelType, ScrollablePanel>();

    void Awake()
    {
        if (_Instance == null)
            _Instance = this;
    }

    void OnDestroy()
    {
        _Instance = null;
    }

    void Start()
    {
        foreach (var panel in _ScrollablePanels)
        {
            _ScrollablePanelDict.Add(panel.ScrollPanelType, panel);
        }
    }

    public bool Init()
    {
        bool result = true;
        foreach (ScrollablePanel panel in _ScrollablePanels)
        {
            panel.Reset();

            if (result == false)
            {
                Debug.Log("Failed to initialize " + panel.ScrollPanelType.ToString());
                break;
            }
        }

        return result;
    }

    public void ResetScroll(ScrollPanelType panelType)
    {
        ScrollablePanel panel = null;
        if (_ScrollablePanelDict.TryGetValue(panelType, out panel))
        {
            panel.Reset();
        }
    }
}
