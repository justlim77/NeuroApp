using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CaseListEditor : EditorWindow {

    public CaseList caseList;

    private Vector2 scrollPos;

    [MenuItem("Window/Case List Editor %#e")]              //%#e = Ctrl + Shift + E shortcut
    static void Init() {
        EditorWindow window = EditorWindow.GetWindow(typeof(CaseListEditor));
        window.minSize = new Vector2(300, 310);
    }

    void OnEnable() {
        //string objectPath = string.Empty;

        if (EditorPrefs.HasKey("ObjectPath")) {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            caseList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CaseList)) as CaseList;
            //if (caseList == null) {
            //    CreateNewItemList();
            //    objectPath = EditorPrefs.GetString("ObjectPath");
            //    caseList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CaseList)) as CaseList;
            //}
        //} else {
        //    CreateNewItemList();
        //    objectPath = EditorPrefs.GetString("ObjectPath");
        //    caseList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CaseList)) as CaseList;
        }
    }

    void OnGUI() {
        GUILayout.Label("(Case List Editor)", EditorStyles.boldLabel);
        GUILayout.Label("(Default CaseList located in Assets/Data)", EditorStyles.miniBoldLabel);
        EditorGUILayout.Space();
        GUILayout.Label("1. Setup case list to edit.", EditorStyles.boldLabel);

        //Horizontal Layout - Options
        GUILayout.BeginHorizontal();
        if (caseList != null) {
            if(GUILayout.Button("Show List")) {
                Selection.activeObject = caseList;
                if (caseList) {
                    EditorUtility.FocusProjectWindow();
                    EditorGUIUtility.PingObject(caseList);
                }
            }
        }
        if (GUILayout.Button("Open List")) {
            OpenCaseList();
        }
        if (caseList == null) {
            if (GUILayout.Button("New List")) {
                CreateNewItemList();
                EditorUtility.FocusProjectWindow();
            }
        }
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        //Add New Condition Button
        if (caseList != null) {
            GUILayout.Label("2. Edit cases in selected case list.", EditorStyles.boldLabel);
            if (GUILayout.Button("Add New Case")) {
                AddCase();
            }

            //Scroll View for Conditions in List
            if (caseList.caseList != null) {
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true, GUILayout.Width(EditorGUIUtility.currentViewWidth), GUILayout.Height(100));
                for (var i = 0; i < caseList.caseList.Count; i++) {
                    EditorGUILayout.BeginHorizontal();
                    caseList.caseList[i].isEnabled = EditorGUILayout.ToggleLeft(new GUIContent(caseList.caseList[i].caseName), caseList.caseList[i].isEnabled);
                    if (GUILayout.Button("Edit")) {
                        CaseEditor.Init(caseList.caseList[i]);
                    }
                    if (GUILayout.Button("Delete")) {
                        caseList.caseList.Remove(caseList.caseList[i]);
                        if (caseList.caseList.Contains(null)) caseList.caseList.Remove(null);
                    }
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndScrollView();
            }
            if (GUI.changed) {
                EditorUtility.SetDirty(caseList);
            }
        }

        //Save & Close Window Button
        EditorGUILayout.Space();
        GUILayout.Label("3. Save & Close.", EditorStyles.boldLabel);
        if (GUILayout.Button("Close Window")) {
            Close();
        }
    }

    //Update Editor Window GUI 10 times per second
    void OnInspectorUpdate() {
        Repaint();
    }

    void CreateNewItemList()
    {
        caseList = CreateCaseList.Create();
        if (caseList)
        {
            string relPath = AssetDatabase.GetAssetPath(caseList);
            EditorPrefs.SetString("ObjectPath", relPath);
            //caseList = AssetDatabase.LoadAssetAtPath(relPath, typeof(CaseList)) as CaseList;
            //Selection.activeObject = caseList;
        }
    }

    void OpenCaseList()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Case List", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            caseList = AssetDatabase.LoadAssetAtPath(relPath, typeof(CaseList)) as CaseList;
            if (caseList)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }


    void AddCase() {
        Case newCase = new Case();
        newCase.caseName = "New Case";
        caseList.caseList.Add(newCase);
    }

    void DeleteCase() { 
        //Handled in popup CaseEditorWindow
    }
}
