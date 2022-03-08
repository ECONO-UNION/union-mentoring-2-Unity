using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class MouseController : Controller
{
    #region Fields

    /// <summary>
    /// 마우스 데이터 파일 경로
    /// </summary>
    public const string MouseDataPath = "Data/MouseData";

    /// <summary>
    /// 마우스 정보 데이터 
    /// </summary>
    private MouseData mouseData;

    /// <summary>
    /// 현재 입력 중인 마우스 상태를 알려주는 변수
    /// </summary>
    int CurrentMouseState;

    public Vector2 Pos { get; private set; }
    public float MouseX { get; private set; }
    public float MouseY { get; private set; }

    #endregion

    #region Constructors

    public MouseController()
    {
        mouseData = Resources.Load<MouseData>(MouseDataPath);

        if (mouseData == null)
        {
            Debug.LogError("Can't load MouseData file");
            return;
        }

        foreach (var mouseInfo in mouseData.MouseInfos)
        {
            if (mouseInfo.CommandType == InputManager.CommandType.Move)
                MoveInputInfos.Add(mouseInfo);
            else
                NonMoveInputInfos.Add(mouseInfo);
        }
    }

    #endregion

    #region Callbacks

    public override void Update()
    {
        if(isRunning)
            OnCheckNonMoveInput();
    }

    public override void FixedUpdate()
    {
        if (isRunning)
            OnCheckMoveInput();
    }

    protected override void OnCheckMoveInput()
    {
        foreach (var inputInfo in MoveInputInfos)
        {
            MouseInfo mouseInfo = (MouseInfo)inputInfo;
            var mouseCode = mouseInfo.Code;

            if (Input.GetMouseButtonUp(mouseCode))
            {
                OnPressInput(mouseInfo);
            }
            else if (Input.GetMouseButton(mouseCode) && mouseInfo.CanHolding)
            {
                OnKeepInput(mouseInfo);
            }
            else if (Input.GetMouseButtonUp(mouseCode))
            {
                OnReleaseInput(mouseInfo);
            }
        }
    }

    protected override void OnCheckNonMoveInput()
    {
        foreach (var inputInfo in NonMoveInputInfos)
        {
            MouseInfo mouseInfo = (MouseInfo)inputInfo;
            var mouseCode = mouseInfo.Code;

            if (Input.GetMouseButtonUp(mouseCode))
            {
                OnKeepInput(mouseInfo);
            }
            else if (Input.GetMouseButton(mouseCode) && mouseInfo.CanHolding)
            {
                OnKeepInput(mouseInfo);
            }
            else if (Input.GetMouseButtonUp(mouseCode))
            {
                OnReleaseInput(mouseInfo);
            }
        }
    }

    #endregion
}
