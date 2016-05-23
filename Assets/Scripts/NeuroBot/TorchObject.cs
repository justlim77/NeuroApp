using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using NeuroApp;
using System;

[RequireComponent(typeof(Image))]
public class TorchObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tongue;
    public Sprite palate_normal;
    public Sprite palate_abnormal;
    public Sprite tongue_normal;
    public Sprite tongue_abnormal;

    Image _palateImage;
    Image _tongueImage;
    CanvasGroup _palateCanvas;
    CanvasGroup _tongueCanvas;

	void Start ()
    {
        Init();   
	}

    public void Init()
    {
        if(_palateImage == null)
            _palateImage = GetComponent<Image>();
        if(_palateCanvas == null)
            _palateCanvas = GetComponent<CanvasGroup>();
        if(_tongueImage == null)
            _tongueImage = tongue.GetComponent<Image>();
        if(_tongueCanvas == null)
            _tongueCanvas = tongue.GetComponent<CanvasGroup>();

        _palateCanvas.alpha = _tongueCanvas.alpha = 0;

        // Reset scale
        _palateImage.rectTransform.localScale = _tongueImage.rectTransform.localScale = Vector2.one;

        // Check palate
        // Palate both normal
        if (Patient.CaseData.state_Palate_R == Patient.CaseData.state_Palate_L)
        {
            _palateImage.sprite = palate_normal;
        }
        // Right abnormal
        else if (Patient.CaseData.state_Palate_R == State.Abnormal)
        {
            _palateImage.sprite = palate_abnormal;
            _palateImage.rectTransform.localScale = new Vector2(-1, 1);
        }
        // Left abnormal
        else if (Patient.CaseData.state_Palate_L == State.Abnormal)
        {
            _palateImage.sprite = palate_abnormal;
            _palateImage.rectTransform.localScale = Vector2.one;
        }

        // Check tongue
        // Tongue both normal
        if (Patient.CaseData.state_Tongue_R == Patient.CaseData.state_Tongue_R)
        {
            _tongueImage.sprite = tongue_normal;
        }
        // Right abnormal
        else if (Patient.CaseData.state_Tongue_R == State.Abnormal)
        {
            _tongueImage.sprite = tongue_abnormal;
            _tongueImage.rectTransform.localScale = new Vector2(-1, 1);
        }
        // Left abnormal
        else if (Patient.CaseData.state_Tongue_L == State.Abnormal)
        {
            _tongueImage.sprite = tongue_abnormal;
            _tongueImage.rectTransform.localScale = Vector2.one;
        }
    }

	// Update is called once per frame
	void Update () {
	 
	}

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        _palateCanvas.alpha = _tongueCanvas.alpha = 1;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        _palateCanvas.alpha = _tongueCanvas.alpha = 0;
    }
}
