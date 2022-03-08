using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Easy.Events.Delegate;

[Serializable]
public class InputInfo
{
    [SerializeField]
    protected string name;

    [SerializeField]
    protected InputManager.CommandType commandType;
    [SerializeField]
    protected InputManager.MoveType moveType;

    [SerializeField]
    protected bool _canHolding;

    public string Name => name;

    public InputManager.CommandType CommandType => commandType;
    public InputManager.MoveType MoveType => moveType;

    /// <summary>
    /// 특정 키가 최초 입력 상태
    /// </summary>
    [NonSerialized]
    public bool IsPressed;
    /// <summary>
    /// 특정 키가 입력 중인 상태
    /// </summary>
    [NonSerialized]
    public bool IsHolding;
    /// <summary>
    /// 특정 키를 뗀 상태
    /// </summary>
    [NonSerialized]
    public bool IsReleased;

    /// <summary>
    /// 홀딩 상태를 유지할 수 있는지 판별
    /// </summary>
    public bool CanHolding => _canHolding;
}
