using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using NeuroApp;

public class ConcludingButton : MonoBehaviour, IPointerClickHandler {

    public Answer option;
    public Color32 correctColor;
    public Color32 wrongColor;
    public float buttonFlashDuration = 1.0f;

    private Image m_Image;
    private Color32 m_OriginalColor;
    private ConcludingTest m_ConcludingTest;
    private RectTransform m_Rect;

    public void Init() {
        m_Image = GetComponent<Image>();
        m_OriginalColor = m_Image.color;
        m_Rect = GetComponent<RectTransform>();
        m_ConcludingTest = transform.GetComponentInParent<ConcludingTest>();

        ResetScale();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(ButtonFlash(buttonFlashDuration));
    }

    public void ResetScale() {
        m_Rect.localScale = new Vector3(1, 1, 1);
    }

    private IEnumerator ButtonFlash(float flashDuration) {
        bool validate = m_ConcludingTest.ValidateAnswer(option);

        m_Image.color = validate ? correctColor : wrongColor;

        if (validate) yield break;

        yield return new WaitForSeconds(flashDuration);

        m_Image.color = m_OriginalColor;
    }
}
