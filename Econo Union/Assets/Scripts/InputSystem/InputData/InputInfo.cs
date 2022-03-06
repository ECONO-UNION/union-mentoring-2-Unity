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
    protected int index;

    [SerializeField]
    protected EVENT_TYPE Event_Type;

    [SerializeField]
    protected bool _ContinuousCommand;

    public string Name => name;

    /// <summary>
    /// �Է� ���¸� �Ǻ��ϱ� ���� ��Ʈ ����
    /// </summary>
    public int Index => index;

    public EVENT_TYPE EVENT_TYPE => Event_Type;

    /// <summary>
    /// Ȧ�� ���¸� ������ �� �ִ��� �Ǻ��ϱ� ���� ����
    /// </summary>
    public bool ContinuousCommand => _ContinuousCommand;
}
