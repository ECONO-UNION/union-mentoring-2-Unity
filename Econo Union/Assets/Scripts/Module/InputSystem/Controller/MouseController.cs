using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class MouseController : Controller
    {
        #region Fields

        /// <summary>
        /// 데이터 파일 경로
        /// </summary>
        public const string DataFilePath = "Data/MouseData";

        /// <summary>
        /// 마우스 버튼 정보 데이터 
        /// </summary>
        private MouseData mouseData;

        #endregion

        #region Constructors

        public MouseController() : base()
        {
            mouseData = Resources.Load<MouseData>(DataFilePath);

            if (mouseData == null)
            {
                Debug.LogError("Can't load MouseData file");
                return;
            }

            foreach (var mouseInfo in mouseData.MouseInfos)
            {
                ButtonTable.Add(mouseInfo.Button, mouseInfo);
            }

            BindAxis();
        }

        #endregion

        #region Callbacks

        protected override void OnCheckInput()
        {
            foreach (var keyValuePair in ButtonTable)
            {
                int button = keyValuePair.Key;
                MouseInfo inputInfo = (MouseInfo)keyValuePair.Value;

                inputInfo.IsPressed = Input.GetMouseButtonDown(button);
                inputInfo.IsHolding = Input.GetMouseButton(button);
                inputInfo.IsReleased = Input.GetMouseButtonUp(button);

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
                if(x != 0 || y != 0)
                    OnSendAxisInput(x, y);
            }
        }

        protected override void OnCheckMoveInput(InputInfo inputInfo)
        {
            if (inputInfo.IsPressed)
                OnSendMoveInput(Input.mousePosition);
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

        protected override void BindAxis()
        {
            if (AxisTable.ContainsKey(horizontal) || AxisTable.ContainsKey(vertical))
                AxisTable.Clear();

            AxisTable.Add(horizontal, new AxisInput());
            AxisTable.Add(vertical, new AxisInput());

            foreach (var keyValuePair in ButtonTable)
            {
                MouseInfo inputInfo = (MouseInfo)keyValuePair.Value;

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
