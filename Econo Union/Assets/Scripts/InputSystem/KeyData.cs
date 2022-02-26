using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

[System.Serializable]
public class KeyInfo
{
    [SerializeField]
    private string name;

    [SerializeField]
    private KeyCode code;

    [SerializeField]
    private int index;

    [SerializeField]
    private EVENT_TYPE Event_Type;

    [SerializeField]
    private bool _ContinuousCommand;
    public string Name => name;

    public KeyCode Code => code;

    /// <summary>
    /// 입력 상태를 판별하기 위한 비트 정수
    /// </summary>
    public int Index => index;

    public EVENT_TYPE EVENT_TYPE => Event_Type;

    public bool ContinuousCommand => _ContinuousCommand;
}

[CreateAssetMenu(menuName ="InputData/KeyData")]
public class KeyData : ScriptableObject
{
    private List<KeyInfo> keyInfos;

    public List<KeyInfo> KeyInfos;
}
