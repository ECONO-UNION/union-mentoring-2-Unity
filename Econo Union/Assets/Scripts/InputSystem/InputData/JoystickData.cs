using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class JoystickInfo : InputInfo
{

}

[CreateAssetMenu(menuName = "InputData/KeyData")]
public class JoystickData : ScriptableObject
{
    private List<JoystickInfo> joystickInfos;

    public List<JoystickInfo> JoystickInfos;
}