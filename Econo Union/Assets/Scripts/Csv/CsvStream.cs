using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace Easy.Data.IO
{
    /// <summary>
    /// CSV 파일 입출력 클래스
    /// </summary>
    public class CsvStream
    {
        public const string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        public const string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";

        private static List<string> csvNameList;

        public static List<string> CsvNameList
        {
            get
            {
                if (csvNameList == null) csvNameList = FindCsvNameList();
                return csvNameList;
            }
        }

        /// <summary>
        /// 모든 CSV 파일들의 이름을 찾는 메소드
        /// </summary>
        /// <returns></returns>
        public static List<string> FindCsvNameList()
        {
            const string CsvDirectoryPath = "Assets/Resources/Data/";

            List<string> nameList = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(CsvDirectoryPath);
            FileInfo[] fileInfos = directoryInfo.GetFiles();

            foreach (var fileInfo in fileInfos)
            {
                string name = fileInfo.Name;
                if (name.EndsWith(".csv"))
                {
                    name = name.Replace(".csv", "");
                    nameList.Add(name);
                }
            }

            return nameList;
        }

        /// <summary>
        /// 특정 CSV 파일을 모든 줄을 읽는 메소드
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string[] ReadLines(string FileName)
        {
            string path = "Data/" + FileName;
            TextAsset textAsset = Resources.Load(path) as TextAsset;
            if (textAsset == null)
            {
                Debug.LogError("Can't find file : " + path);
                return new string[0];
            }
            string[] lines = Regex.Split(textAsset.text, LINE_SPLIT_RE);
            return lines;
        }

        /// <summary>
        /// 특정 CSV 파일을 읽어 데이터들을 Dictionary에 저장하는 메소드
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static Dictionary<int, Dictionary<string, string>> Read(string FileName)
        {
            Dictionary<int, Dictionary<string, string>> result = new Dictionary<int, Dictionary<string, string>>();
            string path = "Data/" + FileName;
            TextAsset textAsset = Resources.Load(path) as TextAsset;
            if (textAsset == null)
            {
                Debug.LogError("Can't find file : " + path);
            }

            string[] lines = Regex.Split(textAsset.text, LINE_SPLIT_RE);
            string[] fieldNames = Regex.Split(lines[0], SPLIT_RE);

            for (int i = 2; i < lines.Length; i++)
            {
                string[] values = Regex.Split(lines[i], SPLIT_RE);

                int key;
                if (!int.TryParse(values[0], out key)) break;
                result.Add(key, new Dictionary<string, string>());

                for (int j = 1; j < values.Length; j++)
                {
                    result[key].Add(fieldNames[j], values[j]);
                }
                
            }

            return result;
        }
    }
}