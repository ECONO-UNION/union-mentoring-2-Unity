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
    }

    #endregion

    #region Callbacks

    public override void Update()
    {
        OnCheckInput();
    }

    public override void OnCheckInput()
    {
        foreach (var mouseInfo in mouseData.MouseInfos)
        {
            var mouseCode = mouseInfo.Code;
            var mouseBit = mouseInfo.Index;

            if (Input.GetMouseButtonUp(mouseCode))
            {
                OnKeepInput(mouseInfo);
            }
            else if (Input.GetMouseButton(mouseCode) && mouseInfo.ContinuousCommand)
            {
                OnKeepInput(mouseInfo);
            }
            else if (Input.GetMouseButtonUp(mouseCode))
            {
                OnReleaseInput(mouseInfo);
            }
        }
    }

    protected override void OnPressInput(InputInfo inputInfo)
    {
        EventManager.Instance.PostNotification(inputInfo.EVENT_TYPE, GameManager.Player);
    }

    protected override void OnKeepInput(InputInfo inputInfo)
    {
        if (inputInfo.EVENT_TYPE == EVENT_TYPE.MOVE)
        {
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
            EventManager.Instance.PostNotification(inputInfo.EVENT_TYPE, GameManager.Player, new object[] { MouseX, MouseY });
        }
        else
        {
            EventManager.Instance.PostNotification(inputInfo.EVENT_TYPE, GameManager.Player);
        }
    }

    protected override void OnReleaseInput(InputInfo inputInfo)
    {
        
    }

    #endregion
}
