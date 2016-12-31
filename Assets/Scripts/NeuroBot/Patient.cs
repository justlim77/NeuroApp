using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using NeuroApp;

public class Patient : MonoBehaviour
{
    static Case _CaseData = null;
    public static Case CaseData
    {
        get { return _CaseData; }
        set { _CaseData = value; }
    }

    public Text caseDescriptionText;            // Case description heading

    public Face face;                           // Default face
    public HeadReaction head;
    public Image eyelid_R;
    public Image eyelid_L;

    #region Clinical Exam Variables // DEPRECATED in 0.3.0
    //public Text toneText;                       // Tone
    //public Text plantarsText;                   // Plantars
    //public Text cerebellarExamText;             // Cerebellar Exam
    //public Text otherTestsText;                 // Other important tests
    #endregion

    #region Power Variables
    // Power
    // Upper limb
    public Text UL_Shoulder_AB_R;
    public Text UL_Shoulder_AB_L;
    public Text UL_Shoulder_AD_R;
    public Text UL_Shoulder_AD_L;
    public Text UL_Elbow_F_R;
    public Text UL_Elbow_F_L;
    public Text UL_Elbow_E_R;
    public Text UL_Elbow_E_L;
    public Text UL_Wrist_F_R;
    public Text UL_Wrist_F_L;
    public Text UL_Wrist_E_R;
    public Text UL_Wrist_E_L;
    public Text UL_Finger_F_R;
    public Text UL_Finger_F_L;
    public Text UL_Finger_E_R;
    public Text UL_Finger_E_L;
    public Text UL_Finger_AB_R;
    public Text UL_Finger_AB_L;
    public Text UL_Thumb_F_R;
    public Text UL_Thumb_F_L;
    public Text UL_Thumb_E_R;
    public Text UL_Thumb_E_L;
    public Text UL_Thumb_AB_R;
    public Text UL_Thumb_AB_L;
    // Lower limb
    public Text LL_Hip_F_R;
    public Text LL_Hip_F_L;
    public Text LL_Hip_E_R;
    public Text LL_Hip_E_L;
    public Text LL_Knee_F_R;
    public Text LL_Knee_F_L;
    public Text LL_Knee_E_R;
    public Text LL_Knee_E_L;
    public Text LL_Ankle_DF_R;
    public Text LL_Ankle_DF_L;
    public Text LL_Ankle_PF_R;
    public Text LL_Ankle_PF_L;
    public Text LL_Toe_DF_R;
    public Text LL_Toe_DF_L;
    public Text LL_Toe_PF_R;
    public Text LL_Toe_PF_L;
    #endregion

    #region Dermatomes Variables
    /*  
     *  True - Normal
     *  False - Decreased
     *  Format - LIMB_REGION_SIDE_SECTION
     */
    // Upper extremity
    public Dermatome UL_T1_R, UL_T1_L;      // Inner upper arm
    public Dermatome UL_C5_R, UL_C5_L;      // Outer upper arm
    public Dermatome UL_C6_R_1, UL_C6_L_1;  // Outer forearm
    public Dermatome UL_C6_R_2, UL_C6_L_2;  // Thumb
    public Dermatome UL_C7_R, UL_C7_L;      // Middle finger
    public Dermatome UL_C8_R_1, UL_C8_R_2;  // Little finger
    public Dermatome UL_C8_L_1, UL_C8_L_2;  // Little finger | Inner forearm
    // Lower extremity
    public Dermatome LL_L2_R, LL_L2_L;      // Thigh
    public Dermatome LL_L3_R, LL_L3_L;      // Knee
    public Dermatome LL_L4_R_1, LL_L4_L_1;  // Medial malleolus
    public Dermatome LL_L4_R_2, LL_L4_L_2;  // Heel
    public Dermatome LL_L5_R_1, LL_L5_L_1;  // Dorsum of foot
    public Dermatome LL_L5_R_2, LL_L5_L_2;  // Toes 1-3
    public Dermatome LL_S1_R, LL_S1_L;      // Toes 4 and 5; lateral malleolus
    // Other
    public Dermatome UL_T4;                 // Nipple
    public Dermatome UL_T5_T9;              // Nipple to Umbilicus
    public Dermatome UL_T10;                // Umbilicus
    #endregion

    #region Deep Tendon Reflex Variables
    // Deep Tendon Reflexes
    public Tendon tendon_tricep_R;
    public Tendon tendon_bicep_R;
    public Tendon tendon_supinator_R;
    public Tendon tendon_tricep_L;
    public Tendon tendon_bicep_L;
    public Tendon tendon_supinator_L;
    public Tendon tendon_patellar_R;
    public Tendon tendon_ankle_R;
    public Tendon tendon_patellar_L;
    public Tendon tendon_ankle_L;
    #endregion

    #region Cranial
    // Sensation
    public Dermatome face_upper_R, face_upper_L;
    public Dermatome face_mid_R, face_mid_L;
    public Dermatome face_lower_R, face_lower_L;

    public TorchObject palate;

    public Pupil pupil_R;
    public Pupil pupil_L;

    // Power
    public Power face_power_upper;
    public Power face_power_mid;
    public Power face_power_lower;

    // Clinical exam
    public Text hearingText;
    public Text cornealReflexText;
    public Text visualFieldsText;
    public Text gagReflexText;
    //public Text speechText;
    public GameObject speechButton;
    #endregion

    #region Elimination Variables
    // Neuroaxis Elimination
    public bool neuraxis_C;
    public bool neuraxis_SC;
    public bool neuraxis_BS;
    public bool neuraxis_SCORD;
    public bool neuraxis_AHC;
    public bool neuraxis_R;
    public bool neuraxis_P;
    public bool neuraxis_PN;
    public bool neuraxis_NMJ;
    public bool neuraxis_M;

    public string[] localisingSteps;    // Localising steps string array
    public Text localisingText;         // Localising Steps text component
    public Text localisingExplainText;  // Localising explanation text component
    public Sprite localisingDiagram;    // Localising diagram image sprite
    public Text testQuestionText;       // Concluding test question text component
    public string[] concludingTests;    // Concluding tests string array
    public Answer answer;               // Correct test answer enum
    public Text answerText;             // Explanation for test answer text component
    #endregion

    // Case database (DB) reference
    [SerializeField] CaseDatabase _caseDatabase;

    int _numOfCases;    // Cache number of cases

    void Awake()
    {
        _numOfCases = _caseDatabase.caseList.caseList.Count;
    }

    void OnDestroy()
    {
        _CaseData = null;
    }
    private bool Init()
    {
        // General
        caseDescriptionText.text = CaseData.caseDescription;                                                // Case description setup

        #region DEPRECATED IN 0.3.0
        //toneText.text = string.Format("<b>Tone</b>\n{0}", CaseData.tone);                                   // Tone setup
        //plantarsText.text = string.Format("<b>Plantars</b>\n{0}", CaseData.plantars);                       // Plantars setup
        //cerebellarExamText.text = string.Format("<b>Cerebellar examination</b>\n{0}", CaseData.cerebellar); // Cerebellar exam setup
        //otherTestsText.text = string.Format("<b>Other important tests</b>\n{0}", CaseData.otherTests);      // Other important tests
        #endregion

        // Face
        face = CaseData.Face;

        // Upper limbs
        // Shoulder
        UL_Shoulder_AB_R.text = CaseData.UL_Shoulder_AB_R;
        UL_Shoulder_AB_L.text = CaseData.UL_Shoulder_AB_L;
        UL_Shoulder_AD_R.text = CaseData.UL_Shoulder_AD_R;
        UL_Shoulder_AD_L.text = CaseData.UL_Shoulder_AD_L;
        // Elbow
        UL_Elbow_F_R.text = CaseData.UL_Elbow_F_R;
        UL_Elbow_F_L.text = CaseData.UL_Elbow_F_L;
        UL_Elbow_E_R.text = CaseData.UL_Elbow_E_R;
        UL_Elbow_E_L.text = CaseData.UL_Elbow_E_L;
        // Wrist
        UL_Wrist_F_R.text = CaseData.UL_Wrist_F_R;
        UL_Wrist_F_L.text = CaseData.UL_Wrist_F_L;
        UL_Wrist_E_R.text = CaseData.UL_Wrist_E_R;
        UL_Wrist_E_L.text = CaseData.UL_Wrist_E_L;
        // Finger
        UL_Finger_F_R.text = CaseData.UL_Finger_F_R;
        UL_Finger_F_L.text = CaseData.UL_Finger_F_L;
        UL_Finger_E_R.text = CaseData.UL_Finger_E_R;
        UL_Finger_E_L.text = CaseData.UL_Finger_E_L;
        UL_Finger_AB_R.text = CaseData.UL_Finger_AB_R;
        UL_Finger_AB_L.text = CaseData.UL_Finger_AB_L;
        // Thumb
        UL_Thumb_F_R.text = CaseData.UL_Thumb_F_R;
        UL_Thumb_F_L.text = CaseData.UL_Thumb_F_L;
        UL_Thumb_E_R.text = CaseData.UL_Thumb_E_R;
        UL_Thumb_E_L.text = CaseData.UL_Thumb_E_L;
        UL_Thumb_AB_R.text = CaseData.UL_Thumb_AB_R;
        UL_Thumb_AB_L.text = CaseData.UL_Thumb_AB_L;
        // Lower limbs
        // Hip
        LL_Hip_F_R.text = CaseData.LL_Hip_F_R;
        LL_Hip_F_L.text = CaseData.LL_Hip_F_L;
        LL_Hip_E_R.text = CaseData.LL_Hip_E_R;
        LL_Hip_E_L.text = CaseData.LL_Hip_E_L;
        // Knee
        LL_Knee_F_R.text = CaseData.LL_Knee_F_R;
        LL_Knee_F_L.text = CaseData.LL_Knee_F_L;
        LL_Knee_E_R.text = CaseData.LL_Knee_E_R;
        LL_Knee_E_L.text = CaseData.LL_Knee_E_L;
        // Ankle
        LL_Ankle_DF_R.text = CaseData.LL_Ankle_DF_R;
        LL_Ankle_DF_L.text = CaseData.LL_Ankle_DF_L;
        LL_Ankle_PF_R.text = CaseData.LL_Ankle_PF_R;
        LL_Ankle_PF_L.text = CaseData.LL_Ankle_PF_L;
        // Toe
        LL_Toe_DF_R.text = CaseData.LL_Toe_DF_R;
        LL_Toe_DF_L.text = CaseData.LL_Toe_DF_L;
        LL_Toe_PF_R.text = CaseData.LL_Toe_PF_R;
        LL_Toe_PF_L.text = CaseData.LL_Toe_PF_L;

        // DTR setup
        // Upper limbs
        tendon_tricep_R.tendon = CaseData.tendon_tricep_R;
        tendon_bicep_R.tendon = CaseData.tendon_bicep_R;
        tendon_supinator_R.tendon = CaseData.tendon_supinator_R;
        tendon_tricep_L.tendon = CaseData.tendon_tricep_L;
        tendon_bicep_L.tendon = CaseData.tendon_bicep_L;
        tendon_supinator_L.tendon = CaseData.tendon_supinator_L;
        // Lower limbs
        tendon_patellar_R.tendon = CaseData.tendon_patellar_R;
        tendon_ankle_R.tendon = CaseData.tendon_ankle_R;
        tendon_patellar_L.tendon = CaseData.tendon_patellar_L;
        tendon_ankle_L.tendon = CaseData.tendon_ankle_L;

        // Sensation setup
        // Upper limbs
        UL_T4.canFeel = CaseData.UL_T4;
        UL_T5_T9.canFeel = CaseData.UL_T5_T9;
        UL_T10.canFeel = CaseData.UL_T10;
        UL_T1_R.canFeel = CaseData.UL_T1_R;
        UL_T1_L.canFeel = CaseData.UL_T1_L;
        UL_C5_R.canFeel = CaseData.UL_C5_R;
        UL_C5_L.canFeel = CaseData.UL_C5_L;
        UL_C6_R_1.canFeel = CaseData.UL_C6_R_1;
        UL_C6_L_1.canFeel = CaseData.UL_C6_L_1;
        UL_C6_R_2.canFeel = CaseData.UL_C6_R_2;
        UL_C6_L_2.canFeel = CaseData.UL_C6_L_2;
        UL_C7_R.canFeel = CaseData.UL_C7_R;
        UL_C7_L.canFeel = CaseData.UL_C7_L;
        UL_C8_R_1.canFeel = CaseData.UL_C8_R_1;
        UL_C8_L_1.canFeel = CaseData.UL_C8_L_1;
        UL_C8_R_2.canFeel = CaseData.UL_C8_R_2;
        UL_C8_L_2.canFeel = CaseData.UL_C8_L_2;
        // Lower limbs
        LL_L2_R.canFeel = CaseData.LL_L2_R;
        LL_L2_L.canFeel = CaseData.LL_L2_L;
        LL_L3_R.canFeel = CaseData.LL_L3_R;
        LL_L3_L.canFeel = CaseData.LL_L3_L;
        LL_L4_R_1.canFeel = CaseData.LL_L4_R_1;
        LL_L4_L_1.canFeel = CaseData.LL_L4_L_1;
        LL_L4_R_2.canFeel = CaseData.LL_L4_R_2;
        LL_L4_L_2.canFeel = CaseData.LL_L4_L_2;
        LL_L5_R_1.canFeel = CaseData.LL_L5_R_1;
        LL_L5_L_1.canFeel = CaseData.LL_L5_L_1;
        LL_L5_R_2.canFeel = CaseData.LL_L5_R_2;
        LL_L5_L_2.canFeel = CaseData.LL_L5_L_2;
        LL_S1_R.canFeel = CaseData.LL_S1_R;
        LL_S1_L.canFeel = CaseData.LL_S1_L;

        // Cranial
        // General

        // Face behaviors
        // Eyelid Drooping
        eyelid_R.enabled = eyelid_L.enabled = false;
        if (face.rightEyeDroop)
            eyelid_R.enabled = true;
        if (face.leftEyeDroop)
            eyelid_L.enabled = true;

        // Visual Fields Tracking
        head.testEyeManager.rightEye.trackingFieldMin = face.visualFieldMin_R;
        head.testEyeManager.rightEye.trackingFieldMax = face.visualFieldMax_R;
        head.testEyeManager.leftEye.trackingFieldMin = face.visualFieldMin_L;
        head.testEyeManager.leftEye.trackingFieldMax = face.visualFieldMax_L;

        // Sensation
        face_upper_R.canFeel = CaseData.face_upper_R;
        face_upper_L.canFeel = CaseData.face_upper_R;
        face_mid_R.canFeel = CaseData.face_mid_R;
        face_mid_L.canFeel = CaseData.face_mid_L;
        face_lower_R.canFeel = CaseData.face_lower_R;
        face_lower_L.canFeel = CaseData.face_lower_L;

        // Torch - Eyes
        if (pupil_L != null)
        {
            if (face.leftPupilState.Equals(PupilState.Default))
                pupil_L.Init(CaseData.state_Pupil_L);
            else if (face.leftPupilState.Equals(PupilState.Dilated))
                pupil_L.Init(CaseData.state_Pupil_L, PupilState.Dilated, 9, 9, 9, 9);
            else if (face.leftPupilState.Equals(PupilState.Constricted))
                pupil_L.Init(CaseData.state_Pupil_L, PupilState.Constricted, 4, 4, 4, 4);
        }
        if (pupil_R != null)
        {
            if (face.rightPupilState.Equals(PupilState.Default))
                pupil_R.Init(CaseData.state_Pupil_R);
            else if (face.rightPupilState.Equals(PupilState.Dilated))
                pupil_R.Init(CaseData.state_Pupil_R, PupilState.Dilated, 9, 9, 9, 9);
            else if (face.rightPupilState.Equals(PupilState.Constricted))
                pupil_R.Init(CaseData.state_Pupil_R, PupilState.Constricted, 4, 4, 4, 4);
        }

        // Palate & Tongue
        if (palate != null)
            palate.Init();

        // Power
        // Upper - Eyebrows raising
        if (CaseData.state_Brow_R == State.Normal && CaseData.state_Brow_L == State.Normal)
            face_power_upper.faceState = FaceState.BothEyebrowsUp;
        else if (CaseData.state_Brow_R == State.Abnormal)
            face_power_upper.faceState = FaceState.LeftEyebrowUp;
        else if (CaseData.state_Brow_L == State.Abnormal)
            face_power_upper.faceState = FaceState.RightEyebrowUp;
        // Mid - Eyes squinting
        if (CaseData.state_Eye_R == State.Normal && CaseData.state_Eye_L == State.Normal)
            face_power_mid.faceState = FaceState.BothSquint;
        else if (CaseData.state_Eye_R == State.Abnormal)
            face_power_mid.faceState = FaceState.LeftSquint;
        else if (CaseData.state_Eye_L == State.Abnormal)
            face_power_mid.faceState = FaceState.RightSquint;
        // Lower - Teeth gritting
        if (CaseData.state_Mouth_R == State.Normal && CaseData.state_Mouth_L == State.Normal)
            face_power_lower.faceState = FaceState.BothGritTeeth;
        else if (CaseData.state_Mouth_R == State.Abnormal)
            face_power_lower.faceState = FaceState.LeftGritTeeth;
        else if (CaseData.state_Mouth_L == State.Abnormal)
            face_power_lower.faceState = FaceState.RightGritTeeth;

        // Clinical exam
        hearingText.text = string.Format("<b>Hearing</b>\n{0}", CaseData.hearing);
        cornealReflexText.text = string.Format("<b>Corneal Reflex</b>\n{0}", CaseData.cornealReflex);
        visualFieldsText.text = string.Format("<b>Visual Fields</b>\n{0}", CaseData.visualFields);
        gagReflexText.text = string.Format("<b>Gag Reflex</b>\n{0}", CaseData.gagReflex);
        string speech = CaseData.speech.ToLower();
        if (string.IsNullOrEmpty(speech) || speech == "normal" || speech == "nil")
        {
            speechButton.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            //speechText.text = CaseData.speech;    // Deprecated in 0.3.0
            speechButton.GetComponent<CanvasGroup>().alpha = 1;
        }

        // Neuraxis Elimination Game setup
        neuraxis_C = CaseData.neuraxis_C;
        neuraxis_SC = CaseData.neuraxis_SC;
        neuraxis_BS = CaseData.neuraxis_BS;
        neuraxis_SCORD = CaseData.neuraxis_SCORD;
        neuraxis_AHC = CaseData.neuraxis_AHC;
        neuraxis_R = CaseData.neuraxis_R;
        neuraxis_P = CaseData.neuraxis_P;
        neuraxis_PN = CaseData.neuraxis_PN;
        neuraxis_NMJ = CaseData.neuraxis_NMJ;
        neuraxis_M = CaseData.neuraxis_M;

        // Build localising steps from array
        localisingSteps = CaseData.localisingSteps;
        string content = "";
        int index = 0;
        foreach (string step in localisingSteps)
        {
            if (step != "")
            {
                index++;
                content += string.Format("{0}. {1}\n\n", index, step);
            }
        }
        string subContent = CaseData.localisingExplanation;
        if (subContent != string.Empty)
            content += string.Format("\n<b>Explanation</b>\n{0}", CaseData.localisingExplanation);

        //localisingText.text = content;                                              // Localising setup
        localisingDiagram = Resources.Load<Sprite>(CaseData.localisingImagePath);   // Load image path of localising diagram image
        testQuestionText.text = CaseData.testQuestion;                              // Concluding Test Question setup
        concludingTests = CaseData.concludingTests;                                 // Concluding Test setup
        answer = CaseData.answer;                                                   // Answer setup
        answerText.text = CaseData.answerExplanation;                               // Answer explanation setup

        return true;
    }

    public static int CaseIdx = 0;
    public void LoadCase(int idx)
    {
        if (idx > _numOfCases)
        {
            idx = 0;
        }

        CaseData = _caseDatabase.caseList.caseList[idx];

        CaseIdx = idx;

        Init();
    }
}
