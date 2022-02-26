using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class InputManager : MonoBehaviour
{
    #region Fields

    private static InputManager instance;

    #endregion

    #region Properties

    public static InputManager Instance { 
        get { return instance; }
    }

    public ControllerType _ControllerType;

    #endregion

    #region Enums

    /// <summary>
    /// ÀÔ·Â ÇÃ·§Æû Å¸ÀÔ
    /// </summary>
    [Flags]
    public enum ControllerType
    {     
        Keyboard_Touch = 0,
        
        Touch = 1,
        
        Keyboard = 2,
        
        None = 3,
    }

    public enum InputState
    {
        Press,

        Holding,

        Release,
    }

    #endregion

    #region Callbacks

    void Awake()
    {
        if (instance == null)
        {
            instance = this;         
        }
        else
            DestroyImmediate(this);

        SetControllerType();
    }

    void Start()
    {
       
    }

    #endregion

    #region Methods

    public void SetControllerType()
    {
        int index = PlayerPrefs.GetInt("ControllerType");
        var controllerTypes = Enum.GetValues(typeof(ControllerType));
        _ControllerType = (ControllerType)controllerTypes.GetValue(index);
        switch (_ControllerType)
        {
            case ControllerType.Keyboard:
                gameObject.AddComponent<KeyboardController>();
                break;
            case ControllerType.Touch:
                gameObject.AddComponent<MouseController>();
                break;
            case ControllerType.Keyboard_Touch:
                gameObject.AddComponent<MouseController>();
                gameObject.AddComponent<KeyboardController>();
                break;              
        }
    }

    #endregion

}
