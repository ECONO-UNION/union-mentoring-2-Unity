using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Easy.Data.Editor
{
    public class CsvSystemEditor : EditorWindow
    {
        [MenuItem("Custom Window/Data/CSV Setting")]
        static void ShowWindow()
        {
            CsvSystemEditor window = (CsvSystemEditor)GetWindow(typeof(CsvSystemEditor));
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Data Script Creator\n", EditorStyles.boldLabel);
            GUILayout.Label("모든 CSV파일에 해당하는 스크립트를 생성 후 클래스를 작성합니다.");

            if (GUILayout.Button("Create"))
            {
                ClassCreator.CreateAll();
                AssetDatabase.Refresh();
            }
        }

    }

}