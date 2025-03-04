﻿#define DEBUG

using UnityEngine;
using System.Collections;

namespace NeuroApp
{
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

        public float trackingRange = 10.0f;

        public bool TrackMouse { get; set; }
        public bool ConvergeTest { get; set; }

        private float _ipd = 0;
        private float _scaledRange = 0;
        private Vector2 _cachedRes;

        // Use this for initialization
        void Start()
        {
            _ipd = Vector2.Distance(rightEye.GetCenter(), leftEye.GetCenter());

            Init();

            CaseLoader.OnLoadCase += CaseLoader_OnLoadCase;
            _cachedRes = new Vector2(Screen.width, Screen.height);
            _scaledRange = ScreenScaledRange(trackingRange);
        }

        private void CaseLoader_OnLoadCase(object sender, System.EventArgs e)
        {
            rightEye.Init();
            leftEye.Init();
            Init();
        }

        private void OnDestroy()
        {
            CaseLoader.OnLoadCase -= CaseLoader_OnLoadCase;
        }

        void OnEnable()
        {
            Tool.OnToolSelected += Tool_OnToolSelected;
        }
        void OnDisable()
        {
            Tool.OnToolSelected -= Tool_OnToolSelected;
        }

        private void Tool_OnToolSelected(string obj)
        {
            ConvergeTest = false;
        }

        // Update is called once per frame
        void Update()
        {
            // Check for any changes in screen resolution
            if (DidScreenChange())
            {
                _scaledRange = ScreenScaledRange(trackingRange);
                _cachedRes = new Vector2(Screen.width, Screen.height);
            }

            if (!TrackMouse)
            {
                if (ConvergeTest)
                    ConvergeLook();
                else
                    CenterLook();
                return;
            }

            if (IsInRange())
            {
                EquidistantCenterLook();
            }
            else
            {
                CenterLook();
            }
        }

        bool IsInRange()
        {
            float dist = Vector2.Distance(Input.mousePosition, eyeCenterRect.position);
            //print("Range: " + _scaledRange + "Dist: " + dist + " Width: " + Screen.width);
            return dist < _scaledRange;
        }

        float ScreenScaledRange(float trackingRange)
        {
            return (trackingRange / GUIManager.GetReferenceResolution().x) * Screen.width;
        }

        void EquidistantLook()
        {
            Vector3 direction = rightEyeDist < leftEyeDist ?
                Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetNormalizedDirection(), followSpeed * Time.deltaTime) :
                Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);

            rightEye.SetAnchoredPosition(direction);
            leftEye.SetAnchoredPosition(direction);
        }

        bool DidScreenChange()
        {            
            return _cachedRes.x != Screen.width || _cachedRes.y != Screen.height;
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
                if (eye.IsClamped)
                {
                    pos = eye.GetClampedNormalizedDirection(pos);
                }
                pos *= eye.GetRadius();
                pos.x = 0;
            }
            else
            {
                pos.Normalize();
                if (eye.IsClamped)
                {
                    pos = eye.GetClampedNormalizedDirection(pos);
                }
                pos *= eye.GetRadius();
            }
            return pos;
        }

        void ConvergeLook()
        {
            //Vector3 rightTargetPos = Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);
            //Vector3 leftTargetPos = Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetNormalizedDirection(), followSpeed * Time.deltaTime);
            Vector3 rightTargetPos = Vector3.Lerp(rightEye.GetAnchoredPosition(), rightEye.GetConvergePosition(), followSpeed * Time.deltaTime);
            Vector3 leftTargetPos = Vector3.Lerp(leftEye.GetAnchoredPosition(), leftEye.GetConvergePosition(), followSpeed * Time.deltaTime);

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
            return Vector3.Distance(rightEye.GetCenter(), leftEye.GetCenter()) * 0.5f;
        }

        public void OnTrackingSpeedSliderChanged(float value)
        {
            followSpeed = value;
        }

        #region Public methods
        public bool Init()
        {
            TrackMouse = true;
            ConvergeTest = false;
            ShowInnerPupils();

            return true;
        }

        private Color _invisibleColor = new Color(1, 1, 1, 0);
        public void ShowInnerPupils(bool value = true)
        {
            SetInnerPupilColor(value ? Color.white : _invisibleColor);
        }

        public void SetInnerPupilColor(Color color)
        {
            rightEye.InnerPupilImage.color = color;
            leftEye.InnerPupilImage.color = color;
        }

        #endregion
    }
} 
