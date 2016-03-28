using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class PanelController : MonoBehaviour {

    public List<RectTransform> panels = new List<RectTransform>();

#if UNITY_EDITOR
    void OnGUI() {
        if (Application.isPlaying)
            return;

        if (GUI.Button(new Rect(10, 10, 50, 20), "Next"))
        {
            MovePanel(-1);
        }

        if (GUI.Button(new Rect(10, 40, 50, 20), "Prev"))
        {
            MovePanel(1);
        }
    }
#endif

    void MovePanel(int direction)
    {
        foreach (RectTransform panel in panels)
        {
            panel.anchoredPosition += new Vector2(panel.rect.width * direction, panel.anchoredPosition.y);
        }
    }
}
