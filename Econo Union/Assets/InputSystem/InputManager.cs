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
        private Dictionary<CommandType, Dictionary<PlayerType, List<KeyState>>> KeyCommandTable = new Dictionary<CommandType, Dictionary<PlayerType, List<KeyState>>>();
       
        /// <summary>
        /// 각 키에 할당된 키 입력 상태를 저장한 테이블. 하나의 키에 여러 커맨드가 등록되지 않도록 확인한다.
        /// </summary>
        private Dictionary<KeyCode, KeyState> KeyTable = new Dictionary<KeyCode, KeyState>();

        private MouseInput mouseInput;
        
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

        public MouseInput MouseInput => mouseInput;

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
            mouseInput = new MouseInput();
        }

        void Update()
        {
            foreach(var playerTable in KeyCommandTable)
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
            mouseInput.Update();
        }

        #endregion

        #region Methods

        private void LoadTable()
        {
            foreach(var key in inputData.Keys)
            {
                if (KeyTable.ContainsKey(key.KeyCode))
                {
                    Debug.LogError("[" + key.KeyCode + "] is duplicated");
                    return;
                }

                if (!KeyCommandTable.ContainsKey(key.CommandType)) 
                    KeyCommandTable.Add(key.CommandType, new Dictionary<PlayerType, List<KeyState>>());
                
                if (!KeyCommandTable[key.CommandType].ContainsKey(key.PlayerType))
                    KeyCommandTable[key.CommandType].Add(key.PlayerType, new List<KeyState>());

                KeyState keyState = new KeyState(key.KeyCode);
                KeyTable.Add(key.KeyCode, keyState);
                KeyCommandTable[key.CommandType][key.PlayerType].Add(keyState);
            }
        }

        public List<KeyState> GetTableData(CommandType commandType, PlayerType playerType)
        {
            if (!KeyCommandTable.ContainsKey(commandType)) return null;
            if (!KeyCommandTable[commandType].ContainsKey(playerType)) return null;

            return KeyCommandTable[commandType][playerType];
        }

        #endregion
    }
    
}
