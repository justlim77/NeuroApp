using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using NeuroApp;

[System.Serializable]
public class Power : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public HeadReaction head;
    public Image mainPanel;
    public float activationRadius = 50.0f;
    public FaceState faceState;

    Image m_image;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        if(m_image == null)
            m_image = GetComponent<Image>();

        m_image.CrossFadeAlpha(0.0f, 0.0f, true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_image.CrossFadeAlpha(1.0f, Constants.const_alpha_fade_duration, true);
        if (!_isTesting)
            head.Reaction(FaceState.Shocked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        StartCoroutine(PowerReaction(eventData.button));

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_image.CrossFadeAlpha(0.0f, Constants.const_alpha_fade_duration, true);
        if (!_isTesting)
            head.Reaction(FaceState.Neutral);
    }

    static bool _isTesting = false;
    IEnumerator PowerReaction(PointerEventData.InputButton button)
    {
        if (_isTesting)
            yield break;

        _isTesting = true;
        head.testEyeManager.TrackMouse = false;

        switch (button)
        {
            case PointerEventData.InputButton.Left:
                head.Reaction(faceState);
                break;
            case PointerEventData.InputButton.Right:
                head.testEyeManager.ConvergeTest = true;
                break;
        }
        
        yield return new WaitForSeconds(Constants.const_power_reaction_delay);

        head.Reaction(FaceState.Neutral);
        head.testEyeManager.TrackMouse = true;
        head.testEyeManager.ConvergeTest = false;

        _isTesting = false;
    }
}
