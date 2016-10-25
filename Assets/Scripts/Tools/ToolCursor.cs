using UnityEngine;
using UnityEngine.UI;

public class ToolCursor : MonoBehaviour
{
    public static bool canAnimate;

    public CanvasScaler canvasScaler;
    public enum ReferenceRatio { Uniform, Height, Width }
    public ReferenceRatio referenceRatio = ReferenceRatio.Uniform;

    private RectTransform m_RectTransform;
    private float m_RectWidth;
    private float m_RectHeight;
    private Vector2 m_MouseOffset;
    private Vector3 m_InitialPos;
    private float m_ReferenceWidthRatio;
    private float m_ReferenceHeightRatio;
    private float m_RefWidth;
    private float m_RefHeight;
    private float m_Direction;

    void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_InitialPos = transform.localPosition;

        if (!canAnimate) canAnimate = true;

        m_RefWidth = canvasScaler.referenceResolution.x;
        m_RefHeight = canvasScaler.referenceResolution.y;
    }

    void OnEnable()
    {
        m_Direction = 1;
        m_ReferenceWidthRatio = Screen.width != m_RefWidth ? Screen.width / m_RefWidth : 1.0f;
        m_ReferenceHeightRatio = Screen.height != m_RefHeight ? Screen.height / m_RefHeight : 1.0f;

        switch (referenceRatio)
        {
            case ReferenceRatio.Uniform:
                m_RectWidth = (m_RectTransform.rect.width) * m_ReferenceWidthRatio;
                m_RectHeight = (m_RectTransform.rect.height) * m_ReferenceHeightRatio;
                break;
            case ReferenceRatio.Width:
                m_RectWidth = (m_RectTransform.rect.width) * m_ReferenceWidthRatio;
                m_RectHeight = (m_RectTransform.rect.height) * m_ReferenceWidthRatio;
                break;
            case ReferenceRatio.Height:
                m_RectWidth = (m_RectTransform.rect.width) * m_ReferenceHeightRatio;
                m_RectHeight = (m_RectTransform.rect.height) * m_ReferenceHeightRatio;
                break;
            default:
                break;
        }

#if UNITY_EDITOR
        //Debug.Log(m_RectWidth.ToString("F2"));
        //Debug.Log(m_RectHeight.ToString("F2"));
#endif
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.visible = true;
        SetDirection(1);
        transform.position = m_InitialPos;
    }

    void LateUpdate()
    {
        if (!gameObject.activeInHierarchy)
            return;

        m_MouseOffset = new Vector2(Input.mousePosition.x + (m_RectWidth * m_Direction), Input.mousePosition.y - m_RectHeight);
        transform.position = m_MouseOffset;
        Cursor.visible = false;
    }

    public void SetDirection(int index)
    {
        switch (index)
        {
            case 1:                
                m_RectTransform.pivot = new Vector2(1, 0);  // Normal
                break;
            case -1:
                m_RectTransform.pivot = new Vector2(0, 0);  // Inverted
                break;
        }

        m_Direction = index;
    }
}
