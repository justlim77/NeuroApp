using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Patient : MonoBehaviour
{
    static Case _CaseData = null;
    public static Case CaseData
    {
        get { return _CaseData; }
        set { _CaseData = value; }
    }

    public Text caseDescriptionText;            //Case description heading

    #region Clinical Exam Variables
    public Text toneText;                       //Tone
    public Text plantarsText;                   //Plantars
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
    public Text UL_Finger_F_R;
    public Text UL_Finger_F_L;
    public Text UL_Finger_E_R;
    public Text UL_Finger_E_L;
    public Text UL_Finger_A_R;
    public Text UL_Finger_A_L;
    public Text UL_Thumb_F_R;
    public Text UL_Thumb_F_L;
    public Text UL_Thumb_E_R;
    public Text UL_Thumb_E_L;
    public Text UL_Thumb_A_R;
    public Text UL_Thumb_A_L;
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
    public Text LL_Toe_DF_R;
    public Text LL_Toe_DF_L;
    public Text LL_Toe_PF_R;
    public Text LL_Toe_PF_L;
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

    #region Elimination Variables
    //Neuroaxis Elimination
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

    void OnDestroy()
    {
        _CaseData = null;
    }
    private bool Init()
    {        
        caseDescriptionText.text = CaseData.caseDescription;   //Case description setup
        toneText.text = CaseData.tone.ToString();              //Tone setup
        plantarsText.text = CaseData.plantars;                 //Plantars setup
        cerebellarSignsText.text = CaseData.cerebellarSigns;   //Cerebellar signs setup

        //Upper limbs
        //Shoulder
        UL_Shoulder_A_R.text = CaseData.UL_Shoulder_A_R;
        UL_Shoulder_A_L.text = CaseData.UL_Shoulder_A_L;
        //Elbow
        UL_Elbow_F_R.text = CaseData.UL_Elbow_F_R;
        UL_Elbow_F_L.text = CaseData.UL_Elbow_F_L;
        UL_Elbow_E_R.text = CaseData.UL_Elbow_E_R;
        UL_Elbow_E_L.text = CaseData.UL_Elbow_E_L;
        //Wrist
        UL_Wrist_F_R.text = CaseData.UL_Wrist_F_R;
        UL_Wrist_F_L.text = CaseData.UL_Wrist_F_L;
        UL_Wrist_E_R.text = CaseData.UL_Wrist_E_R;
        UL_Wrist_E_L.text = CaseData.UL_Wrist_E_L;
        //Finger
        UL_Finger_A_R.text = CaseData.UL_Finger_A_R;
        UL_Finger_A_L.text = CaseData.UL_Finger_A_L;
        UL_Finger_F_R.text = CaseData.UL_Finger_F_R;
        UL_Finger_F_L.text = CaseData.UL_Finger_F_L;
        UL_Finger_E_R.text = CaseData.UL_Finger_E_R;
        UL_Finger_E_L.text = CaseData.UL_Finger_E_L;
        //Thumb
        UL_Thumb_A_R.text = CaseData.UL_Thumb_A_R;
        UL_Thumb_A_L.text = CaseData.UL_Thumb_A_L;
        UL_Thumb_F_R.text = CaseData.UL_Thumb_F_R;
        UL_Thumb_F_L.text = CaseData.UL_Thumb_F_L;
        UL_Thumb_E_R.text = CaseData.UL_Thumb_E_R;
        UL_Thumb_E_L.text = CaseData.UL_Thumb_E_L;
        //Lower limbs
        //Hip
        LL_Hip_F_R.text = CaseData.LL_Hip_F_R;
        LL_Hip_F_L.text = CaseData.LL_Hip_F_L;
        LL_Hip_E_R.text = CaseData.LL_Hip_E_R;
        LL_Hip_E_L.text = CaseData.LL_Hip_E_L;
        //Knee
        LL_Knee_F_R.text = CaseData.LL_Knee_F_R;
        LL_Knee_F_L.text = CaseData.LL_Knee_F_L;
        LL_Knee_E_R.text = CaseData.LL_Knee_E_R;
        LL_Knee_E_L.text = CaseData.LL_Knee_E_L;
        //Ankle
        LL_Ankle_DF_R.text = CaseData.LL_Ankle_DF_R;
        LL_Ankle_DF_L.text = CaseData.LL_Ankle_DF_L;
        LL_Ankle_PF_R.text = CaseData.LL_Ankle_PF_R;
        LL_Ankle_PF_L.text = CaseData.LL_Ankle_PF_L;

        //DTR setup
        //Upper limbs
        tendon_tricep_R.tendon = CaseData.tendon_tricep_R;
        tendon_bicep_R.tendon = CaseData.tendon_bicep_R;
        tendon_supinator_R.tendon = CaseData.tendon_supinator_R;
        tendon_tricep_L.tendon = CaseData.tendon_tricep_L;
        tendon_bicep_L.tendon = CaseData.tendon_bicep_L;
        tendon_supinator_L.tendon = CaseData.tendon_supinator_L;
        //Lower limbs
        tendon_patellar_R.tendon = CaseData.tendon_patellar_R;
        tendon_ankle_R.tendon = CaseData.tendon_ankle_R;
        tendon_plantar_R.tendon = CaseData.tendon_plantar_R;
        tendon_patellar_L.tendon = CaseData.tendon_patellar_L;
        tendon_ankle_L.tendon = CaseData.tendon_ankle_L;
        tendon_plantar_L.tendon = CaseData.tendon_plantar_L;

        //Sensation setup
        //Upper limbs
        UL_T1_R.canFeel = CaseData.UL_T1_R;
        UL_T1_L.canFeel = CaseData.UL_T1_L;
        UL_C5_R.canFeel = CaseData.UL_C5_R;
        UL_C5_L.canFeel = CaseData.UL_C5_L;
        UL_C6_R_1.canFeel = CaseData.UL_C6_R_1;
        UL_C6_R_2.canFeel = CaseData.UL_C6_R_2;
        UL_C6_R_3.canFeel = CaseData.UL_C6_R_3;
        UL_C6_L_1.canFeel = CaseData.UL_C6_L_1;
        UL_C6_L_2.canFeel = CaseData.UL_C6_L_2;
        UL_C6_L_3.canFeel = CaseData.UL_C6_L_3;
        UL_C7_R.canFeel = CaseData.UL_C7_R;
        UL_C7_L.canFeel = CaseData.UL_C7_L;
        UL_C8_R_1.canFeel = CaseData.UL_C8_R_1;
        UL_C8_R_2.canFeel = CaseData.UL_C8_R_2;
        UL_C8_R_3.canFeel = CaseData.UL_C8_R_3;
        UL_C8_L_1.canFeel = CaseData.UL_C8_L_1;
        UL_C8_L_2.canFeel = CaseData.UL_C8_L_2;
        UL_C8_L_3.canFeel = CaseData.UL_C8_L_3;
        //Lower limbs
        LL_L2_R.canFeel = CaseData.LL_L2_R;
        LL_L2_L.canFeel = CaseData.LL_L2_L;
        LL_L3_R.canFeel = CaseData.LL_L3_R;
        LL_L3_L.canFeel = CaseData.LL_L3_L;
        LL_L4_R_1.canFeel = CaseData.LL_L4_R_1;
        LL_L4_R_2.canFeel = CaseData.LL_L4_R_2;
        LL_L4_L_1.canFeel = CaseData.LL_L4_L_1;
        LL_L4_L_2.canFeel = CaseData.LL_L4_L_2;
        LL_L5_R_1.canFeel = CaseData.LL_L5_R_1;
        LL_L5_R_2.canFeel = CaseData.LL_L5_R_2;
        LL_L5_L_1.canFeel = CaseData.LL_L5_L_1;
        LL_L5_L_2.canFeel = CaseData.LL_L5_L_2;
        LL_S1_R.canFeel = CaseData.LL_S1_R;
        LL_S1_L.canFeel = CaseData.LL_S1_L;

        //Neuraxis Elimination Game setup
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

        localisingText.text = CaseData.localising;     //Localising setup
        localisingSteps = CaseData.localisingSteps;    //Localising steps string array setup
        testQuestionText.text = CaseData.testQuestion; //Concluding Test Question setup
        concludingTests = CaseData.concludingTests;    //Concluding Test Game setup
        answer = CaseData.answer;                      //Answer setup
        rationaleText.text = CaseData.rationale;       //Rationale setup

        return true;
    }

    public void LoadCase(int index)
    {
        CaseData = m_CaseDatabase.m_CaseList.caseList[index];

        Init();
    }
}
