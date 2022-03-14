using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class JoystickController : Controller
    {

        #region Fields

        /// <summary>
        /// 조이스틱 버튼 정보 데이터 
        /// </summary>
        private JoystickData joystickData;

        /// <summary>
        /// 데이터 파일 경로
        /// </summary>
        public const string DataFilePath = "Data/JoystickData";

        /// <summary>
        /// 조이스틱의 이름
        /// </summary>
        private string name;

        /// <summary>
        /// 조이스틱의 번호
        /// </summary>
        private int index;

        #endregion

        #region Constructors

        public JoystickController(string name, int index) : base()
        {
            this.name = name;
            this.index = index;

            joystickData = Resources.Load<JoystickData>(DataFilePath);

            if (joystickData == null)
            {
                Debug.LogError("Can't load JoystickData file");
                return;
            }

            foreach (var joystickInfo in joystickData.JoystickInfos)
            {
                KeyCode keyCode = GetJoystickKeyCode(joystickInfo.ButtonType);
                if (KeyTable.ContainsKey(keyCode))
                    Debug.LogError("Joystick KeyCode [" + keyCode + "] : is duplicated");
                KeyTable.Add(keyCode, joystickInfo);
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
                JoystickInfo inputInfo = (JoystickInfo)keyValuePair.Value;

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

                // 조이스틱 버튼에 상하좌우 중 하나라도 할당되지 않으면
                // 조이스틱의 스틱으로 이동한다.
                if (IsAxisTableEmpty)
                {
                    float x = Input.GetAxis(horizontal);
                    float y = Input.GetAxis(vertical);
                    OnSendAxisInput(x, y);
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

        #region Methods

        /// <summary>
        /// 조이스틱의 버튼을 KeyCode로 반환하는 메소드
        /// </summary>
        private KeyCode GetJoystickKeyCode(JoystickButtonType joystickButtonType)
        {
            string result = "JoystickButton";
            int button = (int)joystickButtonType;
            if (index != 0)
                result += index;
            result += button;

            KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), result);
            return keyCode;
        }

        protected override void BindAxis()
        {
            if (AxisTable.ContainsKey(horizontal) || AxisTable.ContainsKey(vertical))
                AxisTable.Clear();

            AxisTable.Add(horizontal, new AxisInput());
            AxisTable.Add(vertical, new AxisInput());

            foreach (var keyValuePair in KeyTable)
            {
                JoystickInfo inputInfo = (JoystickInfo)keyValuePair.Value;

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
