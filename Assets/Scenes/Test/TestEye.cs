using UnityEngine;
using System.Collections;

public class TestEye : MonoBehaviour
{
    public EyeType eyeType;
    public RectTransform eyeBounds;
    public float scale;
    public float dist;
    public RectTransform eyesCenter;

    public Vector3 normalizedDir;

    public bool Follow { get; set; }

    Vector2 _center;
    Vector2 _localCenter;
    RectTransform _rectTransform;
    Vector2 _convergePos = Vector2.zero;

	// Use this for initialization
	void Start ()
    {
        _rectTransform = GetComponent<RectTransform>();
        _center = _rectTransform.position;
        _localCenter = _rectTransform.anchoredPosition;
        _radius = eyeBounds.rect.width * scale;
        _convergePos.x = eyeType == EyeType.Right ? _radius : -_radius;
        Follow = false;
	}

    public Vector3 GetCenter()
    {
        return _center;
    }

    public Vector3 GetLocalCenter()
    {
        return _localCenter;
    }

    public float GetDistanceFromMouse()
    {
        return Vector3.Distance(Input.mousePosition, _center);
    }

    private float _radius;
    public float GetRadius()
    {
        if (_radius == 0)
            _radius = eyeBounds.rect.width * scale;
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
