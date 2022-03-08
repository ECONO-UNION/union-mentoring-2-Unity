using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerInput : InputMapper
{
    #region Fields

    PlayerAction _playerAction;

    #endregion

    #region Constructors

    public PlayerInput()
    {
        _playerAction = GameManager.Player;
        InitSendInput();
    }

    #endregion

    #region Callbacks

    protected override void PressInputHandler(InputInfo inputInfo)
    {
        switch (inputInfo.CommandType)
        {
            case InputManager.CommandType.Attack:
                _playerAction.Attack();
                break;
            case InputManager.CommandType.Jump:
                _playerAction.Jump();
                break;
        }
    }

    protected override void HoldingInputHandler(InputInfo inputInfo)
    {
        
    }

    protected override void ReleaseInputHandler(InputInfo inputInfo)
    {
        
    }

    protected override void MoveEventHandler(InputInfo inputInfo, float x, float y)
    {
        _playerAction.Move(x, y);
    }

    #endregion

    #region Methods


    #endregion

}
