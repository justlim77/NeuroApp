#define DEBUG

using UnityEngine;
using System.Collections;

public class TestEyeManager : MonoBehaviour
{
    public TestEye rightEye;
    public TestEye leftEye;
    public RectTransform eyeCenterRect;
    
    public float followSpeed = 2.0f;

    public float converganceDistance = 10.0f;
    public float equiDistance;

    public float rightEyeDist;
    public float leftEyeDist;

    public bool TrackMouse { get; set; }

    private float _ipd = 0;

	// Use this for initialization
	void Start ()
    {
        _ipd = Vector2.Distance(rightEye.GetCenter(), leftEye.GetCenter());
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!TrackMouse)
        {
            CenterLook();
            return;
        }

        //rightEyeDist = rightEye.GetDistanceFromMouse();
        //leftEyeDist = leftEye.GetDistanceFromMouse();
        //converganceDistance = GetConvergeDistance();
        //equiDistance = GetEquidistance();

        //if (equiDistance <= converganceDistance)
        //{
        //    ConvergeLook();
        //}
        //else
        //{
            //EquidistantLook();
            EquidistantCenterLook();
        //}       
	}

    void EquidistantLook()
    {
        Vector3 direction = rightEyeDist < leftEyeDist ?
            Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetNormalizedDirection(), followSpeed * Time.deltaTime) :
            Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);

        rightEye.SetAnchoredPosition(direction);
        leftEye.SetAnchoredPosition(direction);
    }

    void EquidistantCenterLook()
    {

        Vector3 r_pos = Vector3.Lerp(rightEye.GetAnchoredPosition(), GetNormalizedDirection(rightEye), followSpeed * Time.deltaTime);
        Vector3 l_pos = Vector3.Lerp(leftEye.GetAnchoredPosition(), GetNormalizedDirection(leftEye), followSpeed * Time.deltaTime);

        rightEye.SetAnchoredPosition(r_pos);
        leftEye.SetAnchoredPosition(l_pos);
    }

    Vector2 GetNormalizedDirection(TestEye eye)
    {
        Vector3 pos = Input.mousePosition - eyeCenterRect.position;
        //Debug.Log(pos);
        //Debug.Log(_ipd);
        //pos.Normalize();
        if (pos.x > -_ipd * 0.5f && pos.x < _ipd * 0.5f)
        {
            pos.Normalize();
            pos *= eye.GetRadius();
            pos.x = 0;
        }
        else
        {
            pos.Normalize();
            pos *= eye.GetRadius();
        }
        return pos;
    }

    void ConvergeLook()
    {
        Vector3 rightTargetPos = Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);
        Vector3 leftTargetPos = Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);

        rightEye.SetAnchoredPosition(rightTargetPos);
        leftEye.SetAnchoredPosition(leftTargetPos);
    }

    void CenterLook()
    {
        Vector3 rightTargetPos = Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetLocalCenter(), followSpeed * Time.deltaTime);
        Vector3 leftTargetPos = Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetLocalCenter(), followSpeed * Time.deltaTime);

        rightEye.SetAnchoredPosition(rightTargetPos);
        leftEye.SetAnchoredPosition(leftTargetPos);
    }

    float GetEquidistance()
    {
        return Mathf.Abs(rightEyeDist - leftEyeDist);
    }

    float GetConvergeDistance()
    {
        return Vector3.Distance(rightEye.GetCenter(),leftEye.GetCenter()) * 0.5f;
    }

    public void OnTrackingSpeedSliderChanged(float value)
    {
        followSpeed = value;
    }
}
