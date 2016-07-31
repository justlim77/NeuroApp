using UnityEngine;
using UnityEditor;
using NeuroApp;

[System.Serializable]
public class CaseEditor : EditorWindow {

    #region Static Variables
    public static Case CaseData;
    #endregion

    #region Private Variables
    private Vector2 _scrollPos;
    #endregion

    //[MenuItem("Window/Edit Case")]

    public static void Init(Case _case) {
        CaseData = _case;
        CaseEditor window = (CaseEditor)GetWindow(typeof(CaseEditor));
        window.Show();
        window.minSize = new Vector2(600, 470);
    }

    private void OnGUI() {
        EditorGUILayout.LabelField("(Case Properties for " + CaseData.caseName + ")", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        //Begin scroll view
        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, false, true, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.Height(400));

        //Condition Name
        EditorGUILayout.LabelField("Case Name", EditorStyles.boldLabel);
        CaseData.caseName = EditorGUILayout.TextArea(CaseData.caseName);
        EditorGUILayout.Space();

        //Condition Description
        EditorGUILayout.LabelField("Case Description", EditorStyles.boldLabel);
        CaseData.caseDescription = EditorGUILayout.TextArea(CaseData.caseDescription);
        EditorGUILayout.Space();

        // Default face
        EditorGUILayout.LabelField("Default Face", EditorStyles.boldLabel);
        CaseData.face.rightEyeDroop = EditorGUILayout.ToggleLeft("Right Eye Droop", CaseData.face.rightEyeDroop);
        CaseData.face.leftEyeDroop = EditorGUILayout.ToggleLeft("Left Eye Droop", CaseData.face.leftEyeDroop);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Right Pupil State", GUILayout.MaxWidth(100));
        CaseData.face.rightPupilState = (PupilState)EditorGUILayout.EnumPopup(CaseData.face.rightPupilState);
        EditorGUILayout.LabelField("Left Pupil State", GUILayout.MaxWidth(100));
        CaseData.face.leftPupilState = (PupilState)EditorGUILayout.EnumPopup(CaseData.face.leftPupilState);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //Tone
        EditorGUILayout.LabelField("Tone", EditorStyles.boldLabel);
        CaseData.tone = EditorGUILayout.TextArea(CaseData.tone);
        EditorGUILayout.Space();

        //Plantars
        EditorGUILayout.LabelField("Plantars", EditorStyles.boldLabel);
        CaseData.plantars = EditorGUILayout.TextArea(CaseData.plantars);
        EditorGUILayout.Space();

        //Cerebellar Explanation
        EditorGUILayout.LabelField("Cerebellar Examination", EditorStyles.boldLabel);
        CaseData.cerebellar = EditorGUILayout.TextArea(CaseData.cerebellar);
        EditorGUILayout.Space();

        //Comments
        EditorGUILayout.LabelField("Other important tests", EditorStyles.boldLabel);
        CaseData.otherTests = EditorGUILayout.TextArea(CaseData.otherTests);
        EditorGUILayout.Space();

        //DTR
        EditorGUILayout.LabelField("Deep Tendon Reflexes", EditorStyles.boldLabel);

        //Upper limb group
        EditorGUILayout.LabelField("(Upper Limb)", EditorStyles.miniBoldLabel);
        //Upper limb - Right
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Right Tricep", GUILayout.MaxWidth(100));
        CaseData.tendon_tricep_R.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_tricep_R.tendonReflex);
        EditorGUILayout.LabelField("Right Bicep", GUILayout.MaxWidth(100));
        CaseData.tendon_bicep_R.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_bicep_R.tendonReflex);
        EditorGUILayout.LabelField("Right Supinator", GUILayout.MaxWidth(100));
        CaseData.tendon_supinator_R.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_supinator_R.tendonReflex);
        EditorGUILayout.EndHorizontal();

        //Upper limb - Left
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Left Tricep", GUILayout.MaxWidth(100));
        CaseData.tendon_tricep_L.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_tricep_L.tendonReflex);
        EditorGUILayout.LabelField("Left Bicep", GUILayout.MaxWidth(100));
        CaseData.tendon_bicep_L.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_bicep_L.tendonReflex);
        EditorGUILayout.LabelField("Left Supinator", GUILayout.MaxWidth(100));
        CaseData.tendon_supinator_L.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_supinator_L.tendonReflex);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //Lower limb group
        EditorGUILayout.LabelField("(Lower Limb)", EditorStyles.miniBoldLabel);
        //Lower limb - Right
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Right Patellar", GUILayout.MaxWidth(100));
        CaseData.tendon_patellar_R.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_patellar_R.tendonReflex);
        EditorGUILayout.LabelField("Right Ankle", GUILayout.MaxWidth(100));
        CaseData.tendon_ankle_R.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_ankle_R.tendonReflex);
        EditorGUILayout.EndHorizontal();

        //Lower limb - Left
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Left Patellar", GUILayout.MaxWidth(100));
        CaseData.tendon_patellar_L.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_patellar_L.tendonReflex);
        EditorGUILayout.LabelField("Left Ankle", GUILayout.MaxWidth(100));
        CaseData.tendon_ankle_L.tendonReflex = (TendonData.TendonReflex)EditorGUILayout.EnumPopup(CaseData.tendon_ankle_L.tendonReflex);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Dermatomes
        EditorGUILayout.LabelField("Dermatomes", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("(Check if can feel)", EditorStyles.miniBoldLabel);
        //Upper extremity
        EditorGUILayout.LabelField("Upper extremity", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_T1_R = EditorGUILayout.ToggleLeft("T1 Right", CaseData.UL_T1_R, GUILayout.MaxWidth(120));
        CaseData.UL_T1_L = EditorGUILayout.ToggleLeft("T1 Left", CaseData.UL_T1_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_C5_R = EditorGUILayout.ToggleLeft("C5 Right", CaseData.UL_C5_R, GUILayout.MaxWidth(120));
        CaseData.UL_C5_L = EditorGUILayout.ToggleLeft("C5 Left", CaseData.UL_C5_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_C6_R_1 = EditorGUILayout.ToggleLeft("C6 Right 1", CaseData.UL_C6_R_1, GUILayout.MaxWidth(120));
        CaseData.UL_C6_L_1 = EditorGUILayout.ToggleLeft("C6 Left 1", CaseData.UL_C6_L_1, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_C6_R_2 = EditorGUILayout.ToggleLeft("C6 Right 2", CaseData.UL_C6_R_2, GUILayout.MaxWidth(120));
        CaseData.UL_C6_L_2 = EditorGUILayout.ToggleLeft("C6 Left 2", CaseData.UL_C6_L_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_C7_R = EditorGUILayout.ToggleLeft("C7 Right", CaseData.UL_C7_R, GUILayout.MaxWidth(120));
        CaseData.UL_C7_L = EditorGUILayout.ToggleLeft("C7 Left", CaseData.UL_C7_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_C8_R_1 = EditorGUILayout.ToggleLeft("C8 Right 1", CaseData.UL_C8_R_1, GUILayout.MaxWidth(120));
        CaseData.UL_C8_L_1 = EditorGUILayout.ToggleLeft("C8 Left 1", CaseData.UL_C8_L_1, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_C8_R_2 = EditorGUILayout.ToggleLeft("C8 Right 2", CaseData.UL_C8_R_2, GUILayout.MaxWidth(120));
        CaseData.UL_C8_L_2 = EditorGUILayout.ToggleLeft("C8 Left 2", CaseData.UL_C8_L_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();

        //Lower extremity
        EditorGUILayout.LabelField("Lower extremity", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        CaseData.LL_L2_R = EditorGUILayout.ToggleLeft("L2 Right", CaseData.LL_L2_R, GUILayout.MaxWidth(120));
        CaseData.LL_L2_L = EditorGUILayout.ToggleLeft("L2 Left", CaseData.LL_L2_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.LL_L3_R = EditorGUILayout.ToggleLeft("L3 Right", CaseData.LL_L3_R, GUILayout.MaxWidth(120));
        CaseData.LL_L3_L = EditorGUILayout.ToggleLeft("L3 Left", CaseData.LL_L3_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.LL_L4_R_1 = EditorGUILayout.ToggleLeft("L4 Right 1", CaseData.LL_L4_R_1, GUILayout.MaxWidth(120));
        CaseData.LL_L4_L_1 = EditorGUILayout.ToggleLeft("L4 Left 1", CaseData.LL_L4_L_1, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.LL_L4_R_2 = EditorGUILayout.ToggleLeft("L4 Right 2", CaseData.LL_L4_R_2, GUILayout.MaxWidth(120));
        CaseData.LL_L4_L_2 = EditorGUILayout.ToggleLeft("L4 Left 2", CaseData.LL_L4_L_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.LL_L5_R_1 = EditorGUILayout.ToggleLeft("L5 Right 1", CaseData.LL_L5_R_1, GUILayout.MaxWidth(120));
        CaseData.LL_L5_L_1 = EditorGUILayout.ToggleLeft("L5 Left 1", CaseData.LL_L5_L_1, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.LL_L5_R_2 = EditorGUILayout.ToggleLeft("L5 Right 2", CaseData.LL_L5_R_2, GUILayout.MaxWidth(120));
        CaseData.LL_L5_L_2 = EditorGUILayout.ToggleLeft("L5 Left 2", CaseData.LL_L5_L_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.LL_S1_R = EditorGUILayout.ToggleLeft("S1 Right", CaseData.LL_S1_R, GUILayout.MaxWidth(120));
        CaseData.LL_S1_L = EditorGUILayout.ToggleLeft("S1 Left", CaseData.LL_S1_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();

        // Other
        EditorGUILayout.LabelField("Other", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        CaseData.UL_T4 = EditorGUILayout.ToggleLeft("T4", CaseData.UL_T4, GUILayout.MaxWidth(120));
        CaseData.UL_T5_T9 = EditorGUILayout.ToggleLeft("T5/T9", CaseData.UL_T5_T9, GUILayout.MaxWidth(120));
        CaseData.UL_T10 = EditorGUILayout.ToggleLeft("T10", CaseData.UL_T10, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Power
        EditorGUILayout.LabelField("Power", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("R", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("L", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();

        //Upper limbs
        //Shoulder
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Shoulder   /   Abduction", EditorStyles.boldLabel);
        CaseData.UL_Shoulder_AB_R = EditorGUILayout.TextField(CaseData.UL_Shoulder_AB_R);
        CaseData.UL_Shoulder_AB_L = EditorGUILayout.TextField(CaseData.UL_Shoulder_AB_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Shoulder   /   Adduction", EditorStyles.boldLabel);
        CaseData.UL_Shoulder_AD_R = EditorGUILayout.TextField(CaseData.UL_Shoulder_AD_R);
        CaseData.UL_Shoulder_AD_L = EditorGUILayout.TextField(CaseData.UL_Shoulder_AD_L);
        EditorGUILayout.EndHorizontal();

        //Elbow
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Elbow   /   Flexion", EditorStyles.boldLabel);
        CaseData.UL_Elbow_F_R = EditorGUILayout.TextField(CaseData.UL_Elbow_F_R);
        CaseData.UL_Elbow_F_L = EditorGUILayout.TextField(CaseData.UL_Elbow_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Elbow   /   Extension", EditorStyles.boldLabel);
        CaseData.UL_Elbow_E_R = EditorGUILayout.TextField(CaseData.UL_Elbow_E_R);
        CaseData.UL_Elbow_E_L = EditorGUILayout.TextField(CaseData.UL_Elbow_E_L);
        EditorGUILayout.EndHorizontal();

        //Wrist
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Wrist   /   Flexion", EditorStyles.boldLabel);
        CaseData.UL_Wrist_F_R = EditorGUILayout.TextField(CaseData.UL_Wrist_F_R);
        CaseData.UL_Wrist_F_L = EditorGUILayout.TextField(CaseData.UL_Wrist_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Wrist   /   Extension", EditorStyles.boldLabel);
        CaseData.UL_Wrist_E_R = EditorGUILayout.TextField(CaseData.UL_Wrist_E_R);
        CaseData.UL_Wrist_E_L = EditorGUILayout.TextField(CaseData.UL_Wrist_E_L);
        EditorGUILayout.EndHorizontal();

        //Finger
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Finger   /   Flexion", EditorStyles.boldLabel);
        CaseData.UL_Finger_F_R = EditorGUILayout.TextField(CaseData.UL_Finger_F_R);
        CaseData.UL_Finger_F_L = EditorGUILayout.TextField(CaseData.UL_Finger_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Finger   /   Extension", EditorStyles.boldLabel);
        CaseData.UL_Finger_E_R = EditorGUILayout.TextField(CaseData.UL_Finger_E_R);
        CaseData.UL_Finger_E_L = EditorGUILayout.TextField(CaseData.UL_Finger_E_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Finger   /   Abduction", EditorStyles.boldLabel);
        CaseData.UL_Finger_AB_R = EditorGUILayout.TextField(CaseData.UL_Finger_AB_R);
        CaseData.UL_Finger_AB_L = EditorGUILayout.TextField(CaseData.UL_Finger_AB_L);
        EditorGUILayout.EndHorizontal();

        //Thumb
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Thumb   /   Flexion", EditorStyles.boldLabel);
        CaseData.UL_Thumb_F_R = EditorGUILayout.TextField(CaseData.UL_Thumb_F_R);
        CaseData.UL_Thumb_F_L = EditorGUILayout.TextField(CaseData.UL_Thumb_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Thumb   /   Extension", EditorStyles.boldLabel);
        CaseData.UL_Thumb_E_R = EditorGUILayout.TextField(CaseData.UL_Thumb_E_R);
        CaseData.UL_Thumb_E_L = EditorGUILayout.TextField(CaseData.UL_Thumb_E_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Thumb   /   Abduction", EditorStyles.boldLabel);
        CaseData.UL_Thumb_AB_R = EditorGUILayout.TextField(CaseData.UL_Thumb_AB_R);
        CaseData.UL_Thumb_AB_L = EditorGUILayout.TextField(CaseData.UL_Thumb_AB_L);
        EditorGUILayout.EndHorizontal();

        //Lower limbs
        //Hip
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Hip     /   Flexion", EditorStyles.boldLabel);
        CaseData.LL_Hip_F_R = EditorGUILayout.TextField(CaseData.LL_Hip_F_R);
        CaseData.LL_Hip_F_L = EditorGUILayout.TextField(CaseData.LL_Hip_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Hip     /   Extension", EditorStyles.boldLabel);
        CaseData.LL_Hip_E_R = EditorGUILayout.TextField(CaseData.LL_Hip_E_R);
        CaseData.LL_Hip_E_L = EditorGUILayout.TextField(CaseData.LL_Hip_E_L);
        EditorGUILayout.EndHorizontal();

        //Knee
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Knee    /   Flexion", EditorStyles.boldLabel);
        CaseData.LL_Knee_F_R = EditorGUILayout.TextField(CaseData.LL_Knee_F_R);
        CaseData.LL_Knee_F_L = EditorGUILayout.TextField(CaseData.LL_Knee_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Knee    /   Extension", EditorStyles.boldLabel);
        CaseData.LL_Knee_E_R = EditorGUILayout.TextField(CaseData.LL_Knee_E_R);
        CaseData.LL_Knee_E_L = EditorGUILayout.TextField(CaseData.LL_Knee_E_L);
        EditorGUILayout.EndHorizontal();

        //Ankle
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Ankle    /   Dorsiflexion", EditorStyles.boldLabel);
        CaseData.LL_Ankle_DF_R = EditorGUILayout.TextField(CaseData.LL_Ankle_DF_R);
        CaseData.LL_Ankle_DF_L = EditorGUILayout.TextField(CaseData.LL_Ankle_DF_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Ankle    /   Plantarflexion", EditorStyles.boldLabel);
        CaseData.LL_Ankle_PF_R = EditorGUILayout.TextField(CaseData.LL_Ankle_PF_R);
        CaseData.LL_Ankle_PF_L = EditorGUILayout.TextField(CaseData.LL_Ankle_PF_L);
        EditorGUILayout.EndHorizontal();

        //Toe
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Toe    /   Dorsiflexion", EditorStyles.boldLabel);
        CaseData.LL_Toe_DF_R = EditorGUILayout.TextField(CaseData.LL_Toe_DF_R);
        CaseData.LL_Toe_DF_L = EditorGUILayout.TextField(CaseData.LL_Toe_DF_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Toe    /   Plantarflexion", EditorStyles.boldLabel);
        CaseData.LL_Toe_PF_R = EditorGUILayout.TextField(CaseData.LL_Toe_PF_R);
        CaseData.LL_Toe_PF_L = EditorGUILayout.TextField(CaseData.LL_Toe_PF_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        // Cranial
        EditorGUILayout.LabelField("Cranial", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        EditorGUILayout.LabelField("R", EditorStyles.boldLabel, GUILayout.MaxWidth(60));
        EditorGUILayout.LabelField("L", EditorStyles.boldLabel, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();

        // Sensation
        EditorGUILayout.LabelField("(Sensation)", EditorStyles.miniBoldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Upper Face", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.face_upper_R = EditorGUILayout.Toggle(CaseData.face_upper_R, GUILayout.MaxWidth(60));
        CaseData.face_upper_L = EditorGUILayout.Toggle(CaseData.face_upper_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Mid Face", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.face_mid_R = EditorGUILayout.Toggle(CaseData.face_mid_R, GUILayout.MaxWidth(60));
        CaseData.face_mid_L = EditorGUILayout.Toggle(CaseData.face_mid_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Lower Face", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.face_lower_R = EditorGUILayout.Toggle(CaseData.face_lower_R, GUILayout.MaxWidth(60));
        CaseData.face_lower_L = EditorGUILayout.Toggle(CaseData.face_lower_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();

        // Torch
        EditorGUILayout.LabelField("(Torch)", EditorStyles.miniBoldLabel);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Pupils", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.state_Pupil_R = (State)EditorGUILayout.EnumPopup(CaseData.state_Pupil_R, GUILayout.MaxWidth(60));
        CaseData.state_Pupil_L = (State)EditorGUILayout.EnumPopup(CaseData.state_Pupil_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Tongue", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.state_Tongue_R = (State)EditorGUILayout.EnumPopup(CaseData.state_Tongue_R, GUILayout.MaxWidth(60));
        CaseData.state_Tongue_L = (State)EditorGUILayout.EnumPopup(CaseData.state_Tongue_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Palate", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.state_Palate_R = (State)EditorGUILayout.EnumPopup(CaseData.state_Palate_R, GUILayout.MaxWidth(60));
        CaseData.state_Palate_L = (State)EditorGUILayout.EnumPopup(CaseData.state_Palate_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();

        // Power
        EditorGUILayout.LabelField("(Power)", EditorStyles.miniBoldLabel);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Eyebrows", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.state_Brow_R = (State)EditorGUILayout.EnumPopup(CaseData.state_Brow_R, GUILayout.MaxWidth(60));
        CaseData.state_Brow_L = (State)EditorGUILayout.EnumPopup(CaseData.state_Brow_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Eyes", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.state_Eye_R = (State)EditorGUILayout.EnumPopup(CaseData.state_Eye_R, GUILayout.MaxWidth(60));
        CaseData.state_Eye_L = (State)EditorGUILayout.EnumPopup(CaseData.state_Eye_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Mouth", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.state_Mouth_R = (State)EditorGUILayout.EnumPopup(CaseData.state_Mouth_R, GUILayout.MaxWidth(60));
        CaseData.state_Mouth_L = (State)EditorGUILayout.EnumPopup(CaseData.state_Mouth_L, GUILayout.MaxWidth(60));
        EditorGUILayout.EndHorizontal();

        // Others
        EditorGUILayout.LabelField("(Others)", EditorStyles.miniBoldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Hearing", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.hearing = EditorGUILayout.TextField(CaseData.hearing);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Corneal Reflex", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.cornealReflex = EditorGUILayout.TextField(CaseData.cornealReflex);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Visual Fields", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.visualFields = EditorGUILayout.TextField(CaseData.visualFields);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Gag Reflex", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.gagReflex = EditorGUILayout.TextField(CaseData.gagReflex);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Speech", EditorStyles.boldLabel, GUILayout.MaxWidth(120));
        CaseData.speech = EditorGUILayout.TextArea(CaseData.speech, GUILayout.MaxWidth(400), GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(false));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        // Elimination
        EditorGUILayout.LabelField("Eliminate from Neuraxis (Leave blank to eliminate)", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        CaseData.neuraxis_C = EditorGUILayout.ToggleLeft("C", CaseData.neuraxis_C, GUILayout.MaxWidth(120));
        CaseData.neuraxis_SC = EditorGUILayout.ToggleLeft("SC", CaseData.neuraxis_SC, GUILayout.MaxWidth(120));
        CaseData.neuraxis_BS = EditorGUILayout.ToggleLeft("BS", CaseData.neuraxis_BS, GUILayout.MaxWidth(120));
        CaseData.neuraxis_SCORD = EditorGUILayout.ToggleLeft("SCORD", CaseData.neuraxis_SCORD, GUILayout.MaxWidth(120));
        CaseData.neuraxis_AHC = EditorGUILayout.ToggleLeft("AHC", CaseData.neuraxis_AHC, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        CaseData.neuraxis_R = EditorGUILayout.ToggleLeft("R", CaseData.neuraxis_R, GUILayout.MaxWidth(120));
        CaseData.neuraxis_P = EditorGUILayout.ToggleLeft("P", CaseData.neuraxis_P, GUILayout.MaxWidth(120));
        CaseData.neuraxis_PN = EditorGUILayout.ToggleLeft("PN", CaseData.neuraxis_PN, GUILayout.MaxWidth(120));
        CaseData.neuraxis_NMJ = EditorGUILayout.ToggleLeft("NMJ", CaseData.neuraxis_NMJ, GUILayout.MaxWidth(120));
        CaseData.neuraxis_M = EditorGUILayout.ToggleLeft("M", CaseData.neuraxis_M, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        // Localising steps
        EditorGUILayout.LabelField("Localising steps (Leave blank if necessary)", EditorStyles.boldLabel);
        CaseData.localisingSteps[0] = EditorGUILayout.TextField("Enter localising step #1", CaseData.localisingSteps[0]);
        CaseData.localisingSteps[1] = EditorGUILayout.TextField("Enter localising step #2", CaseData.localisingSteps[1]);
        CaseData.localisingSteps[2] = EditorGUILayout.TextField("Enter localising step #3", CaseData.localisingSteps[2]);
        CaseData.localisingSteps[3] = EditorGUILayout.TextField("Enter localising step #4", CaseData.localisingSteps[3]);
        EditorGUILayout.Space();

        // Explanation
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Explanation: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        CaseData.localisingExplanation = EditorGUILayout.TextArea(CaseData.localisingExplanation, GUILayout.MaxWidth(600), GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(false));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        // Test type (Single/Multiple)
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Test Type", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        CaseData.testType = (TestType)EditorGUILayout.EnumPopup(CaseData.testType, GUILayout.MaxWidth(100));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        // Test question
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Test Question: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        CaseData.testQuestion = EditorGUILayout.TextArea(CaseData.testQuestion, GUILayout.MaxWidth(600), GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(false));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        // Concluding Test
        EditorGUILayout.LabelField("Concluding Test (Leave blank if necessary)", EditorStyles.boldLabel);
        CaseData.concludingTests[0] = EditorGUILayout.TextField("Enter option for A)", CaseData.concludingTests[0]);
        CaseData.concludingTests[1] = EditorGUILayout.TextField("Enter option for B)", CaseData.concludingTests[1]);
        CaseData.concludingTests[2] = EditorGUILayout.TextField("Enter option for C)", CaseData.concludingTests[2]);
        CaseData.concludingTests[3] = EditorGUILayout.TextField("Enter option for D)", CaseData.concludingTests[3]);
        CaseData.concludingTests[4] = EditorGUILayout.TextField("Enter option for E)", CaseData.concludingTests[4]);
        EditorGUILayout.Space();

        // Answer to Concluding Test
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Correct Answer: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        CaseData.answer = (Answer) EditorGUILayout.EnumPopup(CaseData.answer, GUILayout.MaxWidth(50));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        // Answer Explanation
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Explanation: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        CaseData.answerExplanation = EditorGUILayout.TextArea(CaseData.answerExplanation, GUILayout.MaxWidth(600), GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(false));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUILayout.EndScrollView();

        //END//
        EditorGUILayout.Space();

        // Close
        if (GUILayout.Button("Save & Close"))
            Close();
    }
}
