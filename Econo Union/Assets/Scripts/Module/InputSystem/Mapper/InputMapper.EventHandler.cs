using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem.Mapper
{
    public partial class InputMapper
    {
        #region Delegates

        /// <summary>
        /// 이동을 제외한 커맨드 처리를 수행할 대리자
        /// </summary>
        public delegate void OnSendCommandInput(InputInfo inputInfo);

        /// <summary>
        /// Axis로부터 이동 커맨드 처리를 수행할 대리자
        /// </summary>
        public delegate void OnAxisInput(float x, float y);

        /// <summary>
        /// 특정 위치로의 이동 커맨드 처리를 수행할 대리자
        /// </summary>
        public delegate void OnMoveInput(Vector3 targetPos);

        #endregion

        #region Fields

        public OnSendCommandInput OnSendPressInput;
        public OnSendCommandInput OnSendHoldingInput;
        public OnSendCommandInput OnSendReleaseInput;
        public OnAxisInput OnSendAxisInput;
        public OnMoveInput OnSendMoveInput;

        #endregion

        #region Methods

        /// <summary>
        /// 입력 커맨드 핸들러를 초기화하는 메소드
        /// </summary>
        public void InitSendHandler()
        {
            OnSendPressInput = PressInputHandler;
            OnSendHoldingInput = HoldingInputHandler;
            OnSendReleaseInput = ReleaseInputHandler;
            OnSendAxisInput = AxisEventHandler;
            OnSendMoveInput = MoveEventHandler;
        }

        /// <summary>
        /// 최초 입력시 수행할 이벤트 핸들러
        /// </summary>
        /// <param name="inputInfo"></param>
        protected virtual void PressInputHandler(InputInfo inputInfo)
        {
    
        }

        /// <summary>
        /// 지속적으로 입력 중일 때 수행할 이벤트 핸들러
        /// </summary>
        /// <param name="inputInfo"></param>
        protected virtual void HoldingInputHandler(InputInfo inputInfo)
        {
 
        }

        /// <summary>
        /// 입력 종료 시 수행할 이벤트 핸들러
        /// </summary>
        /// <param name="inputInfo"></param>
        protected virtual void ReleaseInputHandler(InputInfo inputInfo)
        {
 
        }

        /// <summary>
        /// 중심선을 기준으로 특정방향으로 이동하는 이벤트 핸들러
        /// </summary>
        protected virtual void AxisEventHandler(float x, float y)
        {

        }

        /// <summary>
        /// 특정 위치로 이동하는 이벤트 핸들러
        /// </summary>
        /// <param name="targetPos"></param>
        protected virtual void MoveEventHandler(Vector3 targetPos)
        {

        }

        #endregion
    }
}
