using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pupil : MonoBehaviour
{
    public enum PupilState { Default, Dilated, Constricted }
    public PupilState pupilState = PupilState.Default;
    public HeadReaction head;
    public float activationRadius = 40.0f;
    public float normalSize;
    public float dilatedSize;
    public float constrictedSize;

    RectTransform _imageRect;
    public static Transform _TargetedPupil = null;

	void Awake ()
    {
        _imageRect = GetComponent<RectTransform>();
	}

    void Start()
    {
        if(_TargetedPupil == null)
            _TargetedPupil = this.transform;
    }

    void LateUpdate()
    {
        bool inProximity = Vector2.Distance(Input.mousePosition, transform.position) < activationRadius + 10.0f;
        if (inProximity)
        {
            _TargetedPupil = this.transform;
            bool inTargetProximity = Vector2.Distance(Input.mousePosition, transform.position) < activationRadius;
            if (inTargetProximity)
            {
                switch (pupilState)
                {
                    case PupilState.Default:
                        break;
                    case PupilState.Dilated:
                        ResizeEyes(dilatedSize);
                        break;
                    case PupilState.Constricted:
                        ResizeEyes(constrictedSize);
                        break;
                    default:
                        break;
                }

                head.SetMouth(HeadReaction.MouthState.OMG);
            }
            else
            {
                _TargetedPupil = null;
                ResizeEyes(normalSize);
                head.SetMouth(HeadReaction.MouthState.Smile);
            }
        }            
    }

    void ResizeEyes(float pupilSize)
    {
        _imageRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, pupilSize);
        _imageRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, pupilSize);
    }
}
