using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using NeuroApp;

public class ConcludingButton : MonoBehaviour, IPointerClickHandler
{
    public Answer option;
    public Color32 correctColor;
    public Color32 wrongColor;
    public float buttonFlashDuration = 1.0f;

    Image _image;
    Color32 _originalColor;
    ConcludingTest _concludingTest;
    RectTransform _rect;

    public void Init()
    {
        _image = GetComponent<Image>();
        _originalColor = _image.color;
        _rect = GetComponent<RectTransform>();
        _concludingTest = transform.GetComponentInParent<ConcludingTest>();

        ResetScale();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(ButtonFlash(buttonFlashDuration));
    }

    public void ResetScale()
    {
        _rect.localScale = Vector3.one;
    }

    IEnumerator ButtonFlash(float flashDuration)
    {
        bool validate = _concludingTest.ValidateAnswer(option);

        _image.color = validate ? correctColor : wrongColor;

        if (validate) yield break;

        yield return new WaitForSeconds(flashDuration);

        _image.color = _originalColor;
    }
}
