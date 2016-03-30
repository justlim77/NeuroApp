using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

[System.Serializable]
public class Power : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerExitHandler
{
    public HeadReaction head;
    public Image mainPanel;
    public float activationRadius = 50.0f;
    public HeadReaction.FaceState faceState;

    Image _image;
    Color _visibleColor = new Color(1, 1, 1, 1);
    Color _invisibleColor = new Color(1, 1, 1, 0);

    void Start()
    {
        _image = GetComponent<Image>();

        Init();
    }

    public void Init()
    {
        _image.color = _invisibleColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.color = _visibleColor;
        head.Reaction(HeadReaction.FaceState.Smile);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        head.Reaction(faceState);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = _invisibleColor;
        head.Reaction(HeadReaction.FaceState.Smile);
    }
}
