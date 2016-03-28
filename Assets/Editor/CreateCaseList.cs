using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateCaseList {
    [MenuItem("Assets/Create/Case List")]
    public static CaseList Create() {
        CaseList asset = ScriptableObject.CreateInstance<CaseList>();

        AssetDatabase.CreateAsset(asset, "Assets/Data/CaseList.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}
