using NeuroApp;

[System.Serializable]
public class Case {
    #region Generic Variables
    public bool isEnabled = true;                           //Will this condition item be enabled in the list?
    public string caseName = "<DefaultCase>";               //What is the condition's name?
    public string caseDescription = "<CaseDescription>";    //A description for the condition
    public int caseScore = 0;                               //Case highest score
    public bool bonusCorrect = false;                       //Case star rating system
    public enum Tone { Normal, Abnormal }                   //Tone enumeration
    public string tone;                                     //Tone
    public string plantars;                                 //Plantars
    public string cerebellarSigns;                          //Cerebellar signs
    #endregion

    #region Deep Tendon Reflexes (DTR)
    //(+++) - Hyperactive
    //(++) - Normal
    //(+) - Sluggish
    //(-) - Absent
    public Tendon tendon_tricep_R = new Tendon();           //Tendon Tricep R
    public Tendon tendon_bicep_R = new Tendon();            //Tendon Bicep R
    public Tendon tendon_supinator_R = new Tendon();        //Tendon Supinator R
    public Tendon tendon_tricep_L = new Tendon();           //Tendon Tricep L
    public Tendon tendon_bicep_L = new Tendon();            //Tendon Bicep L
    public Tendon tendon_supinator_L = new Tendon();        //Tendon Supinator L
    public Tendon tendon_patellar_R = new Tendon();         //Tendon Patellar R
    public Tendon tendon_ankle_R = new Tendon();            //Tendon Ankle R
    public Tendon tendon_plantar_R = new Tendon();          //Tendon Plantar R
    public Tendon tendon_patellar_L = new Tendon();         //Tendon Patellar L
    public Tendon tendon_ankle_L = new Tendon();            //Tendon Ankle L
    public Tendon tendon_plantar_L = new Tendon();          //Tendon Plantar L
    #endregion

    #region Sensation Variables
    //True - Normal
    //False - Decreased
    //Format - LIMB_REGION_SIDE_SECTION
    //Upper limbs (From shoulder to fingertip)
    public bool UL_T1_R, UL_T1_L;
    public bool UL_C5_R, UL_C5_L;
    public bool UL_C6_R_1, UL_C6_R_2;
    public bool UL_C6_L_1, UL_C6_L_2;
    public bool UL_C7_R, UL_C7_L;
    public bool UL_C8_R_1, UL_C8_R_2;
    public bool UL_C8_L_1, UL_C8_L_2;
    //Lower limbs (From hip to toe)
    public bool LL_L2_R, LL_L2_L;
    public bool LL_L3_R, LL_L3_L;
    public bool LL_L4_R_1, LL_L4_R_2;
    public bool LL_L4_L_1, LL_L4_L_2;
    public bool LL_L5_R_1, LL_L5_R_2;
    public bool LL_L5_L_1, LL_L5_L_2;
    public bool LL_S1_R, LL_S1_L;
    #endregion

    #region Power Variables
    //0 - No movement
    //1 - Flicker of contraction
    //2 - Movement if gravity eliminated
    //3 - Can overcome gravity but not resistance
    //4 - Moderate movement against resistance
    //5 - Normal power
    public string UL_Shoulder_A_R;                          //Upper Limb - Shoulder - Abduction - Right
    public string UL_Shoulder_A_L;                          //Upper Limb - Shoulder - Abduction - Left
    public string UL_Elbow_F_R;                             //Upper Limb - Elbow - Flexion - Right
    public string UL_Elbow_F_L;                             //Upper Limb - Elbow - Flexion - Left
    public string UL_Elbow_E_R;                             //Upper Limb - Elbow - Extension - Right
    public string UL_Elbow_E_L;                             //Upper Limb - Elbow - Extension - Left
    public string UL_Wrist_F_R;                             //Upper Limb - Wrist - Flexion - Right
    public string UL_Wrist_F_L;                             //Upper Limb - Wrist - Flexion - Left
    public string UL_Wrist_E_R;                             //Upper Limb - Wrist - Extension - Right
    public string UL_Wrist_E_L;                             //Upper Limb - Wrist - Extension - Left
    public string UL_Finger_F_R;                            //Upper Limb - Finger - Flexion - Right
    public string UL_Finger_F_L;                            //Upper Limb - Finger - Flexion - Left
    public string UL_Finger_E_R;                            //Upper Limb - Finger - Extension - Right
    public string UL_Finger_E_L;                            //Upper Limb - Finger - Extension - Left
    public string UL_Finger_A_R;                            //Upper Limb - Finger - Abduction - Right
    public string UL_Finger_A_L;                            //Upper Limb - Finger - Abduction - Left
    public string UL_Thumb_F_R;                            //Upper Limb - Thumb - Flexion - Right
    public string UL_Thumb_F_L;                            //Upper Limb - Thumb - Flexion - Left
    public string UL_Thumb_E_R;                            //Upper Limb - Thumb - Extension - Right
    public string UL_Thumb_E_L;                            //Upper Limb - Thumb - Extension - Left
    public string UL_Thumb_A_R;                            //Upper Limb - Thumb - Adduction - Right
    public string UL_Thumb_A_L;                            //Upper Limb - Thumb - Adduction - Left

    public string LL_Hip_F_R;                               //Lower Limb - Hip - Flexion - Right
    public string LL_Hip_F_L;                               //Lower Limb - Hip - Flexion - Left
    public string LL_Hip_E_R;                               //Lower Limb - Hip - Extension - Right
    public string LL_Hip_E_L;                               //Lower Limb - Hip - Extension - Left
    public string LL_Knee_F_R;                              //Lower Limb - Knee - Flexion - Right
    public string LL_Knee_F_L;                              //Lower Limb - Knee - Flexion - Left
    public string LL_Knee_E_R;                              //Lower Limb - Knee - Extension - Right
    public string LL_Knee_E_L;                              //Lower Limb - Knee - Extension - Left
    public string LL_Ankle_DF_R;                            //Lower Limb - Ankle - Dorsiflexion - Right
    public string LL_Ankle_DF_L;                            //Lower Limb - Ankle - Dorsiflexion - Left
    public string LL_Ankle_PF_R;                            //Lower Limb - Ankle - Plantarflexion - Right
    public string LL_Ankle_PF_L;                            //Lower Limb - Ankle - Plantarflexion - Left
    public string LL_Toe_DF_R;                              //Lower Limb - Toe - Dorsiflexion - Right
    public string LL_Toe_DF_L;                              //Lower Limb - Toe - Dorsiflexion - Left
    public string LL_Toe_PF_R;                              //Lower Limb - Toe - Plantarflexion - Right
    public string LL_Toe_PF_L;                              //Lower Limb - Toe - Plantarflexion - Left
    #endregion

    #region Cranial
    //Torch
    public State state_Pupil_R;
    public State state_Pupil_L;
    public State state_Tongue_R;
    public State state_Tongue_L;
    public State state_Palate_R;
    public State state_Palate_L;
    //Power
    public State state_Brow_R;
    public State state_Brow_L;
    public State state_Eye_R;
    public State state_Eye_L;
    public State state_Mouth_R;
    public State state_Mouth_L;
    //Others
    public string hearing;
    public string cornealReflex;
    public string visualFields;
    public string gagReflex;
    public string speech;
    #endregion

    #region Neuroaxis Variables
    //Neuroaxis
    //Q: Please eliminate from neuroaxis:
    public bool neuraxis_C;         //Cortex
    public bool neuraxis_SC;        //Sub Cortex
    public bool neuraxis_BS;        //Brain Stem
    public bool neuraxis_SCORD;     //Spinal Cord
    public bool neuraxis_AHC;       //Anterior Horn Cell
    public bool neuraxis_R;         //Root
    public bool neuraxis_P;         //Plexus
    public bool neuraxis_PN;        //Peripheral Nerves
    public bool neuraxis_NMJ;       //Neuro Muscular Junction
    public bool neuraxis_M;         //Muscle
    #endregion

    #region Elimination hint variables
    public string[] neuraxis_hints;
    #endregion

    #region Concluding Test Variables
    //Type of test: Single-answer or multi-answer
    public enum TestType { Single, Multiple };
    public TestType testType = TestType.Single;

    //Number of options (MCQ); Default: 5
    public int optionCount = 5;

    //Q: What specific test would you do next? (A/B/C/D/E)
    public string testQuestion = "<Enter test question>";

    //Test options for player to choose from...
    public string[] concludingTests = new string [] {
        "Concluding Test #1",
        "Concluding Test #2",
        "Concluding Test #3",
        "Concluding Test #4",
        "Concluding Test #5"
    };

    //Steps in localising
    public string localising = "<Enter localising steps>";

    //Localising steps...
    public string[] localisingSteps = new string[] {
        "Localising Step #1",
        "Localising Step #2",
        "Localising Step #3",
        "Localising Step #4"
    };

    //A: Correct answer is?
    public enum Answer {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4
    }
    public Answer answer;

    //Rationale
    public string rationale = "<Enter rationale>";
    #endregion

    #region To-be-implemented
    //+++++++++Not yet implemented+++++++++//

    //Obsolete
    //Temperature
    //Arms, face, trunk, hands, legs, and feet

    //Obsolete
    //Proprioception (Joint position sense)
    //Upper Limb - Distal interphalangeal joint of the index finger
    //Lower Limb - Interphalangeal joint of the big toe
    #endregion
}