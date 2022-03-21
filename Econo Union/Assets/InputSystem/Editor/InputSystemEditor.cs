using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Easy.InputSystem
{
    public class InputSystemEditor : EditorWindow
    {
        static float windowWidth = 300;
        static float windowHeight = 800;

        List<string> playerTypeNameList = new List<string>();
        List<string> controllerTypeNameList = new List<string>();
        List<string> commandTypeNameList = new List<string>();

        string addPlayer = "";
        string removePlayer = "";
        string addController = "";
        string removeController = "";
        string addCommand = "";
        string removeCommand = "";

        void Awake()
        {
            InitList();
        }

        [MenuItem("CustomWindow/Input System Setting")]
        static void ShowWindow()
        {
            InputSystemEditor window = (InputSystemEditor)GetWindow(typeof(InputSystemEditor));
            window.position = new Rect(0, 0, windowWidth, windowHeight);
            window.Show();
        }

        void InitList()
        {
            string[] playerTypeNames = System.Enum.GetNames(typeof(PlayerType));
            string[] controllerTypeNames = System.Enum.GetNames(typeof(ControllerType));
            string[] commandTypeNames = System.Enum.GetNames(typeof(CommandType));

            for (int i = 0; i < playerTypeNames.Length; i++)
            {
                playerTypeNameList.Add(playerTypeNames[i]);
            }
            for (int i = 0; i < controllerTypeNames.Length; i++)
            {
                controllerTypeNameList.Add(controllerTypeNames[i]);
            }
            for (int i = 0; i < commandTypeNames.Length; i++)
            {
                commandTypeNameList.Add(commandTypeNames[i]);
            }
        }

        void OnGUI()
        {         
            GUILayout.Label("Input System Settings", EditorStyles.boldLabel);
            // PlayerType 관리 구역
            {
                GUILayout.Label("\nPlayerType List", EditorStyles.boldLabel);
                GUILayout.Label("----------");
                ShowPlayerTypeList();
                GUILayout.Label("----------");
                // PlayerType 추가/삭제 기능
                addPlayer = EditorGUILayout.TextField("Add PlayerType: ", addPlayer);
                if (GUILayout.Button("Add"))
                {
                    if (!addPlayer.Equals(""))
                        playerTypeNameList.Add(addPlayer);
                    addPlayer = "";
                }
                removePlayer = EditorGUILayout.TextField("Remove PlayerType: ", removePlayer);
                if (GUILayout.Button("Remove"))
                {
                    if (playerTypeNameList.Contains(removePlayer))
                        playerTypeNameList.Remove(removePlayer);
                    removePlayer = "";
                }
            }
            // ControllerType 관리 구역
            {
                GUILayout.Label("\nControllerType List", EditorStyles.boldLabel);
                GUILayout.Label("----------");
                ShowControllerTypeList();
                GUILayout.Label("----------");
                // ControllerType 추가/삭제 기능
                addController = EditorGUILayout.TextField("Add ControllerType: ", addController);
                if (GUILayout.Button("Add"))
                {
                    if (!addController.Equals(""))
                        controllerTypeNameList.Add(addController);
                    addController = "";
                }
                removeController = EditorGUILayout.TextField("Remove ControllerType: ", removeController);
                if (GUILayout.Button("Remove"))
                {
                    if (controllerTypeNameList.Contains(removeController))
                        controllerTypeNameList.Remove(removeController);
                    removeController = "";
                }
            }
            // CommandType 관리 구역
            {
                GUILayout.Label("\nCommandType List", EditorStyles.boldLabel);
                GUILayout.Label("----------");
                ShowCommandTypeList();
                GUILayout.Label("----------");
                // CommandType 추가/삭제 기능
                addCommand = EditorGUILayout.TextField("Add ControllerType: ", addCommand);
                if (GUILayout.Button("Add"))
                {
                    if (!addCommand.Equals(""))
                        commandTypeNameList.Add(addCommand);
                    addCommand = "";
                }
                removeCommand = EditorGUILayout.TextField("Remove ControllerType: ", removeCommand);
                if (GUILayout.Button("Remove"))
                {
                    if (commandTypeNameList.Contains(removeCommand))
                        commandTypeNameList.Remove(removeCommand);
                    removeCommand = "";
                }
            }
            GUILayout.Label("\n");
 
            if (GUILayout.Button("Apply"))
            {
                // Enum을 포함하는 스크립트 생성
                CreateEnums();
            }
            
        }
        void ShowPlayerTypeList()
        {
            for (int i = 0; i < playerTypeNameList.Count; i++)
            {
                GUILayout.Label(playerTypeNameList[i]);
            }
        }
        void ShowControllerTypeList()
        {
            for (int i = 0; i < controllerTypeNameList.Count; i++)
            {
                GUILayout.Label(controllerTypeNameList[i]);
            }
        }
        void ShowCommandTypeList()
        {
            for (int i = 0; i < commandTypeNameList.Count; i++)
            {
                GUILayout.Label(commandTypeNameList[i]);
            }
        }
        void CreateEnums()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace Easy.InputSystem");
            sb.AppendLine("{");
            sb.AppendLine("    public enum PlayerType");
            sb.AppendLine("    {");
            for (int i = 0; i < playerTypeNameList.Count; i++)
            {
                sb.AppendLine("        " + playerTypeNameList[i] + ",");
            }
            sb.AppendLine("    }");
            sb.AppendLine("    public enum ControllerType");
            sb.AppendLine("    {");
            for (int i = 0; i < controllerTypeNameList.Count; i++)
            {
                sb.AppendLine("        " + controllerTypeNameList[i] + ",");
            }
            sb.AppendLine("    }");
            sb.AppendLine("    public enum CommandType");
            sb.AppendLine("    {");
            for (int i = 0; i < commandTypeNameList.Count; i++)
            {
                sb.AppendLine("        " + commandTypeNameList[i] + ",");
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");

            string path = Application.dataPath + "/InputSystem/SystemTool.cs";
            File.WriteAllText(path, sb.ToString());
        }

    }

}