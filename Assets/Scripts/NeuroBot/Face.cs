using UnityEngine;
using System.Collections;
using NeuroApp;

[System.Serializable]
public class Face
{
    [Header("Eye droop")]
    public bool rightEyeDroop = false;
    public bool leftEyeDroop = false;

    [Header("Default pupil state")]
    public PupilState rightPupilState;
    public PupilState leftPupilState;
    public Vector2 rightEyeDefaultOffset = Vector2.zero;
    public Vector2 leftEyeDefaultOffset = Vector2.zero;

    [Header("Visual Fields Regions")]
    public Vector2 visualFieldMin_R = -Vector2.one;
    public Vector2 visualFieldMax_R = Vector2.one;

    public Vector2 visualFieldMin_L = -Vector2.one;
    public Vector2 visualFieldMax_L = Vector2.one;
}
