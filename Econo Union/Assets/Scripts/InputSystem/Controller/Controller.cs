using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller
{
    #region Fields

    protected bool isRunning;

    #endregion

    #region Properties

    public bool IsRunning { get { return isRunning; } }

    #endregion

    #region Callbacks

    /// <summary>
    /// 특정 키를 최초 입력시 실행되는 메소드
    /// </summary>
    protected abstract void OnPressInput(InputInfo inputInfo);

    /// <summary>
    /// 특정 키를 입력하는 동안 실행되는 메소드
    /// </summary>
    protected abstract void OnKeepInput(InputInfo inputInfo);

    /// <summary>
    /// 특정 키를 떼는 순간 실행되는 메소드
    /// </summary>
    protected abstract void OnReleaseInput(InputInfo inputInfo);

    /// <summary>
    /// 매 프레임 마다 실행되는 메소드.
    /// </summary>
    public abstract void Update();

    /// <summary>
    /// 입력 데이터의 각 입력 정보의 입력 상태를 확인하는 메소드
    /// </summary>
    public abstract void OnCheckInput();
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

    #endregion
}
