using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class MouseController : Controller
{
    #region Fields

    /// <summary>
    /// ���콺 ������ ���� ���
    /// </summary>
    public const string MouseDataPath = "Data/MouseData";

    /// <summary>
    /// ���콺 ���� ������ 
    /// </summary>
    private MouseData mouseData;

    /// <summary>
    /// ���� �Է� ���� ���콺 ���¸� �˷��ִ� ����
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

            // �̹� �ش� ��ư�� �Է� ������ Ȯ��
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
    /// Ư�� ���콺 ��ư�� �Է� �� ����Ǵ� �޼ҵ�
    /// </summary>
    private void OnMouseDown(MouseInfo mouseInfo)
    {
        EventManager.Instance.PostNotification(mouseInfo.EVENT_TYPE, GameManager.Player);
    }

    /// <summary>
    /// Ư�� ���콺 ��ư�� �Է� �ϴ� ���� ����Ǵ� �޼ҵ�
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
    /// Ư�� ���콺 ��ư�� ���� ���� ����Ǵ� �޼ҵ�
    /// </summary>
    private void OnMouseUp(MouseInfo mouseInfo)
    {

    }

    #endregion
}
