using UnityEngine;
using System.Collections;

public class TestEye : MonoBehaviour
{
    public RectTransform eyeBounds;
    public float radius;
    public float scale;
    public float dist;

    public Vector3 normalizedDir;

    public bool Follow { get; set; }

    Vector2 _center;
    RectTransform _rectTransform;

	// Use this for initialization
	void Start ()
    {
        _rectTransform = GetComponent<RectTransform>();
        _center = _rectTransform.position;
        Follow = false;
	}

    public Vector3 GetCenter()
    {
        return _center;
    }

    public float GetDistanceFromMouse()
    {
        return Vector3.Distance(Input.mousePosition, _center);
    }

    public Vector2 GetNormalizedDirection()
    {
        Vector3 pos = Input.mousePosition - _rectTransform.position;
        radius = eyeBounds.rect.width * scale;
        pos.Normalize();
        pos *= radius;
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

    // Update is called once per frame
    void Update()
    {
        //if (Follow == false)
        //{
        //    //_rectTransform.anchoredPosition = _center;
        //    return;
        //}

        //radius = eyeBounds.rect.width * scale;
        //Vector3 mousePos = Input.mousePosition;
        //dist = Vector3.Distance(mousePos, _center);

        //if (dist < radius)
        //{
        //    _rectTransform.position = _center;
        //}
        //else
        //{
        //    Vector3 newPos = mousePos - _rectTransform.position;
        //    newPos.Normalize();
        //    newPos *= radius;
        //    _rectTransform.anchoredPosition = newPos;
        //}
    }
}
