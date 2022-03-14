using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Easy.InputSystem
{
    [Serializable]
    public class KeyInfo : InputInfo
    {
        [SerializeField]
        private KeyCode keyCode;

        public KeyCode KeyCode => keyCode;

    }

    [CreateAssetMenu(menuName = "InputData/KeyData")]
    public class KeyData : ScriptableObject
    {
        [SerializeField]
        private List<KeyInfo> keyInfos;

        public List<KeyInfo> KeyInfos => keyInfos;
    }
}