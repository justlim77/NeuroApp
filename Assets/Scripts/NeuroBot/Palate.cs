using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NeuroApp;

[RequireComponent(typeof(Image))]
public class Palate : MonoBehaviour
{
    public Sprite palate_normal;
    public Sprite palate_abnormal;

    Image _image;

	void Start ()
    {
        _image = GetComponent<Image>();

        Init();   
	}

    public void Init()
    {
        // Reset scale
        _image.rectTransform.localScale = Vector2.one;

        // Both normal
        if (Patient.CaseData.state_Palate_R == Patient.CaseData.state_Palate_L)
        {
            _image.sprite = palate_normal;
        }
        // Right abnormal
        else if (Patient.CaseData.state_Palate_R == State.Abnormal)
        {
            _image.sprite = palate_abnormal;
            _image.rectTransform.localScale = new Vector2(-1, 1);
        }
        // Left abnormal
        else if (Patient.CaseData.state_Palate_L == State.Abnormal)
        {
            _image.sprite = palate_abnormal;
            _image.rectTransform.localScale = Vector2.one;
        }
    }

	// Update is called once per frame
	void Update () {
	 
	}
}
