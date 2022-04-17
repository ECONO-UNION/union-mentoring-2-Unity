using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace Easy.Data
{
    /// <summary>
    /// IData의 자식 클래스를 생성하는 클래스.
    /// Editor에 의해 동작
    /// </summary>
    public class ClassCreator
    {
        /// <summary>
        /// 모든 CSV 파일들로부터 IData 클래스를 생성하는 메소드 
        /// </summary>
        public static void CreateAll()
        {
            List<string> nameList = IO.CsvStream.CsvNameList;

            foreach (var name in nameList)
            {
                CreateClass(name);
            }           
        }

        /// <summary>
        /// 특정 CSV 파일의 변수들을 작성한 클래스를 생성하는 메소드
        /// </summary>
        private static void CreateClass(string className)
        {
            string directoryPath = $"{Application.dataPath}/Scripts/Csv/Data/";
            string IDataPath = $"{directoryPath}IData.cs";
            string classPath = $"{directoryPath}{className}.cs";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                CreateIData(IDataPath);
            }

            StringBuilder classStringBuilder = CreateStringBuilder(className);
            File.WriteAllText(classPath, classStringBuilder.ToString());
        }

        private static StringBuilder CreateStringBuilder(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("// 본 스크립트는 Editor에 의해 자동으로 작성되었습니다.");
            stringBuilder.AppendLine("namespace Easy.Data");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"    public class {className} : IData");
            stringBuilder.AppendLine("    {");
    
            string[] lines = IO.CsvStream.ReadLines(className);
            string[] fieldnames = Regex.Split(lines[0], IO.CsvStream.SPLIT_RE);
            string[] fieldTypes = Regex.Split(lines[1], IO.CsvStream.SPLIT_RE);

            for (int i = 1; i < fieldnames.Length && i < fieldTypes.Length; i++)
            {
                stringBuilder.AppendLine($"        public {fieldTypes[i]} {fieldnames[i]} {{ get; private set; }}");
            }
            stringBuilder.AppendLine("    }");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("}");

            return stringBuilder;
        }

        private static void CreateIData(string path)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("// 본 스크립트는 Editor에 의해 자동으로 작성되었습니다.");
            stringBuilder.AppendLine("namespace Easy.Data");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine("    public interface IData");
            stringBuilder.AppendLine("    {");
            stringBuilder.AppendLine("    }");
            stringBuilder.AppendLine("}");

            File.WriteAllText(path, stringBuilder.ToString());
        }
    }
}
