using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NeuraxisButton : MonoBehaviour, IPointerClickHandler
{
    public Color32 neutralColor = new Color32(250, 222, 97, 255);
    public Color32 correctColor = new Color32(134, 188, 61, 255);
    public Color32 wrongColor   = new Color32(100, 100, 100, 255);
    public string neuraxisName  = "Enter full neuraxis name";
    public string abbreviation  = "Enter abbreviation";
    public bool correctAnswer   = false;    // True: eliminate / False: likely to have
    public bool eliminate       = false;

    public Image crossImage;
    public Text text;

    private Image m_Image;
    Button _button;

    void Awake() 
    {
        m_Image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    void Start() 
    {
        Init();
    }

    public bool Init()
    {
        bool result = true;

        if (m_Image.color != neutralColor)
            m_Image.color = neutralColor;

        if (eliminate)
            eliminate = false;

        if (crossImage.enabled)
            crossImage.enabled = false;

        _button.interactable = true;

        return result;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            if (text.text == abbreviation)
                ToggleText(neuraxisName, 15);
            else 
                ToggleText(abbreviation, 40);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        // If button isn't interactable, return
        if (!_button.interactable)
            return;

        //Toggle between selected & deselected
        eliminate = !eliminate;

        //Toggle cross image between off and on
        crossImage.enabled = !crossImage.enabled;
    }

    public bool NeuraxisMatch() 
    {
        if (eliminate == correctAnswer)
            return true;
        else
            return false;
    }

    void ToggleText(string textType, int maxSize)
    {
        text.resizeTextMaxSize  = maxSize;
        text.text               = textType;
    }

    public void SetHighlight()
    {
        m_Image.color = correctAnswer ? wrongColor : correctColor;
        _button.interactable = false;
    }
}
