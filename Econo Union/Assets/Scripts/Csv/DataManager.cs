using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Easy.Data
{
    /// <summary>
    /// CSV파일의 데이터들을 저장하여 관리하는 클래스
    /// </summary>
    public class DataManager<T> where T : IData, new()
    {
        private static DataManager<T> instance;

        Dictionary<int, T> table;

        public static DataManager<T> Instance
        {
            get
            {
                if (instance == null) instance = new DataManager<T>();
                return instance;
            }
        }

        DataManager()
        {
            table = LoadTable();
        }

        /// <summary>
        /// CSV 파일로부터 읽어온 데이터들을 T 타입을 Value로 하는 Dictionary에 저장하는 메소드
        /// </summary>
        private Dictionary<int, T> LoadTable()
        {
            Dictionary<int, T> result = new Dictionary<int, T>();
            Type dataType = typeof(T);
            PropertyInfo[] properties = dataType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            Dictionary<int, Dictionary<string, string>> parsedTable = IO.CsvStream.Read(typeof(T).Name);

            foreach(var data in parsedTable)
            {
                T newT = new T();
                int key = data.Key;
                var values = data.Value;

                // 모든 변수에 값을 저장한다.
                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo property = properties[i];
                    string propertyName = property.Name;
                    Type propertyType = property.PropertyType;
     
                    if (values.ContainsKey(propertyName))
                    {
                        string value = values[propertyName];
                        property.SetValue(newT, Convert.ChangeType(value, propertyType));
                    }
                }

                if(!result.ContainsKey(key))
                    result.Add(key, newT);
            }
            return result;
        }

        public T GetTableData(int key)
        {
            return table[key];
        }
    }
}
