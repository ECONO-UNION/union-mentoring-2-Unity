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
    /// 입력 상태를 판별하기 위한 비트 정수
    /// </summary>
    public int Index => index;

    public EVENT_TYPE EVENT_TYPE => Event_Type;

    /// <summary>
    /// 홀딩 상태를 유지할 수 있는지 판별하기 위한 변수
    /// </summary>
    public bool ContinuousCommand => _ContinuousCommand;
}
