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

    Image _Image;
    Color32 _OriginalColor;
    ConcludingTest _ConcludingTest;
    RectTransform _RectTransform;

    public void Init()
    {
        _Image = GetComponent<Image>();
        _OriginalColor = _Image.color;
        _RectTransform = GetComponent<RectTransform>();
        _ConcludingTest = transform.GetComponentInParent<ConcludingTest>();

        ResetScale();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(ButtonFlash(buttonFlashDuration));
    }

    public void ResetScale()
    {
        _RectTransform.localScale = Vector3.one;
    }

    IEnumerator ButtonFlash(float flashDuration)
    {
        bool validate = _ConcludingTest.ValidateAnswer(option);

        _Image.color = validate ? correctColor : wrongColor;

        if (validate) yield break;

        yield return new WaitForSeconds(flashDuration);

        _Image.color = _OriginalColor;
    }
}
