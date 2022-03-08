using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller
{
    #region Fields

    protected bool isRunning;

    /// <summary>
    /// 이동 커맨드 정보 리스트
    /// </summary>
    protected List<InputInfo> MoveInputInfos = new List<InputInfo>();

    /// <summary>
    /// 이동 커맨드를 제외한 정보 리스트
    /// </summary>
    protected List<InputInfo> NonMoveInputInfos = new List<InputInfo>();

    #endregion

    #region Properties

    public bool IsRunning { get { return isRunning; } }

    #endregion

    #region Delegates

    #endregion

    #region Callbacks

    /// <summary>
    /// 특정 키를 최초 입력시 실행되는 메소드
    /// </summary>
    protected virtual void OnPressInput(InputInfo inputInfo)
    {
        InputMapper mapper = InputManager.SelectMapper(inputInfo.CommandType);
        mapper.OnSendPressInput(inputInfo);
    }

    /// <summary>
    /// 특정 키를 입력하는 동안 실행되는 메소드
    /// </summary>
    protected virtual void OnKeepInput(InputInfo inputInfo)
    {
        InputMapper mapper = InputManager.SelectMapper(inputInfo.CommandType);
        mapper.OnSendHoldingInput(inputInfo);
    }

    /// <summary>
    /// 특정 키를 떼는 순간 실행되는 메소드
    /// </summary>
    protected virtual void OnReleaseInput(InputInfo inputInfo)
    {
        InputMapper mapper = InputManager.SelectMapper(inputInfo.CommandType);
        mapper.OnSendReleaseInput(inputInfo);
    }

    protected virtual void OnMoveInput(InputInfo inputInfo, float x, float y)
    {
        InputMapper mapper = InputManager.SelectMapper(inputInfo.CommandType);
        mapper.OnMoveEventInput(inputInfo, x, y);
    }

    /// <summary>
    /// 매 프레임 마다 실행되는 메소드.
    /// </summary>
    public abstract void Update();
    public abstract void FixedUpdate();

    #endregion

    #region Methods

    /// <summary>
    /// 컨트롤러 입력을 시작하는 메소드
    /// </summary>
    public virtual void StartController()
    {
        isRunning = true;
    }

    /// <summary>
    /// 컨트롤러 입력을 중지하는 메소드
    /// </summary>
    public virtual void StopController()
    {
        isRunning = false;
    }

    /// <summary>
    /// 이동 커맨드 입력 데이터의 각 입력 정보의 입력 상태를 확인하는 메소드
    /// </summary>
    protected abstract void OnCheckMoveInput();

    /// <summary>
    /// 이동 커맨드가 아닌 입력 데이터의 각 입력 정보의 입력 상태를 확인하는 메소드
    /// </summary>
    protected abstract void OnCheckNonMoveInput();

    #endregion
}
