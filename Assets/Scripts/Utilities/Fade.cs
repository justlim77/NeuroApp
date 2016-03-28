using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class Fade : MonoBehaviour {

    public Color fadeOutColor = new Color(0, 0, 0, 0);
    public Color fadeInColor = new Color(0, 0, 0, 1);
    public enum FadeType { In, Out };
    public FadeType fadeType = FadeType.Out;
    public float fadeDuration = 0.3f;

    Image m_FadeImage;

    void Awake()
    {
        m_FadeImage = GetComponent<Image>();

        Init();
    }

    void Init()
    {
        iTween.Init(gameObject);
        m_FadeImage.color = fadeInColor;
        gameObject.transform.localPosition = Vector2.zero;
    }

    void OnEnable()
    {
        StartCoroutine(RunFade());
    }

    IEnumerator RunFade()
    {
        transform.SetAsLastSibling();

        switch (fadeType)
        {
            case FadeType.Out:
                iTween.ValueTo(gameObject, iTween.Hash("from",fadeInColor,"to",fadeOutColor,"onupdate","FadeAlpha","time", fadeDuration));
                break;
            case FadeType.In:
                iTween.ValueTo(gameObject, iTween.Hash("from",fadeOutColor,"to",fadeInColor,"onupdate", "FadeAlpha","time", fadeDuration));
                break;
        }

        yield return new WaitForSeconds(fadeDuration);

        gameObject.SetActive(false);
    }

    void FadeAlpha(Color newColor)
    {
        m_FadeImage.color = newColor;
    }

    public void SetColor(Color color)
    {
        m_FadeImage.color = color;
    }
}
