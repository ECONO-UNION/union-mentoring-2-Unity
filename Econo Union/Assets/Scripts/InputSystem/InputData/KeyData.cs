using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;
using System;

[Serializable]
public class KeyInfo: InputInfo
{
    [SerializeField]
    private KeyCode code;

    public KeyCode Code => code;
}

[CreateAssetMenu(menuName ="InputData/KeyData")]
public class KeyData : ScriptableObject
{
    private List<KeyInfo> keyInfos;

    public List<KeyInfo> KeyInfos;
}
