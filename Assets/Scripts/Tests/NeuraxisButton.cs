using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class NeuraxisButton : MonoBehaviour, IPointerClickHandler
{
    public Color32 neutralColor = new Color32(250, 222, 97, 255);
    public Color32 correctColor = new Color32(134, 188, 61, 255);
    public Color32 wrongColor   = new Color32(100, 100, 100, 255);
    public Color32 enabledTextColor = Color.white;
    public Color32 disabledTextColor = new Color32(255, 255, 255, 128);
    public string neuraxisName  = "Enter full neuraxis name";
    public string abbreviation  = "Enter abbreviation";
    public bool correctAnswer   = false;    // True: likely / False: eliminate
    public bool eliminate       = false;
    public Elimination elimination = Elimination.Likely;
    public Text text;

    private Image _image;
    Button _button;

    void Awake() 
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    void Start() 
    {
        Init();
    }

    public bool Init()
    {
        bool result = true;

        _image.color = neutralColor;
        text.color = Color.white;

        _image.CrossFadeAlpha(1, 0, false);
        text.CrossFadeAlpha(1, 0, false);

        eliminate = false;
        elimination = Elimination.Likely;

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

        if (eliminate == true)
        {
            elimination = Elimination.NotLikely;
            _image.CrossFadeAlpha(0, .2f, false);
            text.CrossFadeAlpha(0.5f, .2f, false);
        }
        else
        {
            elimination = Elimination.Likely;
            _image.CrossFadeAlpha(1, .2f, false);
            text.CrossFadeAlpha(1, .2f, false);
        }
    }

    public bool NeuraxisMatch() 
    {        
        if ((elimination.Equals(Elimination.Likely) && correctAnswer == true && eliminate == false) ||
            elimination.Equals(Elimination.NotLikely) && correctAnswer == false && eliminate == true)
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
        //_image.color = correctAnswer ? wrongColor : correctColor;
        _button.interactable = false;
    }
}

public enum Elimination
{
    Likely,
    NotLikely
}
