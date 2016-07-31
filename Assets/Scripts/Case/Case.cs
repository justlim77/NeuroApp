using NeuroApp;

[System.Serializable]
public class Case {
    #region Generic Variables
    public bool isEnabled = true;                           // Will this condition item be enabled in the list?
    public string caseName = "<DefaultCase>";               // What is the condition's name?
    public string caseDescription = "<CaseDescription>";    // A description for the condition
    public int caseScore = 0;                               // Case highest score
    public bool bonusCorrect = false;                       // Case star rating system
    public string tone = "Normal";                          // Tone
    public string plantars = "Normal";                      // Plantars
    public string cerebellar = "Normal";                    // Cerebellar examination
    public string otherTests = "Nil";                       // Other important tests
    #endregion

    #region Face
    public Face face;
    #endregion

    #region Deep Tendon Reflexes (DTR)
    // (+++) - Hyperactive
    // (++) - Normal
    // (+) - Sluggish
    // (-) - Absent
    public TendonData tendon_tricep_R = new TendonData();           // Tendon Tricep R
    public TendonData tendon_bicep_R = new TendonData();            // Tendon Bicep R
    public TendonData tendon_supinator_R = new TendonData();        // Tendon Supinator R
    public TendonData tendon_tricep_L = new TendonData();           // Tendon Tricep L
    public TendonData tendon_bicep_L = new TendonData();            // Tendon Bicep L
    public TendonData tendon_supinator_L = new TendonData();        // Tendon Supinator L
    public TendonData tendon_patellar_R = new TendonData();         // Tendon Patellar R
    public TendonData tendon_ankle_R = new TendonData();            // Tendon Ankle R
    public TendonData tendon_plantar_R = new TendonData();          // Tendon Plantar R
    public TendonData tendon_patellar_L = new TendonData();         // Tendon Patellar L
    public TendonData tendon_ankle_L = new TendonData();            // Tendon Ankle L
    public TendonData tendon_plantar_L = new TendonData();          // Tendon Plantar L
    #endregion

    #region Dermatome Variables
    // True - Normal
    // False - Decreased
    // Format - LIMB_REGION_SIDE_SECTION
    // Upper extremity
    public bool UL_T4 = true, UL_T5_T9 = true, UL_T10 = true;
    public bool UL_T1_R = true, UL_T1_L = true;
    public bool UL_C5_R = true, UL_C5_L = true;
    public bool UL_C6_R_1 = true, UL_C6_R_2 = true;
    public bool UL_C6_L_1 = true, UL_C6_L_2 = true;
    public bool UL_C7_R = true, UL_C7_L = true;
    public bool UL_C8_R_1 = true, UL_C8_R_2 = true;
    public bool UL_C8_L_1 = true, UL_C8_L_2 = true;
    // Lower extremity
    public bool LL_L2_R = true, LL_L2_L = true;
    public bool LL_L3_R = true, LL_L3_L = true;
    public bool LL_L4_R_1 = true, LL_L4_R_2 = true;
    public bool LL_L4_L_1 = true, LL_L4_L_2 = true;
    public bool LL_L5_R_1 = true, LL_L5_R_2 = true;
    public bool LL_L5_L_1 = true, LL_L5_L_2 = true;
    public bool LL_S1_R = true, LL_S1_L = true;
    #endregion

    #region Power Variables
    // 0 - No movement
    // 1 - Flicker of contraction
    // 2 - Movement if gravity eliminated
    // 3 - Can overcome gravity but not resistance
    // 4 - Moderate movement against resistance
    // 5 - Normal power
    public string UL_Shoulder_AB_R = "5";                   //Upper Limb - Shoulder - Abduction - Right
    public string UL_Shoulder_AB_L = "5";                   //Upper Limb - Shoulder - Abduction - Left
    public string UL_Shoulder_AD_R = "5";                   //Upper Limb - Shoulder - Adduction - Right
    public string UL_Shoulder_AD_L = "5";                   //Upper Limb - Shoulder - Adduction - Left
    public string UL_Elbow_F_R = "5";                       //Upper Limb - Elbow - Flexion - Right
    public string UL_Elbow_F_L = "5";                       //Upper Limb - Elbow - Flexion - Left
    public string UL_Elbow_E_R = "5";                       //Upper Limb - Elbow - Extension - Right
    public string UL_Elbow_E_L = "5";                       //Upper Limb - Elbow - Extension - Left
    public string UL_Wrist_F_R = "5";                       //Upper Limb - Wrist - Flexion - Right
    public string UL_Wrist_F_L = "5";                       //Upper Limb - Wrist - Flexion - Left
    public string UL_Wrist_E_R = "5";                       //Upper Limb - Wrist - Extension - Right
    public string UL_Wrist_E_L = "5";                       //Upper Limb - Wrist - Extension - Left
    public string UL_Finger_F_R = "5";                      //Upper Limb - Finger - Flexion - Right
    public string UL_Finger_F_L = "5";                      //Upper Limb - Finger - Flexion - Left
    public string UL_Finger_E_R = "5";                      //Upper Limb - Finger - Extension - Right
    public string UL_Finger_E_L = "5";                      //Upper Limb - Finger - Extension - Left
    public string UL_Finger_AB_R = "5";                     //Upper Limb - Finger - Abduction - Right
    public string UL_Finger_AB_L = "5";                     //Upper Limb - Finger - Abduction - Left
    public string UL_Thumb_F_R = "5";                       //Upper Limb - Thumb - Flexion - Right
    public string UL_Thumb_F_L = "5";                       //Upper Limb - Thumb - Flexion - Left
    public string UL_Thumb_E_R = "5";                       //Upper Limb - Thumb - Extension - Right
    public string UL_Thumb_E_L = "5";                       //Upper Limb - Thumb - Extension - Left
    public string UL_Thumb_AB_R = "5";                      //Upper Limb - Thumb - Abduction - Right
    public string UL_Thumb_AB_L = "5";                      //Upper Limb - Thumb - Abduction - Left

    public string LL_Hip_F_R = "5";                         //Lower Limb - Hip - Flexion - Right
    public string LL_Hip_F_L = "5";                         //Lower Limb - Hip - Flexion - Left
    public string LL_Hip_E_R = "5";                         //Lower Limb - Hip - Extension - Right
    public string LL_Hip_E_L = "5";                         //Lower Limb - Hip - Extension - Left
    public string LL_Knee_F_R = "5";                        //Lower Limb - Knee - Flexion - Right
    public string LL_Knee_F_L = "5";                        //Lower Limb - Knee - Flexion - Left
    public string LL_Knee_E_R = "5";                        //Lower Limb - Knee - Extension - Right
    public string LL_Knee_E_L = "5";                        //Lower Limb - Knee - Extension - Left
    public string LL_Ankle_DF_R = "5";                      //Lower Limb - Ankle - Dorsiflexion - Right
    public string LL_Ankle_DF_L = "5";                      //Lower Limb - Ankle - Dorsiflexion - Left
    public string LL_Ankle_PF_R = "5";                      //Lower Limb - Ankle - Plantarflexion - Right
    public string LL_Ankle_PF_L = "5";                      //Lower Limb - Ankle - Plantarflexion - Left
    public string LL_Toe_DF_R = "5";                        //Lower Limb - Toe - Dorsiflexion - Right
    public string LL_Toe_DF_L = "5";                        //Lower Limb - Toe - Dorsiflexion - Left
    public string LL_Toe_PF_R = "5";                        //Lower Limb - Toe - Plantarflexion - Right
    public string LL_Toe_PF_L = "5";                        //Lower Limb - Toe - Plantarflexion - Left
    #endregion

    #region Cranial
    // Torch
    public State state_Pupil_R;
    public State state_Pupil_L;
    public State state_Tongue_R;
    public State state_Tongue_L;
    public State state_Palate_R;
    public State state_Palate_L;
    // Power
    public State state_Brow_R;
    public State state_Brow_L;
    public State state_Eye_R;
    public State state_Eye_L;
    public State state_Mouth_R;
    public State state_Mouth_L;
    // Sensation
    public bool face_upper_R = true, face_upper_L = true;
    public bool face_mid_R = true, face_mid_L = true;
    public bool face_lower_R = true, face_lower_L = true;
    // Others
    public string hearing = "Normal";
    public string cornealReflex = "Normal";
    public string visualFields = "Normal";
    public string gagReflex = "Normal";
    public string speech = "Nil";
    #endregion

    #region Neuroaxis Variables
    // Neuroaxis
    // Q: Please eliminate from neuroaxis:
    public bool neuraxis_C;         // Cortex
    public bool neuraxis_SC;        // Sub Cortex
    public bool neuraxis_BS;        // Brain Stem
    public bool neuraxis_SCORD;     // Spinal Cord
    public bool neuraxis_AHC;       // Anterior Horn Cell
    public bool neuraxis_R;         // Root
    public bool neuraxis_P;         // Plexus
    public bool neuraxis_PN;        // Peripheral Nerves
    public bool neuraxis_NMJ;       // Neuro Muscular Junction
    public bool neuraxis_M;         // Muscle
    #endregion

    #region Elimination hint
    public string[] neuraxis_hints;
    #endregion

    #region Localising Steps
    // Localising steps array
    public string[] localisingSteps = new string[] {
        "Localising Step #1",
        "Localising Step #2",
        "Localising Step #3",
        "Localising Step #4"
    };
    // Localising explanation
    public string localisingExplanation = "<Enter localising explanation>";
    #endregion

    #region Concluding Test
    // Type of test: Single-answer or multi-answer
    public TestType testType = TestType.Single;

    // Q: What specific test would you do next? (A/B/C/D/E)
    public string testQuestion = "<Enter test question>";

    // Test options for player to choose from...
    public string[] concludingTests = new string [] {
        "Concluding Test #1",
        "Concluding Test #2",
        "Concluding Test #3",
        "Concluding Test #4",
        "Concluding Test #5"
    };

    // A: Correct answer is?
    public Answer answer;

    // Answer explanation
    public string answerExplanation = "<Enter answer explanation>";
    #endregion
}