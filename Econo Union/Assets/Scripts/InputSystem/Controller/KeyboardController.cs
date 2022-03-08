using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class KeyboardController : Controller
{
    #region Fields

    /// <summary>
    /// 키 정보 데이터 
    /// </summary>
    private KeyData keyData;

    /// <summary>
    /// 데이터 파일 경로
    /// </summary>
    public const string DataFilePath = "Data/KeyData";

    const string horizontal = "Horizontal";
    const string vertical = "Vertical";

    private Dictionary<string, AxisInput> AxisTable = new Dictionary<string, AxisInput>();

    #endregion

    #region Properties


    #endregion

    #region Constructors

    public KeyboardController()
    {
        keyData = Resources.Load<KeyData>(DataFilePath);

        if (keyData == null)
        {
            Debug.LogError("Can't load KeyData file");
            return;
        }
        KeyInfo up = null, left = null, down = null, right = null;
        foreach(var keyInfo in keyData.KeyInfos)
        {
            if (keyInfo.CommandType == InputManager.CommandType.Move)
            {
                MoveInputInfos.Add(keyInfo);
                // 상하좌우 키를 바인드한다.
                switch (keyInfo.MoveType)
                {
                    case InputManager.MoveType.Up:
                        up = keyInfo;
                        break;
                    case InputManager.MoveType.Left:
                        left = keyInfo;
                        break;
                    case InputManager.MoveType.Down:
                        down = keyInfo;
                        break;
                    case InputManager.MoveType.Right:
                        right = keyInfo;
                        break;
                }
                
            }
            else
                NonMoveInputInfos.Add(keyInfo);
        }

        if(up != null && left != null && down != null && right != null)
        {
            AxisTable.Add(horizontal, new AxisInput(left, right));
            AxisTable.Add(vertical, new AxisInput(down, up));
        }
        
    }

    #endregion

    #region Callbacks

    public override void Update()
    {
        if (isRunning)
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
            KeyInfo keyInfo = (KeyInfo)inputInfo;            
            var keyCode = keyInfo.Code;
            keyInfo.IsPressed = Input.GetKeyDown(keyCode);
            keyInfo.IsHolding = Input.GetKey(keyCode);
            keyInfo.IsReleased = Input.GetKeyUp(keyCode);

            if (AxisTable.ContainsKey(horizontal) && AxisTable.ContainsKey(vertical))
            {
                float x = AxisTable[horizontal].GetAxis();
                float y = AxisTable[vertical].GetAxis();
                OnMoveInput(keyInfo, x, y);
            }

        }
    }

    protected override void OnCheckNonMoveInput() 
    {
        foreach (var inputInfo in NonMoveInputInfos)
        {
            KeyInfo keyInfo = (KeyInfo)inputInfo;
            var keyCode = keyInfo.Code;

            keyInfo.IsPressed = Input.GetKeyDown(keyCode);
            keyInfo.IsHolding = Input.GetKey(keyCode);
            keyInfo.IsReleased = Input.GetKeyUp(keyCode);

            if (Input.GetKeyDown(keyCode))
            {
                OnPressInput(keyInfo);
            }
            if (Input.GetKey(keyCode) && keyInfo.CanHolding)
            {
                OnKeepInput(keyInfo);
            }
            if (Input.GetKeyUp(keyCode))
            {
                OnReleaseInput(keyInfo);
            }

        }
    }

    #endregion
}
