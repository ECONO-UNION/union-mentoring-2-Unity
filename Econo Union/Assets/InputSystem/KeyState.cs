using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class KeyState
    {
        public bool GetKeyDown;

        public bool GetKey;

        public bool GetKeyUp;

        private KeyCode keyCode;
        public KeyCode KeyCode => keyCode;
        public KeyState(KeyCode keyCode)
        {
            this.keyCode = keyCode;
        }
    }
}
