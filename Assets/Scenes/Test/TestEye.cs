using UnityEngine;
using System.Collections;

public class TestEye : MonoBehaviour
{
    public EyeType eyeType;
    public RectTransform outerEyeBounds;
    public RectTransform innerEyeBounds;
    public float scale;
    public float dist;

    public Vector3 normalizedDir;

    [Header("Tracking Field")]
    public Vector2 trackingFieldMin = -Vector2.one;
    public Vector2 trackingFieldMax = Vector2.one;

    [Header("Eye center")]
    public Vector2 defaultEyeCenterOffset = Vector2.zero;
    public RectTransform eyesCenter;

    public bool Follow { get; set; }
    public bool IsClamped
    {
        get { return _isClamped; }
        set { _isClamped = value; }
    }

    Vector2 _center;
    Vector2 _localCenter;
    RectTransform _rectTransform;
    Vector2 _convergePos = Vector2.zero;
    public bool _isClamped = true;

	// Use this for initialization
	void Start ()
    {
        Init();
	}

    public bool Init()
    {
        _rectTransform = GetComponent<RectTransform>(); // Cache rect transform component
        _rectTransform.anchoredPosition = Vector2.zero; // Reset to zero (if not already)

        _center = _rectTransform.position;
        _localCenter = _rectTransform.anchoredPosition;
        scale = innerEyeBounds.rect.width / _rectTransform.rect.width;
        GetRadius();
        //_radius = innerEyeBounds.rect.width * scale;

        //print(scale);
        SetLocalCenter(defaultEyeCenterOffset);

        // Deprecated in 0.3.6
        // TODO: FIX "Lazily" setting converge position based on eye laziness
        if (defaultEyeCenterOffset != Vector2.zero)
        {
            _convergePos = _localCenter;
        }
        else
        {
            _convergePos.x = eyeType == EyeType.Right ? _radius : -_radius;
        }

        Follow = false;        

        return true;
    }

    public Vector3 GetCenter()
    {
        return _center;
    }

    public Vector3 GetLocalCenter()
    {
        return _localCenter;
    }

    public void SetLocalCenter(Vector2 offset)
    {
        Vector2 scaledOffset = offset * _radius;
        _localCenter += scaledOffset;
    }

    public float GetDistanceFromMouse()
    {
        return Vector3.Distance(Input.mousePosition, _center);
    }

    [SerializeField] float _radius;
    public float GetRadius()
    {
        if (_radius == 0)
        {
            //_radius = innerEyeBounds.rect.width * scale;
            _radius = (innerEyeBounds.rect.width - _rectTransform.rect.width) * 0.5f;
        }
        //print("Radius: " + _radius);
        return _radius;
    }

    public Vector2 GetNormalizedDirection()
    {
        Vector3 pos = Input.mousePosition - _rectTransform.position;
        pos.Normalize(); 
        pos *= GetRadius();
        normalizedDir = pos;
        return pos;
    }

    public Vector2 GetClampedNormalizedDirection(Vector2 pos)
    {
        pos.x = Mathf.Clamp(pos.x, trackingFieldMin.x, trackingFieldMax.x);
        pos.y = Mathf.Clamp(pos.y, trackingFieldMin.y, trackingFieldMax.y);
        return pos;
    }

    /// <summary>
    /// [Deprecated] Use GetNormalizedDirection instead
    /// </summary>
    /// <param name="center"></param>
    /// <returns></returns>
    public Vector2 GetNormalizedDirection(Vector3 center)
    {
        Vector3 pos = Input.mousePosition - center;
        pos.Normalize();
        pos *= GetRadius();
        normalizedDir = pos;
        return pos;
    }

    public void SetAnchoredPosition(Vector3 pos)
    {
        _rectTransform.anchoredPosition = pos;
    }

    public Vector2 GetAnchoredPosition()
    {
        return _rectTransform.anchoredPosition;
    }

    public Vector2 GetConvergePosition()
    {
        return _convergePos;
    }
}

public enum EyeType
{
    Left,
    Right
}
