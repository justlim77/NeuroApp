using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Scrollbar))]
public class ScrollUpdate : MonoBehaviour {

    [Range(0, 1)]
    public float initialScrollValue = 1.0f;

    Scrollbar scrollBar;

    void Awake() {
        scrollBar = this.GetComponent<Scrollbar>();
    }

    public bool Init()
    {
        scrollBar.value = initialScrollValue;
        Canvas.ForceUpdateCanvases();

        return true;
    }
}
