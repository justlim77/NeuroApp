using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class GameManager : Singleton<GameManager> {

    protected GameManager() { }

    public string caseName;
    public int caseScore;
    public int caseStars;

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/caseInfo.dat");

        CaseInfo info = new CaseInfo();
        info.caseName = Patient.g_PatientCase.caseName;
        info.caseScore = Patient.g_PatientCase.caseScore;
        info.caseStars = Patient.g_PatientCase.caseScore;

        bf.Serialize(file, info);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/caseInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/caseInfo.dat", FileMode.Open);
            CaseInfo info = (CaseInfo)bf.Deserialize(file);
            file.Close();

            caseName = info.caseName;
            caseScore = info.caseScore;
            caseStars = info.caseStars;
        }
    }
}

class CaseInfo
{
    public string caseName;
    public int caseScore;
    public int caseStars;
}