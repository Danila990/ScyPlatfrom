using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using static MyCode.PlatfromGridSetting;

namespace MyCode 
{
    [CustomEditor(typeof(PlatfromGridSetting))]
    public class EnumArraySOEditor : Editor
    {
        private PlatfromGridSetting _gridSetting;

        public override void OnInspectorGUI()
        {
            _gridSetting = (PlatfromGridSetting)target;
            base.OnInspectorGUI();
            LabelFieldText();
            InitGrid();
            CastomArray();

            EditorGUILayout.BeginHorizontal();
            AddLineButton();
            AddRowButton();
            ResetButton();
            EditorGUILayout.EndHorizontal();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }

        private void CastomArray()
        {
            for (int i = 0; i < _gridSetting.GridLinesArray.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                if (_gridSetting.GridLinesArray[i] != null)
                {
                    for (int j = 0; j < _gridSetting.GridLinesArray[i].Line.Length; j++)
                    {
                        GUI.color = Color.red;
                        _gridSetting.GridLinesArray[i].Line[j] = (PlatformType)EditorGUILayout.EnumPopup(_gridSetting.GridLinesArray[i].Line[j]);
                        GUI.color = Color.white;
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        private void AddLineButton()
        {
            if (GUILayout.Button("Add Line"))
            {
                GridLine[] newGridLine = new GridLine[_gridSetting.GridLinesArray.Length + 1];
                _gridSetting.GridLinesArray.CopyTo(newGridLine, 0);
                newGridLine[_gridSetting.GridLinesArray.Length] = new GridLine() { Line = new PlatformType[_gridSetting.GridLinesArray[0].Line.Length] };
                _gridSetting.GridLinesArray = newGridLine;
            }
        }

        private void AddRowButton()
        {
            if (GUILayout.Button("Add Row"))
            {
                for (int i = 0; i < _gridSetting.GridLinesArray.Length; i++)
                {
                    PlatformType[] newRow = new PlatformType[_gridSetting.GridLinesArray[i].Line.Length + 1];
                    _gridSetting.GridLinesArray[i].Line.CopyTo(newRow, 0);
                    _gridSetting.GridLinesArray[i].Line = newRow;
                }
            }
        }

        private void ResetButton()
        {
            if (GUILayout.Button("Reset"))
            {
                _gridSetting.GridLinesArray = new GridLine[1] { new GridLine() { Line = new PlatformType[1] { PlatformType.Default } } };
            }
        }

        private void LabelFieldText()
        {
            EditorGUILayout.Space(10);
            GUIStyle centeredStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                alignment = TextAnchor.MiddleCenter

            };

            EditorGUILayout.LabelField("Platfroms Grid", centeredStyle);
        }

        private void InitGrid()
        {
            if (_gridSetting.GridLinesArray == null ||  _gridSetting.GridLinesArray.Length == 0)
            {
                _gridSetting.GridLinesArray = new GridLine[1]
                {
                    new GridLine()
                    {
                        Line = new PlatformType[1]{ PlatformType.Default }
                    }
                };
            }
        }
    }
}