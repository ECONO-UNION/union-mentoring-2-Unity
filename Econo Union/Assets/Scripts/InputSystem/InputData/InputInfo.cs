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
    /// Ư�� Ű�� ���� �Է� ����
    /// </summary>
    [NonSerialized]
    public bool IsPressed;
    /// <summary>
    /// Ư�� Ű�� �Է� ���� ����
    /// </summary>
    [NonSerialized]
    public bool IsHolding;
    /// <summary>
    /// Ư�� Ű�� �� ����
    /// </summary>
    [NonSerialized]
    public bool IsReleased;

    /// <summary>
    /// Ȧ�� ���¸� ������ �� �ִ��� �Ǻ�
    /// </summary>
    public bool CanHolding => _canHolding;
}
