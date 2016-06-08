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
}
