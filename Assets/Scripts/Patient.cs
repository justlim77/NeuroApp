using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Patient : MonoBehaviour
{
    public static Case g_PatientCase = null;    //Patient's condition

    public Text caseDescriptionText;            //Case description heading
    public int caseStars;                       //Case star rating system

    #region Clinical Exam Variables
    public Text toneText;                       //Tone
    public Text plantarsText;                   //Plantars
    public Text cranialNerveText;               //Cranial Nerve
    public Text cerebellarSignsText;            //Cerebellar Signs
    #endregion

    #region Power Variables
    //Power
    //Upper limb
    public Text UL_Shoulder_A_R;
    public Text UL_Shoulder_A_L;
    public Text UL_Elbow_F_R;
    public Text UL_Elbow_F_L;
    public Text UL_Elbow_E_R;
    public Text UL_Elbow_E_L;
    public Text UL_Wrist_F_R;
    public Text UL_Wrist_F_L;
    public Text UL_Wrist_E_R;
    public Text UL_Wrist_E_L;
    public Text UL_Finger_A_R;
    public Text UL_Finger_A_L;
    public Text UL_Finger_F_R;
    public Text UL_Finger_F_L;
    public Text UL_Finger_E_R;
    public Text UL_Finger_E_L;
    //Lower limb
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
    #endregion

    #region Sensation Variables
    //True - Normal
    //False - Decreased
    //Format - LIMB_REGION_SIDE_SECTION
    //Upper limbs (From shoulder to fingertip)
    public PinObject UL_T1_R, UL_T1_L;
    public PinObject UL_C5_R, UL_C5_L;
    public PinObject UL_C6_R_1, UL_C6_R_2, UL_C6_R_3;
    public PinObject UL_C6_L_1, UL_C6_L_2, UL_C6_L_3;
    public PinObject UL_C7_R, UL_C7_L;
    public PinObject UL_C8_R_1, UL_C8_R_2, UL_C8_R_3;
    public PinObject UL_C8_L_1, UL_C8_L_2, UL_C8_L_3;
    //Lower limbs (From hip to toe)
    public PinObject LL_L2_R, LL_L2_L;
    public PinObject LL_L3_R, LL_L3_L;
    public PinObject LL_L4_R_1, LL_L4_R_2;
    public PinObject LL_L4_L_1, LL_L4_L_2;
    public PinObject LL_L5_R_1, LL_L5_R_2;
    public PinObject LL_L5_L_1, LL_L5_L_2;
    public PinObject LL_S1_R, LL_S1_L;
    #endregion

    #region Deep Tendon Reflex Variables
    //Deep Tendon Reflexes
    public TendonObject tendon_tricep_R;
    public TendonObject tendon_bicep_R;
    public TendonObject tendon_supinator_R;
    public TendonObject tendon_tricep_L;
    public TendonObject tendon_bicep_L;
    public TendonObject tendon_supinator_L;
    public TendonObject tendon_patellar_R;
    public TendonObject tendon_ankle_R;
    public TendonObject tendon_plantar_R;
    public TendonObject tendon_patellar_L;
    public TendonObject tendon_ankle_L;
    public TendonObject tendon_plantar_L;
    #endregion

    #region Neuroaxis Variables
    //Neuraxis Elimination
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

    public Text localisingText;         //Explanation (Localising Steps)
    public string[] localisingSteps;    //Localising steps
    public Text testQuestionText;       //Concluding test question
    public string[] concludingTests;    //Concluding tests
    public Case.Answer answer;          //Correct concluding test choice
    public Text rationaleText;          //Rationale for test choice
    #endregion

    //Case database (DB) reference
    [SerializeField] private CaseDatabase m_CaseDatabase;

    private bool Init()
    {        
        caseDescriptionText.text = g_PatientCase.caseDescription;   //Case description setup
        caseStars = 0;                                              //Case star system setup
        toneText.text = g_PatientCase.tone.ToString();              //Tone setup
        plantarsText.text = g_PatientCase.plantars;                 //Plantars setup
        cranialNerveText.text = g_PatientCase.cranialNerve;         //Cranial nerve setup
        cerebellarSignsText.text = g_PatientCase.cerebellarSigns;   //Cerebellar signs setup

        //Power table setup
        //Find references
        //if (UL_Shoulder_A_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Shoulder-A-R").GetComponent<Text>();
        //if (UL_Shoulder_A_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Shoulder-A-L").GetComponent<Text>();
        //if (UL_Elbow_F_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Elbow-F-R").GetComponent<Text>();
        //if (UL_Elbow_F_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Elbow-F-L").GetComponent<Text>();
        //if (UL_Elbow_E_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Elbow-E-R").GetComponent<Text>();
        //if (UL_Elbow_E_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Elbow-E-L").GetComponent<Text>();
        //if (UL_Wrist_F_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Wrist-F-R").GetComponent<Text>();
        //if (UL_Wrist_F_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Wrist-F-L").GetComponent<Text>();
        //if (UL_Wrist_E_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Wrist-E-R").GetComponent<Text>();
        //if (UL_Wrist_E_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Wrist-E-L").GetComponent<Text>();
        //if (UL_Finger_A_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Finger-A-R").GetComponent<Text>();
        //if (UL_Finger_A_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Finger-A-L").GetComponent<Text>();
        //if (UL_Finger_F_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Finger-F-R").GetComponent<Text>();
        //if (UL_Finger_F_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Finger-F-L").GetComponent<Text>();
        //if (UL_Finger_E_R == null) UL_Shoulder_A_R = GameObject.Find("UL-Finger-E-R").GetComponent<Text>();
        //if (UL_Finger_E_L == null) UL_Shoulder_A_R = GameObject.Find("UL-Finger-E-L").GetComponent<Text>();

        //if (LL_Hip_F_R == null) UL_Shoulder_A_R = GameObject.Find("LL-Hip-F-R").GetComponent<Text>();
        //if (LL_Hip_F_L == null) UL_Shoulder_A_R = GameObject.Find("LL-Hip-F-L").GetComponent<Text>();
        //if (LL_Hip_E_R == null) UL_Shoulder_A_R = GameObject.Find("LL-Hip-E-R").GetComponent<Text>();
        //if (LL_Hip_E_L == null) UL_Shoulder_A_R = GameObject.Find("LL-Hip-E-L").GetComponent<Text>();
        //if (LL_Knee_F_R == null) UL_Shoulder_A_R = GameObject.Find("LL-Knee-F-R").GetComponent<Text>();
        //if (LL_Knee_F_L == null) UL_Shoulder_A_R = GameObject.Find("LL-Knee-F-L").GetComponent<Text>();
        //if (LL_Knee_E_R == null) UL_Shoulder_A_R = GameObject.Find("LL-Knee-E-R").GetComponent<Text>();
        //if (LL_Knee_E_L == null) UL_Shoulder_A_R = GameObject.Find("LL-Knee-E-L").GetComponent<Text>();
        //if (LL_Ankle_DF_R == null) UL_Shoulder_A_R = GameObject.Find("LL-Ankle-DF-R").GetComponent<Text>();
        //if (LL_Ankle_PF_L == null) UL_Shoulder_A_R = GameObject.Find("LL-Ankle-PF-L").GetComponent<Text>();
        //if (LL_Ankle_DF_R == null) UL_Shoulder_A_R = GameObject.Find("LL-Ankle-DF-R").GetComponent<Text>();
        //if (LL_Ankle_PF_L == null) UL_Shoulder_A_R = GameObject.Find("LL-Ankle-PF-L").GetComponent<Text>();

        //Upper limbs
        //Shoulder
        UL_Shoulder_A_R.text = g_PatientCase.UL_Shoulder_A_R;
        UL_Shoulder_A_L.text = g_PatientCase.UL_Shoulder_A_L;
        //Elbow
        UL_Elbow_F_R.text = g_PatientCase.UL_Elbow_F_R;
        UL_Elbow_F_L.text = g_PatientCase.UL_Elbow_F_L;
        UL_Elbow_E_R.text = g_PatientCase.UL_Elbow_E_R;
        UL_Elbow_E_L.text = g_PatientCase.UL_Elbow_E_L;
        //Wrist
        UL_Wrist_F_R.text = g_PatientCase.UL_Wrist_F_R;
        UL_Wrist_F_L.text = g_PatientCase.UL_Wrist_F_L;
        UL_Wrist_E_R.text = g_PatientCase.UL_Wrist_E_R;
        UL_Wrist_E_L.text = g_PatientCase.UL_Wrist_E_L;
        //Finger
        UL_Finger_A_R.text = g_PatientCase.UL_Finger_A_R;
        UL_Finger_A_L.text = g_PatientCase.UL_Finger_A_L;
        UL_Finger_F_R.text = g_PatientCase.UL_Finger_F_R;
        UL_Finger_F_L.text = g_PatientCase.UL_Finger_F_L;
        UL_Finger_E_R.text = g_PatientCase.UL_Finger_E_R;
        UL_Finger_E_L.text = g_PatientCase.UL_Finger_E_L;
        //Lower limbs
        //Hip
        LL_Hip_F_R.text = g_PatientCase.LL_Hip_F_R;
        LL_Hip_F_L.text = g_PatientCase.LL_Hip_F_L;
        LL_Hip_E_R.text = g_PatientCase.LL_Hip_E_R;
        LL_Hip_E_L.text = g_PatientCase.LL_Hip_E_L;
        //Knee
        LL_Knee_F_R.text = g_PatientCase.LL_Knee_F_R;
        LL_Knee_F_L.text = g_PatientCase.LL_Knee_F_L;
        LL_Knee_E_R.text = g_PatientCase.LL_Knee_E_R;
        LL_Knee_E_L.text = g_PatientCase.LL_Knee_E_L;
        //Ankle
        LL_Ankle_DF_R.text = g_PatientCase.LL_Ankle_DF_R;
        LL_Ankle_DF_L.text = g_PatientCase.LL_Ankle_DF_L;
        LL_Ankle_PF_R.text = g_PatientCase.LL_Ankle_PF_R;
        LL_Ankle_PF_L.text = g_PatientCase.LL_Ankle_PF_L;

        //DTR setup
        //Upper limbs
        tendon_tricep_R.tendon = g_PatientCase.tendon_tricep_R;
        tendon_bicep_R.tendon = g_PatientCase.tendon_bicep_R;
        tendon_supinator_R.tendon = g_PatientCase.tendon_supinator_R;
        tendon_tricep_L.tendon = g_PatientCase.tendon_tricep_L;
        tendon_bicep_L.tendon = g_PatientCase.tendon_bicep_L;
        tendon_supinator_L.tendon = g_PatientCase.tendon_supinator_L;
        //Lower limbs
        tendon_patellar_R.tendon = g_PatientCase.tendon_patellar_R;
        tendon_ankle_R.tendon = g_PatientCase.tendon_ankle_R;
        tendon_plantar_R.tendon = g_PatientCase.tendon_plantar_R;
        tendon_patellar_L.tendon = g_PatientCase.tendon_patellar_L;
        tendon_ankle_L.tendon = g_PatientCase.tendon_ankle_L;
        tendon_plantar_L.tendon = g_PatientCase.tendon_plantar_L;

        //Sensation setup
        //Upper limbs
        UL_T1_R.canFeel = g_PatientCase.UL_T1_R;
        UL_T1_L.canFeel = g_PatientCase.UL_T1_L;
        UL_C5_R.canFeel = g_PatientCase.UL_C5_R;
        UL_C5_L.canFeel = g_PatientCase.UL_C5_L;
        UL_C6_R_1.canFeel = g_PatientCase.UL_C6_R_1;
        UL_C6_R_2.canFeel = g_PatientCase.UL_C6_R_2;
        UL_C6_R_3.canFeel = g_PatientCase.UL_C6_R_3;
        UL_C6_L_1.canFeel = g_PatientCase.UL_C6_L_1;
        UL_C6_L_2.canFeel = g_PatientCase.UL_C6_L_2;
        UL_C6_L_3.canFeel = g_PatientCase.UL_C6_L_3;
        UL_C7_R.canFeel = g_PatientCase.UL_C7_R;
        UL_C7_L.canFeel = g_PatientCase.UL_C7_L;
        UL_C8_R_1.canFeel = g_PatientCase.UL_C8_R_1;
        UL_C8_R_2.canFeel = g_PatientCase.UL_C8_R_2;
        UL_C8_R_3.canFeel = g_PatientCase.UL_C8_R_3;
        UL_C8_L_1.canFeel = g_PatientCase.UL_C8_L_1;
        UL_C8_L_2.canFeel = g_PatientCase.UL_C8_L_2;
        UL_C8_L_3.canFeel = g_PatientCase.UL_C8_L_3;
        //Lower limbs
        LL_L2_R.canFeel = g_PatientCase.LL_L2_R;
        LL_L2_L.canFeel = g_PatientCase.LL_L2_L;
        LL_L3_R.canFeel = g_PatientCase.LL_L3_R;
        LL_L3_L.canFeel = g_PatientCase.LL_L3_L;
        LL_L4_R_1.canFeel = g_PatientCase.LL_L4_R_1;
        LL_L4_R_2.canFeel = g_PatientCase.LL_L4_R_2;
        LL_L4_L_1.canFeel = g_PatientCase.LL_L4_L_1;
        LL_L4_L_2.canFeel = g_PatientCase.LL_L4_L_2;
        LL_L5_R_1.canFeel = g_PatientCase.LL_L5_R_1;
        LL_L5_R_2.canFeel = g_PatientCase.LL_L5_R_2;
        LL_L5_L_1.canFeel = g_PatientCase.LL_L5_L_1;
        LL_L5_L_2.canFeel = g_PatientCase.LL_L5_L_2;
        LL_S1_R.canFeel = g_PatientCase.LL_S1_R;
        LL_S1_L.canFeel = g_PatientCase.LL_S1_L;

        //Neuraxis Elimination Game setup
        neuraxis_C = g_PatientCase.neuraxis_C;
        neuraxis_SC = g_PatientCase.neuraxis_SC;
        neuraxis_BS = g_PatientCase.neuraxis_BS;
        neuraxis_SCORD = g_PatientCase.neuraxis_SCORD;
        neuraxis_AHC = g_PatientCase.neuraxis_AHC;
        neuraxis_R = g_PatientCase.neuraxis_R;
        neuraxis_P = g_PatientCase.neuraxis_P;
        neuraxis_PN = g_PatientCase.neuraxis_PN;
        neuraxis_NMJ = g_PatientCase.neuraxis_NMJ;
        neuraxis_M = g_PatientCase.neuraxis_M;

        localisingText.text = g_PatientCase.localising;     //Localising setup
        localisingSteps = g_PatientCase.localisingSteps;    //Localising steps string array setup
        testQuestionText.text = g_PatientCase.testQuestion; //Concluding Test Question setup
        concludingTests = g_PatientCase.concludingTests;    //Concluding Test Game setup
        answer = g_PatientCase.answer;                      //Answer setup
        rationaleText.text = g_PatientCase.rationale;       //Rationale setup

        return true;
    }

    public void LoadCase(string abbreviation)
    {
        switch (abbreviation)
        {
            case ("Peripheral neuropathy"):
                g_PatientCase = m_CaseDatabase.m_CaseList.caseList[0];
                break;
            case ("Brachiofacial stroke"):
                g_PatientCase = m_CaseDatabase.m_CaseList.caseList[1];
                break;
            case ("Cervical myelopathy"):
                g_PatientCase = m_CaseDatabase.m_CaseList.caseList[2];
                break;
            default:
                break;
        }
        Init();
    }
}
