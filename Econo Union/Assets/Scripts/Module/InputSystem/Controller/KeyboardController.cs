using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class KeyboardController : Controller
    {
        #region Fields

        /// <summary>
        /// 키 정보 데이터 
        /// </summary>
        private KeyData keyData;

        /// <summary>
        /// 데이터 파일 경로
        /// </summary>
        public const string DataFilePath = "Data/KeyData";

        #endregion

        #region Constructors

        public KeyboardController() : base()
        {
            keyData = Resources.Load<KeyData>(DataFilePath);

            if (keyData == null)
            {
                Debug.LogError("Can't load KeyData file");
                return;
            }

            foreach (var keyInfo in keyData.KeyInfos)
            {
                if (KeyTable.ContainsKey(keyInfo.KeyCode))
                    Debug.LogError("KeyCode [" + keyInfo.KeyCode + "] : is duplicated");
                KeyTable.Add(keyInfo.KeyCode, keyInfo);
            }

            BindAxis();
        }

        #endregion

        #region Callbacks

        protected override void OnCheckInput()
        {
            foreach (var keyValuePair in KeyTable)
            {
                KeyCode keyCode = keyValuePair.Key;
                KeyInfo inputInfo = (KeyInfo)keyValuePair.Value;

                inputInfo.IsPressed = Input.GetKeyDown(keyCode);
                inputInfo.IsHolding = Input.GetKey(keyCode);
                inputInfo.IsReleased = Input.GetKeyUp(keyCode);

                switch (inputInfo.CommandType)
                {
                    case CommandType.None:
                        break;
                    case CommandType.Axis_Left:
                    case CommandType.Axis_Right:
                    case CommandType.Axis_Up:
                    case CommandType.Axis_Down:
                        OnCheckAxisInput();
                        break;
                    case CommandType.Move:
                        OnCheckMoveInput(inputInfo);
                        break;
                    default:
                        OnCheckNonAxisInput(inputInfo);
                        break;
                }
            }
        }

        protected override void OnCheckAxisInput()
        {
            if (!IsAxisTableEmpty)
            {
                float x = AxisTable[horizontal].GetAxis();
                float y = AxisTable[vertical].GetAxis();
                if (x != 0 || y != 0)
                    OnSendAxisInput(x, y);

            }
        }

        protected override void OnCheckMoveInput(InputInfo inputInfo)
        {
            
        }

        protected override void OnCheckNonAxisInput(InputInfo inputInfo)
        {
            if (inputInfo.IsPressed)
            {
                OnSendPressInput(inputInfo);
            }
            if (inputInfo.CanHolding && inputInfo.IsHolding)
            {
                OnSendHoldingInput(inputInfo);
            }
            if (inputInfo.IsReleased)
            {
                OnSendReleaseInput(inputInfo);
            }
        }

        #endregion

        #region

        protected override void BindAxis()
        {
            if (AxisTable.ContainsKey(horizontal) || AxisTable.ContainsKey(vertical))
                AxisTable.Clear();

            AxisTable.Add(horizontal, new AxisInput());
            AxisTable.Add(vertical, new AxisInput());

            foreach (var keyValuePair in KeyTable)
            {
                KeyInfo inputInfo = (KeyInfo)keyValuePair.Value;

                switch (inputInfo.CommandType)
                {
                    case CommandType.Axis_Left:
                        AxisTable[horizontal].SetNegative(inputInfo);
                        break;
                    case CommandType.Axis_Right:
                        AxisTable[horizontal].SetPositive(inputInfo);
                        break;
                    case CommandType.Axis_Up:
                        AxisTable[vertical].SetPositive(inputInfo);
                        break;
                    case CommandType.Axis_Down:
                        AxisTable[vertical].SetNegative(inputInfo);
                        break;
                }

            }
        }

        #endregion
    }

}