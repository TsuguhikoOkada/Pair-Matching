using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(inspectedType:typeof(SetGameButton))]
[CanEditMultipleObjects]
[Serializable]
public class SetGameButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SetGameButton myScript = target as SetGameButton;

        switch (myScript._buttonType)
        {
            case SetGameButton.EButtonType.PairNumberBtn:
                myScript._pairNumber = (GameSettings.EPairNumber)EditorGUILayout.EnumPopup(label: "Pair Number", myScript._pairNumber);
                break;

            case SetGameButton.EButtonType.PuzzleCategoryBtn:
                myScript._puzzleCategories = 
                    (GameSettings.EPuzzleCategories)EditorGUILayout.EnumPopup(label: "Puzzle Categories", myScript._puzzleCategories);
                break;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
