using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PE_PathManager))]

public class PE_PathManagerEditor : Editor
{
    PE_PathManager eTarget;

    private bool horizontalToggled = false;

    private void OnEnable()
    {
        eTarget = (PE_PathManager)target;
        eTarget.name = "[PATH MANAGER]";
        Tools.current = Tool.None;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AddSpace();
        EditorGUILayout.HelpBox("Path manager", MessageType.None);
        AddSpace();

        AllPathUi();

        AddSpace();
        ManagerUi();

        SceneView.RepaintAll();
    }

    void ManagerUi()
    {
        AddSpace(5);
        GUI.color = Color.green;
        if (GUILayout.Button("Add path"))
            eTarget.AddPath();
        GUI.color = Color.red;
        if (GUILayout.Button("Remove all paths"))
        {
            bool _confirm = EditorUtility.DisplayDialog("Suppress all paths ?", "Are you sure ?", "Yes", "No");
            if (_confirm)
                eTarget.Clear();
        }
        GUI.color = Color.white;
    }

    void AllPathUi()
    {
        if (!eTarget) return;
        for (int i = 0; i < eTarget.NbPaths; i++)
        {
            PE_Path _p = eTarget.AllPaths[i];
            
            _p.ShowPaths = EditorGUILayout.Foldout(_p.ShowPaths, $"Show/Hide path");

            if (_p.ShowPaths)
            {
                ToggleHorizontal(true);
                EditorGUILayout.LabelField($"{i + 1} : { _p.Id} -> {_p.PathPoints.Count} waypoints");

                GUI.color = Color.green;
                if (GUILayout.Button("+"))
                {
                    _p.AddPoint();

                }
                GUI.color = Color.white;

                GUI.color = Color.red;
                if (GUILayout.Button("Remove path"))
                {
                    bool _confirm = EditorUtility.DisplayDialog($"Suppress path {i + 1} ?", "Are you sure ?", "Yes", "No");
                    if (_confirm)
                        eTarget.RemovePath(i);
                }
                GUI.color = Color.white;

                ToggleHorizontal(false);
                _p.Id = EditorGUILayout.TextField(_p.Id);
                ShowPathPointsUi(_p);
            }
            
        }
    }

    void ShowPathPointsUi(PE_Path _path)
    {
        _path.ShowPoints = EditorGUILayout.Foldout(_path.ShowPoints, $"Show/Hide points");
        for (int i = 0; i < _path.NbPoints; i++)
        {
            if (_path.ShowPoints)
            {
                ToggleHorizontal(true);
                Vector3 _v = _path.PathPoints[i];
                _path.PathPoints[i] = EditorGUILayout.Vector3Field($"Path point {i + 1} :", _v);
                GUI.color = Color.red;
                if (GUILayout.Button("X"))
                {
                    bool _confirm = EditorUtility.DisplayDialog($"{i + 1} at {_v} ?", "Are you sure ?", "Yes", "No");
                    if (_confirm)
                        _path.RemovePoint(i);
                }
                GUI.color = Color.white;
                ToggleHorizontal(false);
            }
    
        }
        _path.pathColor = EditorGUILayout.ColorField(_path.pathColor);

        AddSpace();

        GUI.color = _path.IsEdit ? Color.green : Color.grey;
        if (GUILayout.Button("Edit path"))
        {
            SetActiveEdition(_path);
        }
        GUI.color = Color.white;

        AddSpace();
        GUI.color = Color.red;
        if (GUILayout.Button("Remove all points"))
        {
            bool _confirm = EditorUtility.DisplayDialog("Suppress all points ?", "Are you sure ?", "Yes", "No");
            if (_confirm)
                _path.Clear();
        }
        GUI.color = Color.white;
    }

    void AddSpace(uint _nbspace = 1)
    {
        for (int i = 0; i < _nbspace; i++)
        {
            EditorGUILayout.Space();
        }
    }

    void ToggleHorizontal(bool _open)
    {
        if (_open)
            EditorGUILayout.BeginHorizontal();
        else
            EditorGUILayout.EndHorizontal();
    }

    private void OnSceneGUI()
    {
        ShowAllPathsUI();
    }

    void ShowAllPathsUI()
    {
        for (int i = 0; i<eTarget.NbPaths; i++)
		{
            PE_Path _p = eTarget.AllPaths[i];
            if (!_p.IsEdit)
            {
                continue;
            }
            Handles.color = _p.pathColor;
            for (int j = 0; j < _p.NbPoints; j++)
            {
                _p.PathPoints[j] = Handles.DoPositionHandle(_p.PathPoints[j], Quaternion.identity);

                Handles.Label(_p.PathPoints[j] + Vector3.up * 2, $"Point {j+1}");
                Handles.DrawDottedLine(_p.PathPoints[j] + Vector3.up*2, _p.PathPoints[j], 0.5f );
                Handles.DrawSolidDisc(_p.PathPoints[j], Vector3.up, 1);
                if (j < _p.NbPoints - 1)
                {
                    Handles.DrawLine(_p.PathPoints[j], _p.PathPoints[j+1]);
                }
            }
            Handles.color = Color.white;
        }
    }

    void SetActiveEdition(PE_Path _p)
    {
        for (int i = 0; i < eTarget.NbPaths; i++)
        {
            eTarget.AllPaths[i].IsEdit = false;
        }
        _p.IsEdit = true; 
    }
}