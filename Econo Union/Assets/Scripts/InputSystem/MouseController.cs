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

    #region Callbacks

    void Awake()
    {
        mouseData = Resources.Load<MouseData>(MouseDataPath);

        if (mouseData == null)
        {
            Debug.LogError("Can't load MouseData file");
            return;
        }
    }

    void Update()
    {
        OnCheckButton();
    }

    private void OnCheckButton()
    {
        foreach (var mouseInfo in mouseData.MouseInfos)
        {           
            var mouseCode = mouseInfo.Code;
            var mouseBit = mouseInfo.Index;

            // 이미 해당 버튼이 입력 중인지 확인
            if (HasKeyBit(mouseBit))
            {
                if (Input.GetMouseButtonUp(mouseCode))
                {
                    DeleteKeyBit(mouseBit);
                    OnMouseUp(mouseInfo);
                }
                else
                {
                    if (mouseInfo.ContinuousCommand)
                        OnMouse(mouseInfo);
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(mouseCode))
                {
                    AddKeyBit(mouseBit);
                    OnMouseDown(mouseInfo);
                }
            }
        }
    }

    /// <summary>
    /// 특정 마우스 버튼을 입력 시 실행되는 메소드
    /// </summary>
    private void OnMouseDown(MouseInfo mouseInfo)
    {
        EventManager.Instance.PostNotification(mouseInfo.EVENT_TYPE, GameManager.Player);
    }

    /// <summary>
    /// 특정 마우스 버튼을 입력 하는 동안 실행되는 메소드
    /// </summary>
    private void OnMouse(MouseInfo mouseInfo)
    {
 
        if (mouseInfo.EVENT_TYPE == EVENT_TYPE.MOVE)
        {
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
            EventManager.Instance.PostNotification(mouseInfo.EVENT_TYPE, GameManager.Player, new object[] { MouseX, MouseY });
        }
        else
        {
            EventManager.Instance.PostNotification(mouseInfo.EVENT_TYPE, GameManager.Player);
        }
    }

    /// <summary>
    /// 특정 마우스 버튼을 떼는 순간 실행되는 메소드
    /// </summary>
    private void OnMouseUp(MouseInfo mouseInfo)
    {

    }

    #endregion
}
