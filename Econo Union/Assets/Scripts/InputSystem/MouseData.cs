using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

[System.Serializable]
public class MouseInfo
{
    [SerializeField]
    private string name;

    [SerializeField]
    private int code;

    [SerializeField]
    private int index;

    [SerializeField]
    private EVENT_TYPE Event_Type;

    [SerializeField]
    private bool _ContinuousCommand;
    public string Name => name;

    public int Code => code;

    /// <summary>
    /// �Է� ���¸� �Ǻ��ϱ� ���� ��Ʈ ����
    /// </summary>
    public int Index => index;

    public EVENT_TYPE EVENT_TYPE => Event_Type;

    public bool ContinuousCommand => _ContinuousCommand;
}

[CreateAssetMenu(menuName = "InputData/MouseData")]
public class MouseData : ScriptableObject
{
    private List<MouseInfo> mouseInfos;

    public List<MouseInfo> MouseInfos;
}
