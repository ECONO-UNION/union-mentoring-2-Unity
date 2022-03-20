using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Easy.InputSystem
{
    public class InputManager : MonoBehaviour
    {
        #region Fields

        private static InputManager instance;

        /// <summary>
        /// 입력 데이터 파일 경로
        /// </summary>
        private const string DataFilePath = "Data/InputData";

        private InputData inputData;

        /// <summary>
        /// CommandType과 PlayerType별로 키 입력 상태를 저장한 테이블
        /// </summary>
        private Dictionary<CommandType, Dictionary<PlayerType, List<KeyState>>> KeyTable = new Dictionary<CommandType, Dictionary<PlayerType, List<KeyState>>>();

        #endregion

        #region Properties

        public static InputManager Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<InputManager>();
                    if(instance == null)
                    {
                        instance = new GameObject(typeof(InputManager).Name).AddComponent<InputManager>();                     
                    }
                    return instance;
                }
                return instance;
            }
        }

        #endregion

        #region Callbacks

        void Awake()
        {
            inputData = Resources.Load<InputData>(DataFilePath);
            if(inputData == null)
            {
                Debug.LogError("Can't find InputData File");
            }

            DontDestroyOnLoad(gameObject);

            LoadTable();
        }

        void Update()
        {
            foreach(var playerTable in KeyTable)
            {
                foreach (var keyStateTable in playerTable.Value)
                {
                    foreach(var keyState in keyStateTable.Value)
                    {
                        keyState.GetKeyDown = Input.GetKeyDown(keyState.KeyCode);
                        keyState.GetKey = Input.GetKey(keyState.KeyCode);
                        keyState.GetKeyUp = Input.GetKeyUp(keyState.KeyCode);
                    }
                }
                
            }  
        }

        #endregion

        #region Methods

        private void LoadTable()
        {
            foreach(var key in inputData.Keys)
            {
                if (!KeyTable.ContainsKey(key.CommandType)) 
                    KeyTable.Add(key.CommandType, new Dictionary<PlayerType, List<KeyState>>());
                
                if (!KeyTable[key.CommandType].ContainsKey(key.PlayerType))
                    KeyTable[key.CommandType].Add(key.PlayerType, new List<KeyState>());
                
                KeyTable[key.CommandType][key.PlayerType].Add(new KeyState(key.KeyCode));
            }
        }

        public List<KeyState> GetTableData(CommandType commandType, PlayerType playerType = PlayerType.Player1)
        {
            if (!KeyTable.ContainsKey(commandType)) return null;
            if (!KeyTable[commandType].ContainsKey(playerType)) return null;

            return KeyTable[commandType][playerType];
        }

        #endregion
    }
    
}
