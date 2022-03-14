using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Easy.InputSystem
{
    /// <summary>
    /// 조이스틱 버튼의 종류
    /// </summary>
    public enum JoystickButtonType
    {
        A = 0,
        B = 1,
        X = 2,
        Y = 3,
        RightBumper = 4,
        LeftBumper = 5,

    }

    [Serializable]
    public class JoystickInfo : InputInfo
    {
        [SerializeField]
        private JoystickButtonType buttonType;

        public JoystickButtonType ButtonType => buttonType;

    }

    [CreateAssetMenu(menuName = "InputData/JoystickData")]
    public class JoystickData : ScriptableObject
    {
        [SerializeField]
        private List<JoystickInfo> joystickInfos;

        public List<JoystickInfo> JoystickInfos => joystickInfos;
    }
}