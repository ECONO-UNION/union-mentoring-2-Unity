using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.InputSystem;
using System;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerController PlayerController;

    [SerializeField]
    private PlayerType playerType;

    private AxisAction WalkAction;

    /// <summary>
    /// 각 커맨드에 해당하는 PlayerAction을 저장한 컬렉션
    /// </summary>
    private Dictionary<CommandType, PlayerAction> ActionTable = new Dictionary<CommandType, PlayerAction>();

    /// <summary>
    /// (Horizontal, Vertical)로 이뤄진 AxisInput 쌍 리스트
    /// </summary>
    private List<Tuple<AxisInput, AxisInput>> AxisInputList = new List<Tuple<AxisInput, AxisInput>>();

    void Start()
    {
        InitAxis();

        ActionTable.Add(CommandType.Attack, PlayerController.AttackAction);

        WalkAction = PlayerController.WalkAction;

    }

    void Update()
    {
        foreach(var keyValuePair in ActionTable)
        {
            var commandType = keyValuePair.Key;
            var playerAction = keyValuePair.Value;
            var keyStateList = InputManager.Instance.GetTableData(commandType, playerType);
            if (keyStateList == null) continue;
            foreach (var keyState in keyStateList)
            {
                if (keyState.GetKeyDown) playerAction.OnPressInputHandler();
                if (keyState.GetKey) playerAction.OnHoldingInputHandler();
                if (keyState.GetKeyUp) playerAction.OnReleaseInputHandler();
            }
          
        }
      
    }

    void FixedUpdate()
    {
        for (int i = 0; i < AxisInputList.Count; i++)
        {
            float x = AxisInputList[i].Item1.GetAxis();
            float y = AxisInputList[i].Item2.GetAxis();
            if(x != 0 || y != 0)
                WalkAction.OnEvent(x, y);
        }
    }

    void InitAxis()
    {
        List<KeyState> leftStates = InputManager.Instance.GetTableData(CommandType.Axis_Left, playerType);
        List<KeyState> rightStates = InputManager.Instance.GetTableData(CommandType.Axis_Right, playerType);
        List<KeyState> upStates = InputManager.Instance.GetTableData(CommandType.Axis_Up, playerType);
        List<KeyState> downStates = InputManager.Instance.GetTableData(CommandType.Axis_Down, playerType);     

        for (int i = 0; i < leftStates.Count; i++)
        {
            AxisInputList.Add(new Tuple<AxisInput, AxisInput>(new AxisInput(), new AxisInput()));
        }
        for (int i = 0; i < leftStates.Count; i++)
        {
            AxisInputList[i].Item1.SetNegative(leftStates[i]);
        }
        for (int i = 0; i < rightStates.Count; i++)
        {
            AxisInputList[i].Item1.SetPositive(rightStates[i]);
        }
        for (int i = 0; i < upStates.Count; i++)
        {
            AxisInputList[i].Item2.SetPositive(upStates[i]);
        }
        for (int i = 0; i < downStates.Count; i++)
        {
            AxisInputList[i].Item2.SetNegative(downStates[i]);
        }
    }
}
