#define DEBUG

using UnityEngine;
using System.Collections;

public class TestEyeManager : MonoBehaviour
{
    public TestEye rightEye;
    public TestEye leftEye;

    public float followSpeed = 2.0f;

    public float converganceDistance = 10.0f;
    public float equiDistance;

    public float rightEyeDist;
    public float leftEyeDist;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        rightEyeDist = rightEye.GetDistanceFromMouse();
        leftEyeDist = leftEye.GetDistanceFromMouse();
        converganceDistance = GetConvergeDistance();
        equiDistance = GetEquidistance();

        if (equiDistance <= converganceDistance)
        {
            ConvergeLook();
        }
        else
        {
            EquidistantLook();
        }       
	}

    void EquidistantLook()
    {
        Vector3 direction = rightEyeDist < leftEyeDist ?
            Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetNormalizedDirection(), followSpeed * Time.deltaTime) :
            Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);

        rightEye.SetAnchoredPosition(direction);
        leftEye.SetAnchoredPosition(direction);
    }

    void ConvergeLook()
    {
        Vector3 rightTargetPos = Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);
        Vector3 leftTargetPos = Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);

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
