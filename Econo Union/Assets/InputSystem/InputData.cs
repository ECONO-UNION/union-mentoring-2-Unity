using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    [System.Serializable]
    public class Key
    {
        [SerializeField]
        private ControllerType controllerType;
        [SerializeField]
        private PlayerType playerType;
        [SerializeField]
        private CommandType commandType;
        [SerializeField]
        private KeyCode keyCode;
        public ControllerType ControllerType => controllerType;
        public PlayerType PlayerType => playerType;
        public CommandType CommandType => commandType;
        public KeyCode KeyCode => keyCode;
    }

    [CreateAssetMenu(menuName = "InputSystem/InputData")]
    public class InputData : ScriptableObject
    {
        [SerializeField]
        private List<Key> keys;
        public List<Key> Keys => keys;
    }
}
