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

    Image _image;
    Color _visibleColor = new Color(1, 1, 1, 1);
    Color _invisibleColor = new Color(1, 1, 1, 0);

    void Start()
    {
        Init();
    }

    public void Init()
    {
        if(_image == null)
            _image = GetComponent<Image>();

        _image.color = _invisibleColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = _visibleColor;
        if(!_isTesting)
            head.Reaction(FaceState.Shocked);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StartCoroutine(PowerReaction());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _invisibleColor;
        if (!_isTesting)
            head.Reaction(FaceState.Neutral);
    }

    static bool _isTesting = false;
    IEnumerator PowerReaction()
    {
        if (_isTesting)
            yield break;

        _isTesting = true;

        head.Reaction(faceState);
        yield return new WaitForSeconds(Constants.const_reaction_delay);

        head.Reaction(FaceState.Neutral);

        _isTesting = false;
    }
}
