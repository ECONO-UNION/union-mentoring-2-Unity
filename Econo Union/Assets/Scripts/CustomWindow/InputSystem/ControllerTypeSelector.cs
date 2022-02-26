using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class ControllerTypeSelector : EditorWindow
{
    static string[] options;
    private static int index;   

    [MenuItem("CustomWindow/Input System/Select Controller Type")]
    static void Init()
    {
        options = Enum.GetNames(typeof(InputManager.ControllerType));
        EditorWindow window = EditorWindow.GetWindow(typeof(ControllerTypeSelector));
        window.Show();
    }



    void OnGUI()
    {
        GUILayout.Label("Select Controller Type", EditorStyles.boldLabel);
        index = EditorGUILayout.Popup(selectedIndex: index, displayedOptions: options);

        if (GUILayout.Button("Select"))
        {
            PlayerPrefs.SetInt("ControllerType", index);
        }
    }
}
