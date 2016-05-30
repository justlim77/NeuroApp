using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Scrollbar))]
public class ScrollUpdate : MonoBehaviour {

    [Range(0, 1)]
    public float initialScrollValue = 1.0f;

    public Scrollbar scrollBar;

    public bool Init()
    {
        scrollBar.value = initialScrollValue;
        Canvas.ForceUpdateCanvases();

        return true;
    }

    void OnEnable()
    {
        Init();
    }
}
