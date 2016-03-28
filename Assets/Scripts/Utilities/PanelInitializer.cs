using UnityEngine;

public class PanelInitializer : MonoBehaviour {

    public bool isHomeScreen;
    public bool isOffByDefault = true;

    public bool customPos = false;
    public Rect pos;

    RectTransform m_rect;

    void Awake()
    {
        m_rect = GetComponent<RectTransform>();
        m_rect.anchoredPosition = Vector2.zero;

        if (isHomeScreen)
            m_rect.SetAsLastSibling();

        if (customPos)
        {
            m_rect.rect.Set(0, 0, pos.width, pos.height);
            m_rect.anchoredPosition = new Vector2(pos.x, pos.y);
        }


        gameObject.SetActive(!isOffByDefault);
    }
}
