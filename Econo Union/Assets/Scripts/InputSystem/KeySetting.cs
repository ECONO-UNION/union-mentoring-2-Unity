using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySetting
{
    private static KeyData _keyData;

    public KeyInfo[] KeyInfoSet { get; private set; }

    public Dictionary<KeyInfo, InputState> KeyInputSet = new Dictionary<KeyInfo, InputState>();

    public readonly KeyCode[] ArrowKeyCodeSet;
    public readonly KeyCode[] NonArrowKeyCodeSet;

    private const int ArrowKeyNumber = 4;
    public KeySetting()
    {
        _keyData = Resources.Load<KeyData>("Data/KeyData");
        if(_keyData == null)
        {
            Debug.Log("Key Data 로딩에 실패");
            return;
        }
        KeyInfoSet = _keyData.Keys.ToArray();
        ArrowKeyCodeSet = new KeyCode[ArrowKeyNumber];
        NonArrowKeyCodeSet = new KeyCode[KeyInfoSet.Length - ArrowKeyNumber];

        var arrowKeyIndex = 0;
        var nonArrowKeyIndex = 0;

        foreach (var keyInfo in KeyInfoSet)
        {
            var keyCode = keyInfo.Code;
            var keyName = keyInfo.Name;
            var iKeyCode = (int)keyCode;
            
            switch (keyCode)
            {
                case KeyCode.UpArrow:
                case KeyCode.LeftArrow:
                case KeyCode.DownArrow:
                case KeyCode.RightArrow:
                    ArrowKeyCodeSet[arrowKeyIndex++] = keyCode;
                    break;
                case KeyCode.None:
                    break;
                default:
                    NonArrowKeyCodeSet[nonArrowKeyIndex++] = keyCode;
                    break;
            }

            KeyInputSet.Add(keyInfo, new InputState(keyCode));

        }
    }
}
