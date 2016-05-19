using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class TextTyper : MonoBehaviour {

    public string message;
    public float letterPause = 0.075f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;

    Text m_Text;
    WaitForSeconds m_LetterPause;
    bool _skip = false;

    void OnEnable()
    {
        if (m_Text == null)
            m_Text = GetComponent<Text>();
        Clear();
    }

    void Awake()
    {
        if (m_Text == null)
            m_Text = GetComponent<Text>();
        m_LetterPause = new WaitForSeconds(letterPause);
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
            m_Text.text += letter;
            if (typeSound1 && typeSound2)
                AudioManager.Instance.RandomizeSFX(typeSound1, typeSound2);
            if (_skip)
            {
                Skip();
                yield break;
            }
            else            
                yield return m_LetterPause;
        }
    }

    public void Clear()
    {
        if (m_Text != null)
            m_Text.text = string.Empty;
        message = string.Empty;
        _skip = false;
    }

    public void Skip()
    {
        m_Text.text = message;
    }

    public void FadeText()
    {
        m_Text.CrossFadeAlpha(0.0f, 1.0f, true);
    }
}