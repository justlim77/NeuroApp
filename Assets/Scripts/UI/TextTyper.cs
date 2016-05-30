using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class TextTyper : MonoBehaviour {

    public string message;
    public float letterPause = 0.075f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;

    Text _text;
    WaitForSeconds _letterPause;
    bool _skip = false;

    public bool Init()
    {
        if (_text == null)
            _text = GetComponent<Text>();

        _letterPause = new WaitForSeconds(letterPause);

        return true;
    }

    void Start()
    {
    }

    public IEnumerator RunTypeText(string messageToType)
    {
        Clear();

        // Initialize
        message = messageToType;
        char[] messageArray = new char[0];
        messageArray = message.ToCharArray();

        // Type staggered chars
        foreach (char letter in messageArray)
        {
            _text.text += letter;
            if (typeSound1 && typeSound2)
                AudioManager.Instance.RandomizeSFX(typeSound1, typeSound2);
            if (_skip)
            {
                Skip();
                yield break;
            }
            else            
                yield return _letterPause;
        }
    }

    public void Clear()
    {
        if (_text != null)
            _text.text = string.Empty;
        message = string.Empty;
        _skip = false;
    }

    public void Skip()
    {
        _text.text = message;
    }

    public void FadeText()
    {
        _text.CrossFadeAlpha(0.0f, 1.0f, true);
    }
}