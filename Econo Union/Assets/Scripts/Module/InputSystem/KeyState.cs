using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem
{
    public class KeyState
    {
        public bool GetKeyDown { get; set; }

        public bool GetKey { get; set; }

        public bool GetKeyUp { get; set; }

        public KeyCode KeyCode { get; private set; }

        public KeyState(KeyCode keyCode)
        {
            KeyCode = keyCode;
        }
    }
}
