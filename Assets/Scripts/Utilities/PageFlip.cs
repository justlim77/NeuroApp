using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class PageFlip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool reversed = false;

    [SerializeField] private float xScale = 1.1f;
    [SerializeField] private float yScale = 1.1f;
    [SerializeField] private float scaleTime = 0.8f;

    float m_xScale;

    void Start()
    {
        m_xScale = xScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        xScale = reversed ? -m_xScale : m_xScale;

        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(xScale, yScale, 0), "time", scaleTime));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        xScale = reversed ? -1.0f : 1.0f;

        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(xScale, 1, 0), "time", scaleTime));
    }
}
