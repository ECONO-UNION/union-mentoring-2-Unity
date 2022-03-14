using Easy.InputSystem.Mapper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    /// <summary>
    /// 입력 데이터의 모든 키/버튼의 입력 상태를 확인하여 InputMapper로 이벤트를 전달하는 클래스
    /// </summary>
    public abstract class Controller
    {
        
        #region Fields

        protected const string horizontal = "Horizontal";
        protected const string vertical = "Vertical";

        /// <summary>
        /// 수평과 수직축 정보를 가진 딕셔너리
        /// </summary>
        protected Dictionary<string, AxisInput> AxisTable = new Dictionary<string, AxisInput>();

        /// <summary>
        /// 각 키코드에 할당된 입력 데이터 테이블.
        /// 키보드와 조이스틱에서 사용
        /// </summary>
        protected Dictionary<KeyCode,InputInfo> KeyTable = new Dictionary<KeyCode, InputInfo>();

        /// <summary>
        /// 각 버튼에 할당된 입력 데이터 테이블.
        /// 마우스에서 사용
        /// </summary>
        protected Dictionary<int, InputInfo> ButtonTable = new Dictionary<int, InputInfo>();

        /// <summary>
        /// AxisTable에 키가 하나라도 할당되지 않았으면 true, 할당되어 있으면 false를 반환
        /// </summary>
        protected bool IsAxisTableEmpty => AxisTable[horizontal].IsEmpty || AxisTable[vertical].IsEmpty;

        #endregion

        #region Fields / Delegates

        protected InputMapper.OnSendCommandInput OnSendPressInput;
        protected InputMapper.OnSendCommandInput OnSendHoldingInput;
        protected InputMapper.OnSendCommandInput OnSendReleaseInput;
        protected InputMapper.OnAxisInput OnSendAxisInput;
        protected InputMapper.OnMoveInput OnSendMoveInput;

        #endregion

        #region Constructors

        public Controller()
        {
            InitSendInput();
        }

        #endregion

        #region Callbacks

        /// <summary>
        /// 매 프레임 마다 실행되는 메소드.
        /// </summary>
        public virtual void Update()
        {
            OnCheckInput();
        }

        /// 각 커맨드로부터 입력 상태 확인 메소드를 구분하는 메소드
        /// </summary>
        protected abstract void OnCheckInput();

        /// <summary>
        /// Axis 커맨드의 입력 상태를 확인하는 메소드
        /// </summary>
        protected abstract void OnCheckAxisInput();

        /// <summary>
        /// Move 커맨드의 입력 상태를 확인하는 메소드
        /// </summary>
        protected abstract void OnCheckMoveInput(InputInfo inputInfo);

        /// <summary>
        /// 이동을 제외한 커맨드들의 입력 상태를 확인하는 메소드
        /// </summary>
        protected abstract void OnCheckNonAxisInput(InputInfo inputInfo);

        #endregion

        #region Methods

        /// <summary>
        /// <summary>
        /// Controller의 입력 커맨드 핸들러를 InputMapper의 입력 커맨드 핸들러로 초기화시키는 함수
        /// </summary>
        private void InitSendInput()
        {
            OnSendPressInput = InputMapper.Instance.OnSendPressInput;
            OnSendHoldingInput = InputMapper.Instance.OnSendHoldingInput;
            OnSendReleaseInput = InputMapper.Instance.OnSendReleaseInput;
            OnSendAxisInput = InputMapper.Instance.OnSendAxisInput;
            OnSendMoveInput = InputMapper.Instance.OnSendMoveInput;
        }

        /// <summary>
        /// Axis 이동에 해당하는 키/버튼을 AxisTable에 할당하는 메소드
        /// </summary>
        protected virtual void BindAxis() { }

        #endregion
    }

}
