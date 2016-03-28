using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Tool : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite cursorSprite;
    public Sprite altCursorSprite;
    public GameObject toolCursor;
    public string animationTrigger = "Enter trigger name";
    public Text footer;
    public string test;
    public List<GameObject> interactiveObjects = new List<GameObject>();

    ToolControl m_ToolControl;
    bool m_ToolUsed = false;
    ToolCursor m_ToolCursorScript;
    Animator m_ToolCursorAnim;
    Image m_ToolCursorImage;
    Sprite m_ToolSprite;

    void Awake()
    {
        m_ToolControl = transform.parent.GetComponent<ToolControl>();

        //Setup tool cursor
        if (toolCursor == null) toolCursor = GameObject.Find("ToolCursor");
        m_ToolCursorScript = toolCursor.GetComponent<ToolCursor>();
        m_ToolCursorAnim = toolCursor.GetComponent<Animator>();
        m_ToolCursorImage = toolCursor.GetComponent<Image>();

        //Setup tool sprite reference
        m_ToolSprite = GetComponent<Image>().sprite;

        Init();
    }

    void Start() {}

    public void SelectTool()
    {
        m_ToolControl.ResetTools();

        footer.text = test;

        SetToolCursor();

        foreach (GameObject interactiveObject in interactiveObjects)
            interactiveObject.SetActive(true);
    }

    public void DeselectTool()
    {
        toolCursor.SetActive(false);

        //Disable all interactive objects on awake
        foreach (GameObject obj in interactiveObjects)
            obj.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!m_ToolUsed)
        {
            m_ToolControl.ToolCount();
            m_ToolUsed = true;
        }
    }

    void SetToolCursor()
    {
        m_ToolCursorImage.sprite = cursorSprite;

        Cursor.visible = false;

        if (!toolCursor.activeInHierarchy)
            toolCursor.SetActive(true);
    }

    public void AnimateTool(string animationTrigger)
    {
        if (m_ToolCursorImage.sprite == m_ToolSprite && ToolCursor.canAnimate)
        {
            m_ToolCursorAnim.SetTrigger(animationTrigger);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolCursor.canAnimate = false;
        footer.text = test;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        footer.text = string.Empty;
    }

    public void AlternateSprite(int index)
    {
        switch (index)
        {
            case 0:
                m_ToolCursorImage.enabled = false;
                m_ToolSprite = cursorSprite;
                m_ToolCursorImage.sprite = m_ToolSprite;
                m_ToolCursorScript.SetDirection(1);
                break;
            case 1:
                m_ToolCursorImage.enabled = false;
                m_ToolSprite = altCursorSprite;
                m_ToolCursorImage.sprite = m_ToolSprite;
                m_ToolCursorScript.SetDirection(-1);
                break;
        }

        m_ToolCursorImage.enabled = true;
    }

    public bool Init()
    {
        bool result = true;

        //Disable all interactive objects on awake
        foreach (GameObject interactiveObject in interactiveObjects)
        {
            //interactiveObject.GetComponent<Image>().enabled = false;
            interactiveObject.SetActive(false);
        }

        // Reset tool use flag
        m_ToolUsed = false;

        return result;
    }
}
