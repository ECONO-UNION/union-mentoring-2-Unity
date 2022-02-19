using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class InputManager : MonoBehaviour
{

    KeySetting KeySetting;

    private int CurrentKeyState;

    void Awake()
    {
        KeySetting = new KeySetting();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        foreach(var keyInput in KeySetting.KeyInputSet)
        {
            InputState inputState = keyInput.Value;
            if (inputState.GetKeyDown)
            {
                CommandType cmdType = keyInput.Key.CommandType;
                CommandManager.Instance.AddCommand(cmdType);
            }
        }
    }
}
