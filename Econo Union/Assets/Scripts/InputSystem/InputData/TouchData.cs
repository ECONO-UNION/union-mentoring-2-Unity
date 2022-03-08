using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TouchInfo : InputInfo
{

}

[CreateAssetMenu(menuName = "InputData/TouchData")]
public class TouchData : ScriptableObject
{
    private List<TouchInfo> touchInfos;

    public List<TouchInfo> TouchInfos;
}