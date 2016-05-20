using UnityEngine;
using UnityEditor;

[System.Serializable]
public class CaseEditor : EditorWindow {

    #region Static Variables
    public static Case g_Case;
    #endregion

    #region Private Variables
    private Vector2 scrollPos;
    #endregion

    //[MenuItem("Window/Edit Case")]

    public static void Init(Case _case) {
        g_Case = _case;
        CaseEditor window = (CaseEditor)GetWindow(typeof(CaseEditor));
        window.Show();
        window.minSize = new Vector2(600, 470);
    }

    private void OnGUI() {
        EditorGUILayout.LabelField("(Case Properties for " + g_Case.caseName + ")", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        //Begin scroll view
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.Height(400));

        //Condition Name
        EditorGUILayout.LabelField("Case Name", EditorStyles.boldLabel);
        g_Case.caseName = EditorGUILayout.TextArea(g_Case.caseName);
        EditorGUILayout.Space();

        //Condition Description
        EditorGUILayout.LabelField("Case Description", EditorStyles.boldLabel);
        g_Case.caseDescription = EditorGUILayout.TextArea(g_Case.caseDescription);
        EditorGUILayout.Space();

        //Tone
        EditorGUILayout.LabelField("Tone", EditorStyles.boldLabel);
        g_Case.tone = (Case.Tone)EditorGUILayout.EnumPopup(g_Case.tone);
        EditorGUILayout.Space();

        //Cranial Nerve
        EditorGUILayout.LabelField("Cranial Nerve", EditorStyles.boldLabel);
        g_Case.cranialNerve = EditorGUILayout.TextArea(g_Case.cranialNerve);
        EditorGUILayout.Space();

        //Cerebellar Signs
        EditorGUILayout.LabelField("Cerebellar Signs", EditorStyles.boldLabel);
        g_Case.cerebellarSigns = EditorGUILayout.TextArea(g_Case.cerebellarSigns);
        EditorGUILayout.Space();

        //DTR
        EditorGUILayout.LabelField("Deep Tendon Reflexes", EditorStyles.boldLabel);

        //Upper limb group
        EditorGUILayout.LabelField("(Upper Limb)", EditorStyles.miniBoldLabel);
        //Upper limb - Right
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Right Tricep", GUILayout.MaxWidth(100));
        g_Case.tendon_tricep_R.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_tricep_R.tendonReflex);
        EditorGUILayout.LabelField("Right Bicep", GUILayout.MaxWidth(100));
        g_Case.tendon_bicep_R.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_bicep_R.tendonReflex);
        EditorGUILayout.LabelField("Right Supinator", GUILayout.MaxWidth(100));
        g_Case.tendon_supinator_R.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_supinator_R.tendonReflex);
        EditorGUILayout.EndHorizontal();

        //Upper limb - Left
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Left Tricep", GUILayout.MaxWidth(100));
        g_Case.tendon_tricep_L.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_tricep_L.tendonReflex);
        EditorGUILayout.LabelField("Left Bicep", GUILayout.MaxWidth(100));
        g_Case.tendon_bicep_L.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_bicep_L.tendonReflex);
        EditorGUILayout.LabelField("Left Supinator", GUILayout.MaxWidth(100));
        g_Case.tendon_supinator_L.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_supinator_L.tendonReflex);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //Lower limb group
        EditorGUILayout.LabelField("(Lower Limb)", EditorStyles.miniBoldLabel);
        //Lower limb - Right
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Right Patellar", GUILayout.MaxWidth(100));
        g_Case.tendon_patellar_R.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_patellar_R.tendonReflex);
        EditorGUILayout.LabelField("Right Ankle", GUILayout.MaxWidth(100));
        g_Case.tendon_ankle_R.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_ankle_R.tendonReflex);
        EditorGUILayout.LabelField("Right Plantar", GUILayout.MaxWidth(100));
        g_Case.tendon_plantar_R.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_plantar_R.tendonReflex);
        EditorGUILayout.EndHorizontal();

        //Lower limb - Left
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Left Patellar", GUILayout.MaxWidth(100));
        g_Case.tendon_patellar_L.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_patellar_L.tendonReflex);
        EditorGUILayout.LabelField("Left Ankle", GUILayout.MaxWidth(100));
        g_Case.tendon_ankle_L.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_ankle_L.tendonReflex);
        EditorGUILayout.LabelField("Left Plantar", GUILayout.MaxWidth(100));
        g_Case.tendon_plantar_L.tendonReflex = (Tendon.TendonReflex)EditorGUILayout.EnumPopup(g_Case.tendon_plantar_L.tendonReflex);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Sensation
        EditorGUILayout.LabelField("Sensation (Check if can feel)", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        //EditorGUILayout.LabelField("", EditorStyles.boldLabel);
        //EditorGUILayout.LabelField("R", EditorStyles.boldLabel);
        //EditorGUILayout.LabelField("L", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();

        //Upper limbs
        EditorGUILayout.LabelField("Upper limb regions", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        g_Case.UL_T1_R = EditorGUILayout.ToggleLeft("T1 Right", g_Case.UL_T1_R, GUILayout.MaxWidth(120));
        g_Case.UL_T1_L = EditorGUILayout.ToggleLeft("T1 Left", g_Case.UL_T1_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.UL_C5_R = EditorGUILayout.ToggleLeft("C5 Right", g_Case.UL_C5_R, GUILayout.MaxWidth(120));
        g_Case.UL_C5_L = EditorGUILayout.ToggleLeft("C5 Left", g_Case.UL_C5_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.UL_C6_R_1 = EditorGUILayout.ToggleLeft("C6 Right 1", g_Case.UL_C6_R_1, GUILayout.MaxWidth(120));
        g_Case.UL_C6_R_2 = EditorGUILayout.ToggleLeft("C6 Right 2", g_Case.UL_C6_R_2, GUILayout.MaxWidth(120));
        g_Case.UL_C6_R_3 = EditorGUILayout.ToggleLeft("C6 Right 3", g_Case.UL_C6_R_3, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.UL_C6_L_1 = EditorGUILayout.ToggleLeft("C6 Left 1", g_Case.UL_C6_L_1, GUILayout.MaxWidth(120));
        g_Case.UL_C6_L_2 = EditorGUILayout.ToggleLeft("C6 Left 2", g_Case.UL_C6_L_2, GUILayout.MaxWidth(120));
        g_Case.UL_C6_L_3 = EditorGUILayout.ToggleLeft("C6 Left 3", g_Case.UL_C6_L_3, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.UL_C7_R = EditorGUILayout.ToggleLeft("C7 Right", g_Case.UL_C7_R, GUILayout.MaxWidth(120));
        g_Case.UL_C7_L = EditorGUILayout.ToggleLeft("C7 Left", g_Case.UL_C7_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.UL_C8_R_1 = EditorGUILayout.ToggleLeft("C8 Right 1", g_Case.UL_C8_R_1, GUILayout.MaxWidth(120));
        g_Case.UL_C8_R_2 = EditorGUILayout.ToggleLeft("C8 Right 2", g_Case.UL_C8_R_2, GUILayout.MaxWidth(120));
        g_Case.UL_C8_R_3 = EditorGUILayout.ToggleLeft("C8 Right 3", g_Case.UL_C8_R_3, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.UL_C8_L_1 = EditorGUILayout.ToggleLeft("C8 Left 1", g_Case.UL_C8_L_1, GUILayout.MaxWidth(120));
        g_Case.UL_C8_L_2 = EditorGUILayout.ToggleLeft("C8 Left 2", g_Case.UL_C8_L_2, GUILayout.MaxWidth(120));
        g_Case.UL_C8_L_3 = EditorGUILayout.ToggleLeft("C8 Left 3", g_Case.UL_C8_L_3, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();

        //Lower limbs
        EditorGUILayout.LabelField("Lower limb regions", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        g_Case.LL_L2_R = EditorGUILayout.ToggleLeft("L2 Right", g_Case.LL_L2_R, GUILayout.MaxWidth(120));
        g_Case.LL_L2_L = EditorGUILayout.ToggleLeft("L2 Left", g_Case.LL_L2_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.LL_L3_R = EditorGUILayout.ToggleLeft("L3 Right", g_Case.LL_L3_R, GUILayout.MaxWidth(120));
        g_Case.LL_L3_L = EditorGUILayout.ToggleLeft("L3 Left", g_Case.LL_L3_L, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.LL_L4_R_1 = EditorGUILayout.ToggleLeft("L4 Right 1", g_Case.LL_L4_R_1, GUILayout.MaxWidth(120));
        g_Case.LL_L4_R_2 = EditorGUILayout.ToggleLeft("L4 Right 2", g_Case.LL_L4_R_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.LL_L4_L_1 = EditorGUILayout.ToggleLeft("L4 Left 1", g_Case.LL_L4_L_1, GUILayout.MaxWidth(120));
        g_Case.LL_L4_L_2 = EditorGUILayout.ToggleLeft("L4 Left 2", g_Case.LL_L4_L_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.LL_L5_R_1 = EditorGUILayout.ToggleLeft("L5 Right 1", g_Case.LL_L5_R_1, GUILayout.MaxWidth(120));
        g_Case.LL_L5_R_2 = EditorGUILayout.ToggleLeft("L5 Right 2", g_Case.LL_L5_R_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.LL_L5_L_1 = EditorGUILayout.ToggleLeft("L5 Left 1", g_Case.LL_L5_L_1, GUILayout.MaxWidth(120));
        g_Case.LL_L5_L_2 = EditorGUILayout.ToggleLeft("L5 Left 2", g_Case.LL_L5_L_2, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.LL_S1_R = EditorGUILayout.ToggleLeft("S1 Right", g_Case.LL_S1_R, GUILayout.MaxWidth(120));
        g_Case.LL_S1_L = EditorGUILayout.ToggleLeft("S1 Left", g_Case.LL_S1_L, GUILayout.MaxWidth(120));
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
        g_Case.UL_Shoulder_A_R = EditorGUILayout.TextField(g_Case.UL_Shoulder_A_R);
        g_Case.UL_Shoulder_A_L = EditorGUILayout.TextField(g_Case.UL_Shoulder_A_L);
        EditorGUILayout.EndHorizontal();

        //Elbow
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Elbow   /   Flexion", EditorStyles.boldLabel);
        g_Case.UL_Elbow_F_R = EditorGUILayout.TextField(g_Case.UL_Elbow_F_R);
        g_Case.UL_Elbow_F_L = EditorGUILayout.TextField(g_Case.UL_Elbow_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Elbow   /   Extension", EditorStyles.boldLabel);
        g_Case.UL_Elbow_E_R = EditorGUILayout.TextField(g_Case.UL_Elbow_E_R);
        g_Case.UL_Elbow_E_L = EditorGUILayout.TextField(g_Case.UL_Elbow_E_L);
        EditorGUILayout.EndHorizontal();

        //Wrist
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Wrist   /   Flexion", EditorStyles.boldLabel);
        g_Case.UL_Wrist_F_R = EditorGUILayout.TextField(g_Case.UL_Wrist_F_R);
        g_Case.UL_Wrist_F_L = EditorGUILayout.TextField(g_Case.UL_Wrist_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Wrist   /   Extension", EditorStyles.boldLabel);
        g_Case.UL_Wrist_E_R = EditorGUILayout.TextField(g_Case.UL_Wrist_E_R);
        g_Case.UL_Wrist_E_L = EditorGUILayout.TextField(g_Case.UL_Wrist_E_L);
        EditorGUILayout.EndHorizontal();

        //Finger
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Finger   /   Flexion", EditorStyles.boldLabel);
        g_Case.UL_Finger_F_R = EditorGUILayout.TextField(g_Case.UL_Finger_F_R);
        g_Case.UL_Finger_F_L = EditorGUILayout.TextField(g_Case.UL_Finger_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Finger   /   Extension", EditorStyles.boldLabel);
        g_Case.UL_Finger_E_R = EditorGUILayout.TextField(g_Case.UL_Finger_E_R);
        g_Case.UL_Finger_E_L = EditorGUILayout.TextField(g_Case.UL_Finger_E_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Finger   /   Abduction", EditorStyles.boldLabel);
        g_Case.UL_Finger_A_R = EditorGUILayout.TextField(g_Case.UL_Finger_A_R);
        g_Case.UL_Finger_A_L = EditorGUILayout.TextField(g_Case.UL_Finger_A_L);
        EditorGUILayout.EndHorizontal();

        //Thumb
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Thumb   /   Flexion", EditorStyles.boldLabel);
        g_Case.UL_Thumb_F_R = EditorGUILayout.TextField(g_Case.UL_Thumb_F_R);
        g_Case.UL_Thumb_F_L = EditorGUILayout.TextField(g_Case.UL_Thumb_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Thumb   /   Extension", EditorStyles.boldLabel);
        g_Case.UL_Thumb_E_R = EditorGUILayout.TextField(g_Case.UL_Thumb_E_R);
        g_Case.UL_Thumb_E_L = EditorGUILayout.TextField(g_Case.UL_Thumb_E_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("UL  /   Thumb   /   Adduction", EditorStyles.boldLabel);
        g_Case.UL_Thumb_A_R = EditorGUILayout.TextField(g_Case.UL_Thumb_A_R);
        g_Case.UL_Thumb_A_L = EditorGUILayout.TextField(g_Case.UL_Thumb_A_L);
        EditorGUILayout.EndHorizontal();

        //Lower limbs
        //Hip
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Hip     /   Flexion", EditorStyles.boldLabel);
        g_Case.LL_Hip_F_R = EditorGUILayout.TextField(g_Case.LL_Hip_F_R);
        g_Case.LL_Hip_F_L = EditorGUILayout.TextField(g_Case.LL_Hip_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Hip     /   Extension", EditorStyles.boldLabel);
        g_Case.LL_Hip_E_R = EditorGUILayout.TextField(g_Case.LL_Hip_E_R);
        g_Case.LL_Hip_E_L = EditorGUILayout.TextField(g_Case.LL_Hip_E_L);
        EditorGUILayout.EndHorizontal();

        //Knee
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Knee    /   Flexion", EditorStyles.boldLabel);
        g_Case.LL_Knee_F_R = EditorGUILayout.TextField(g_Case.LL_Knee_F_R);
        g_Case.LL_Knee_F_L = EditorGUILayout.TextField(g_Case.LL_Knee_F_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Knee    /   Extension", EditorStyles.boldLabel);
        g_Case.LL_Knee_E_R = EditorGUILayout.TextField(g_Case.LL_Knee_E_R);
        g_Case.LL_Knee_E_L = EditorGUILayout.TextField(g_Case.LL_Knee_E_L);
        EditorGUILayout.EndHorizontal();

        //Ankle
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Ankle    /   Dorsiflexion", EditorStyles.boldLabel);
        g_Case.LL_Ankle_DF_R = EditorGUILayout.TextField(g_Case.LL_Ankle_DF_R);
        g_Case.LL_Ankle_DF_L = EditorGUILayout.TextField(g_Case.LL_Ankle_DF_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("LL  /   Ankle    /   Plantarflexion", EditorStyles.boldLabel);
        g_Case.LL_Ankle_PF_R = EditorGUILayout.TextField(g_Case.LL_Ankle_PF_R);
        g_Case.LL_Ankle_PF_L = EditorGUILayout.TextField(g_Case.LL_Ankle_PF_L);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Eliminate from neuraxis (Absolute options)
        EditorGUILayout.LabelField("Eliminate from Neuraxis (Leave blank to eliminate)", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        g_Case.neuraxis_C = EditorGUILayout.ToggleLeft("C", g_Case.neuraxis_C, GUILayout.MaxWidth(120));
        g_Case.neuraxis_SC = EditorGUILayout.ToggleLeft("SC", g_Case.neuraxis_SC, GUILayout.MaxWidth(120));
        g_Case.neuraxis_BS = EditorGUILayout.ToggleLeft("BS", g_Case.neuraxis_BS, GUILayout.MaxWidth(120));
        g_Case.neuraxis_SCORD = EditorGUILayout.ToggleLeft("SCORD", g_Case.neuraxis_SCORD, GUILayout.MaxWidth(120));
        g_Case.neuraxis_AHC = EditorGUILayout.ToggleLeft("AHC", g_Case.neuraxis_AHC, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        g_Case.neuraxis_R = EditorGUILayout.ToggleLeft("R", g_Case.neuraxis_R, GUILayout.MaxWidth(120));
        g_Case.neuraxis_P = EditorGUILayout.ToggleLeft("P", g_Case.neuraxis_P, GUILayout.MaxWidth(120));
        g_Case.neuraxis_PN = EditorGUILayout.ToggleLeft("PN", g_Case.neuraxis_PN, GUILayout.MaxWidth(120));
        g_Case.neuraxis_NMJ = EditorGUILayout.ToggleLeft("NMJ", g_Case.neuraxis_NMJ, GUILayout.MaxWidth(120));
        g_Case.neuraxis_M = EditorGUILayout.ToggleLeft("M", g_Case.neuraxis_M, GUILayout.MaxWidth(120));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Test question
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Test Question: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        g_Case.testQuestion = EditorGUILayout.TextArea(g_Case.testQuestion, GUILayout.ExpandWidth(false), GUILayout.Width(400), GUILayout.MaxHeight(100));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //Test type (Single/Multiple)
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Test Type", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        g_Case.testType = (Case.TestType)EditorGUILayout.EnumPopup(g_Case.testType, GUILayout.MaxWidth(100));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //Concluding Test
        EditorGUILayout.LabelField("Concluding Test (Leave blank if necessary)", EditorStyles.boldLabel);
        g_Case.concludingTests[0] = EditorGUILayout.TextField("Enter option for A)", g_Case.concludingTests[0]);
        g_Case.concludingTests[1] = EditorGUILayout.TextField("Enter option for B)", g_Case.concludingTests[1]);
        g_Case.concludingTests[2] = EditorGUILayout.TextField("Enter option for C)", g_Case.concludingTests[2]);
        g_Case.concludingTests[3] = EditorGUILayout.TextField("Enter option for D)", g_Case.concludingTests[3]);
        g_Case.concludingTests[4] = EditorGUILayout.TextField("Enter option for E)", g_Case.concludingTests[4]);
        EditorGUILayout.Space();
        
        //Number of options
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Number of options: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        g_Case.optionCount = EditorGUILayout.IntField(g_Case.optionCount, GUILayout.MaxWidth(50));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Steps in localising
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Steps in localising: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        g_Case.localising = EditorGUILayout.TextArea(g_Case.localising, GUILayout.ExpandWidth(false), GUILayout.Width(400), GUILayout.MaxHeight(100));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //Localising steps
        EditorGUILayout.LabelField("Localising steps (Leave blank if necessary)", EditorStyles.boldLabel);
        g_Case.localisingSteps[0] = EditorGUILayout.TextField("Enter localising step #1", g_Case.localisingSteps[0]);
        g_Case.localisingSteps[1] = EditorGUILayout.TextField("Enter localising step #2", g_Case.localisingSteps[1]);
        g_Case.localisingSteps[2] = EditorGUILayout.TextField("Enter localising step #3", g_Case.localisingSteps[2]);
        g_Case.localisingSteps[3] = EditorGUILayout.TextField("Enter localising step #4", g_Case.localisingSteps[3]);
        EditorGUILayout.Space();

        //Answer to Concluding Test
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Correct Answer: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        g_Case.answer = (Case.Answer) EditorGUILayout.EnumPopup(g_Case.answer, GUILayout.MaxWidth(50));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        //Rationale
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Rationale: ", EditorStyles.boldLabel, GUILayout.MaxWidth(145));
        g_Case.rationale = EditorGUILayout.TextArea(g_Case.rationale, GUILayout.ExpandWidth(false), GUILayout.Width(400), GUILayout.MaxHeight(100));
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUILayout.EndScrollView();

        //END//
        EditorGUILayout.Space();

        //Close
        if (GUILayout.Button("Save & Close")) {
            Close();
        }
    }
}
