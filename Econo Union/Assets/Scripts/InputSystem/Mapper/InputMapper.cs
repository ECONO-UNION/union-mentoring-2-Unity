using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 입력 처리가 실제로 이루어지는 객체를 연결해주는 클래스
/// </summary>
public class InputMapper
{
    #region Delegates

    public delegate void OnSendCommandInput(InputInfo inputInfo);
    public delegate void OnMoveInput(InputInfo inputInfo, float x, float y);

    #endregion

    #region Properties / Delegate

    public OnSendCommandInput OnSendPressInput { get; private set; }
    public OnSendCommandInput OnSendHoldingInput { get; private set; }
    public OnSendCommandInput OnSendReleaseInput { get; private set; }
    public OnMoveInput OnMoveEventInput { get; private set; }

    #endregion

    #region Methods

    protected void InitSendInput()
    {
        OnSendPressInput = PressInputHandler;
        OnSendHoldingInput = HoldingInputHandler;
        OnSendReleaseInput = ReleaseInputHandler;
        OnMoveEventInput = MoveEventHandler;
    }

    protected virtual void PressInputHandler(InputInfo inputInfo)
    {

    }

    protected virtual void HoldingInputHandler(InputInfo inputInfo)
    {

    }

    protected virtual void ReleaseInputHandler(InputInfo inputInfo)
    {

    }

    protected virtual void MoveEventHandler(InputInfo inputInfo, float x, float y)
    {

    }

    #endregion
}
