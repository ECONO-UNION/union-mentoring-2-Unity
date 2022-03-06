using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;
using System;

[Serializable]
public class MouseInfo : InputInfo
{
    [SerializeField]
    private int code;

    public int Code => code;
}

[CreateAssetMenu(menuName = "InputData/MouseData")]
public class MouseData : ScriptableObject
{
    private List<MouseInfo> mouseInfos;

    public List<MouseInfo> MouseInfos;
}
