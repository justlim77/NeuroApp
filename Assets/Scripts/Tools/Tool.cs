using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using NeuroApp;

public class Tool : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite cursorSprite;
    public Sprite altCursorSprite;
    public GameObject toolCursor;
    public string animationTrigger = "Enter trigger name";
    public Text footer;
    public string test;
    public bool hasGradient = false;
    public List<GameObject> interactiveObjects = new List<GameObject>();

    public ColorType ColorType;

    Color _BackgroundColor;
    ToolControl m_ToolControl;
    bool m_ToolUsed = false;
    ToolCursor m_ToolCursorScript;
    Animator m_ToolCursorAnim;
    Image m_ToolCursorImage;
    Sprite m_ToolSprite;
    Image _image;
    Image _gradientImage;    

    void Awake()
    {
        m_ToolControl = transform.parent.GetComponent<ToolControl>();

        //Setup tool cursor
        if (toolCursor == null) toolCursor = GameObject.Find("ToolCursor");
        m_ToolCursorScript = toolCursor.GetComponent<ToolCursor>();
        m_ToolCursorAnim = toolCursor.GetComponent<Animator>();
        m_ToolCursorImage = toolCursor.GetComponent<Image>();
        _gradientImage = toolCursor.transform.GetChild(0).GetComponent<Image>();
        
        //Setup tool sprite reference
        _image = this.GetComponent<Image>();
        m_ToolSprite = _image.sprite;
        cursorSprite = m_ToolSprite;

        switch (ColorType)
        {
            case ColorType.Background:
                _BackgroundColor = Constants.const_background_color;
                break;
            case ColorType.Reaction:
                _BackgroundColor = Constants.const_tap_reaction_color;
                break;
            case ColorType.NoReaction:
                _BackgroundColor = Constants.const_tap_no_reaction_color;
                break;
        }
        //_BackgroundColor = Constants.const_background_color;

        Init();
    }

    void Start() {}

    public void SelectTool()
    {
        m_ToolControl.ResetTools();

        footer.text = test;

        SetToolCursor();

        PanelManager.Instance.mainPanel.color = _BackgroundColor;

        foreach (GameObject interactiveObject in interactiveObjects)
            interactiveObject.SetActive(true);

        // Set tool color to used color
        _image.color = Constants.const_tool_use_color;
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

        _gradientImage.enabled = hasGradient;

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

        if(_image == null)
            _image = this.GetComponent<Image>();    

        //Disable all interactive objects on awake
        foreach (GameObject interactiveObject in interactiveObjects)
        {
            //interactiveObject.GetComponent<Image>().enabled = false;
            interactiveObject.SetActive(false);
        }

        // Reset tool use flag
        m_ToolUsed = false;

        // Reset color
        _image.color = Color.white;

        return result;
    }
}
