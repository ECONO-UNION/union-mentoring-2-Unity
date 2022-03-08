using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

namespace Easy.Utils.Data
{
    public class Table<K, T>: Singleton<K> where K : Table<K, T>, new() where T : Table<K, T>.DataInstance, new()
    {
        #region Fields

        /// <summary>
        /// 데이터가 들어있는 딕셔너리
        /// </summary>
        protected Dictionary<int, T> table;

        protected static string fileName;

        const string KEY = "Key";

        #endregion

        #region Properties

        /// <summary>
        /// 특정 키에 해당하는 테이블 데이터를 반환
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetTableData(int key) => table[key];

        #endregion

        #region Classes

        /// <summary>
        /// 데이터에 속할 필드들을 포함하는 클래스
        /// </summary>
        public abstract class DataInstance
        {

        }

        #endregion

        #region Callbacks
        public override void OnInitiate()
        {
            if (table == null) table = LoadTable();
        }

        public override void OnCreate() 
        {
            
        }
       
        #endregion

        #region Methods

        private Dictionary<int, T> LoadTable()
        {
            Dictionary<int, T> result = new Dictionary<int, T>();
            Type DataInstance = typeof(T);

            // DataInstance T의 필드 배열
            FieldInfo[] fields = DataInstance.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            //CSV로부터 파싱한 데이터 테이블
            Dictionary<int, Dictionary<string, string>> parsedTable = TableLoader.Read(fileName);

            foreach(var collectionPair in parsedTable)
            {
                T dataInstance = new T();
                var tableKey = collectionPair.Key;
                var tableValue = collectionPair.Value;

                for (int i = 0; i < fields.Length; i++)
                {
                    FieldInfo fieldInfo = fields[i];
                    string fieldName = fieldInfo.Name;
                    Type fieldType = fieldInfo.FieldType;

                    if (fieldName == KEY)
                        fieldInfo.SetValue(dataInstance, tableKey);
                    else if (tableValue.ContainsKey(fieldName))
                    {
                        var value = tableValue[fieldName];
                        fieldInfo.SetValue(dataInstance, value.DecodeType(fieldType));
                    }
                }

                if (!result.ContainsKey(tableKey))
                    result.Add(tableKey, dataInstance);
            }
            return result;
        }

        #endregion

    }
}
