using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class Fade : MonoBehaviour
{
    public Color fadeOutColor = new Color(0, 0, 0, 0);
    public Color fadeInColor = new Color(0, 0, 0, 1);
    public enum FadeType { In, Out };
    public FadeType fadeType = FadeType.Out;
    public float fadeDuration = 0.3f;

    Image _fadeImage;

    void Awake()
    {
        _fadeImage = GetComponent<Image>();

        Init();
    }

    bool Init()
    {
        _fadeImage.color = fadeInColor;
        gameObject.transform.localPosition = Vector2.zero;
        return true;
    }

    void Start()
    {
        RunFade();
    }

    public void RunFade()
    {
        StartCoroutine(FadeRoutine());
    }

    public IEnumerator FadeRoutine()
    {
        transform.SetAsLastSibling();

        _fadeImage.enabled = true;

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

        _fadeImage.enabled = false;
    }

    void FadeAlpha(Color newColor)
    {
        _fadeImage.color = newColor;
    }

    public void SetColor(Color color)
    {
        _fadeImage.color = color;
    }
}
