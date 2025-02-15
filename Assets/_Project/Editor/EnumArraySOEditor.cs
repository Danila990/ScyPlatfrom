using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;
using static MyCode.LevelSetting;

namespace MyCode 
{
    [CustomEditor(typeof(LevelSetting))]
    public class EnumArraySOEditor : Editor
    {
        private LevelSetting _gridSetting;

        public override void OnInspectorGUI()
        {
            _gridSetting = (LevelSetting)target;
            base.OnInspectorGUI();
            LabelFieldText();

            InitGrid();
            CustomArray();
            EditorGUILayout.Space(5);
            LabelFieldTextSizeGrid();

            EditorGUILayout.Space(5);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            AddLineButton();
            RemoveLineButton();
            EditorGUILayout.EndVertical();
            EditorGUILayout.BeginVertical();
            AddRowButton();
            RemoveRowButton();
            EditorGUILayout.EndHorizontal();
            ResetButton();
            EditorGUILayout.EndHorizontal();

            if (GUI.changed)
                EditorUtility.SetDirty(target);
        }

        private void CustomArray()
        {
            for (int i = 0; i < _gridSetting.GridLinesArray.Length; i++)
            {
                EditorGUILayout.Space(5);
                EditorGUILayout.BeginHorizontal();
                if (_gridSetting.GridLinesArray[i] != null)
                {
                    for (int j = 0; j < _gridSetting.GridLinesArray[i].Line.Length; j++)
                    {
                        Color enumColor = GetPlatfromColor(_gridSetting.GridLinesArray[i].Line[j]);
                        Rect rect = GUILayoutUtility.GetRect(20, 20); 
                        EditorGUI.DrawRect(rect, enumColor);
                        GUI.color = Color.white;

                        _gridSetting.GridLinesArray[i].Line[j] = (PlatformType)EditorGUILayout.EnumPopup(_gridSetting.GridLinesArray[i].Line[j]);
                        GUI.color = Color.white;
                    }
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        private Color GetPlatfromColor(PlatformType platformType)
        {
            Color color;
            switch (platformType)
            {
                case PlatformType.Default:
                    color = Color.white;
                    break;

                case PlatformType.Player:
                    color = Color.green;
                    break;

                case PlatformType.Empty:
                    color = Color.black;
                    break;

                default:
                    color = Color.white;
                    break;
            }

            return color;
        }

        private void LabelFieldTextSizeGrid()
        {
            Vector2Int sizeGrid = new Vector2Int(_gridSetting.GridLinesArray.Length, _gridSetting.GridLinesArray[0].Line.Length);
            EditorGUILayout.LabelField($"Size Grid: X - {sizeGrid.x}, Y - {sizeGrid.y}");
        }

        private void AddLineButton()
        {
            if (GUILayout.Button("Add Line"))
            {
                GridLine[] newGridLines = new GridLine[_gridSetting.GridLinesArray.Length + 1];
                _gridSetting.GridLinesArray.CopyTo(newGridLines, 0);
                newGridLines[_gridSetting.GridLinesArray.Length] = new GridLine() { Line = new PlatformType[_gridSetting.GridLinesArray[0].Line.Length] };
                _gridSetting.GridLinesArray = newGridLines;
            }
        }

        private void RemoveLineButton()
        {
            if (GUILayout.Button("Remove Line"))
            {
                if (_gridSetting.GridLinesArray.Length <= 1)
                    return;

                GridLine[] newGridLines = new GridLine[_gridSetting.GridLinesArray.Length - 1];
                Array.Copy(_gridSetting.GridLinesArray, newGridLines, newGridLines.Length);
                _gridSetting.GridLinesArray = newGridLines;
            }
        }

        private void RemoveRowButton()
        {
            if (GUILayout.Button("Remove Row"))
            {
                if(_gridSetting.GridLinesArray[0].Line.Length <= 1)
                    return;

                for (int i = 0; i < _gridSetting.GridLinesArray.Length; i++)
                {
                    PlatformType[] newRow = new PlatformType[_gridSetting.GridLinesArray[i].Line.Length -1];
                    Array.Copy(_gridSetting.GridLinesArray[i].Line, newRow, newRow.Length);
                    _gridSetting.GridLinesArray[i].Line = newRow;
                }
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