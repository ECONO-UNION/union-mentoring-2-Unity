using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Easy.Utils.Data
{
    public class TableLoader : MonoBehaviour
    {
        /// <summary>
        /// Resources에 포함된 Data 디렉토리
        /// </summary>
        private const string DataPath = "Data/";
        static char[] Line_Delimiter = { '\n', '\r' };
        static char[] Delimiter = { ',' };

        public static Dictionary<int, Dictionary<string, string>> Read(string FileName)
        {
            FileName = DataPath + FileName;
            TextAsset textAsset = Resources.Load<TextAsset>(FileName);
            if (textAsset == null)
            {
                Debug.LogError("File doesn't exist. " + FileName);
                return null;
            }
            Dictionary<int, Dictionary<string, string>> table = new Dictionary<int, Dictionary<string, string>>();
            string[] lines = textAsset.text.Split(Line_Delimiter);
            string[] header = lines[0].Split(Delimiter);
            if (lines.Length <= 1) return table;

            // CSV 파일의 모든 라인을 확인한다.
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(Delimiter);

                if (values.Length == 0 || values[0] == "") continue;
                // 해당 라인의 내용을 기록하기 위한 딕셔너리
                Dictionary<string, string> content = new Dictionary<string, string>();
                int key = int.Parse(values[0]);

                for (int j = 0; j < values.Length; j++)
                {
                    content[header[j]] = values[j];
                    if (!table.ContainsKey(key))
                        table.Add(key, content);
                }
            }
            return table;
        }

    }

}