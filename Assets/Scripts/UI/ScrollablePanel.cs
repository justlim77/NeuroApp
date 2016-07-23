using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class ScrollablePanel
{
    public ScrollPanelType ScrollPanelType;
    public Scrollbar VerticalBar;

    public void Reset(float value = 1.0f)
    {
        Canvas.ForceUpdateCanvases();
        VerticalBar.value = value;
        Canvas.ForceUpdateCanvases();
    }
}

public enum ScrollPanelType
{
    Power,
    Cheat,
    Clinical,
    Credits,
    Localising,
    Explanation,
    Speech
}
