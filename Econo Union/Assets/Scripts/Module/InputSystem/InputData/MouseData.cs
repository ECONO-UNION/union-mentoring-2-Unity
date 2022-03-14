using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Easy.InputSystem
{
    [Serializable]
    public class MouseInfo : InputInfo
    {
        [SerializeField]
        private int button;
        
        public int Button => button;

    }

    [CreateAssetMenu(menuName = "InputData/MouseData")]
    public class MouseData : ScriptableObject
    {
        [SerializeField]
        private List<MouseInfo> mouseInfos;

        public List<MouseInfo> MouseInfos => mouseInfos;
    }

}