using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class InputManager : MonoBehaviour
{
    #region Fields

    private static InputManager instance;

    /// <summary>
    /// 현재 사용 중인 컨트롤러 타입 리스트
    /// </summary>
    public List<ControllerType> ControllerTypeList = new List<ControllerType>();

    /// <summary>
    /// 컨트롤러 타입에 따른 Controller 객체 딕셔너리
    /// </summary>
    private Dictionary<ControllerType, Controller> ControllerTable = new Dictionary<ControllerType, Controller>();

    #endregion

    #region Properties

    public static InputManager Instance { 
        get { return instance; }
    }

    #endregion

    #region Enums

    /// <summary>
    /// 입력 플랫폼 타입
    /// </summary>
    [Flags]
    public enum ControllerType
    {     
        Keyboard = 0,
        
        Mouse = 1,
        
        Touch = 2,
        
        JoyStick = 3, 

        None,
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
            Destroy(this);
    }

    void Start()
    {
        CreateController();
    }

    void Update()
    {
        foreach(var controllerPair in ControllerTable)
        {
            Controller controller = controllerPair.Value;
            if (controller.IsRunning)
            {
                controller.Update();
            }
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// 모든 컨트롤러를 생성하는 메소드 
    /// </summary>
    private void CreateController()
    {
        ControllerTable.Add(ControllerType.Keyboard, new KeyboardController());
        ControllerTable.Add(ControllerType.Mouse, new MouseController());
        ControllerTable.Add(ControllerType.Touch, new TouchController());
        ControllerTable.Add(ControllerType.JoyStick, new JoystickController());

        ExecuteController();
    }

    /// <summary>
    /// 플랫폼별로 컨트롤러를 실행하도록 하는 메소드
    /// </summary>
    public void ExecuteController()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer:
                StartController(ControllerType.Keyboard);
                StartController(ControllerType.Mouse);
                break;
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                StartController(ControllerType.Touch);
                break;
            case RuntimePlatform.XboxOne:
            case RuntimePlatform.PS4:
            case RuntimePlatform.PS5:
                StartController(ControllerType.JoyStick);
                break;
        }
    }

    /// <summary>
    /// 특정 컨트롤러를 실행하도록 하는 메소드
    /// </summary>
    public void StartController(ControllerType controllerType)
    {
        if (!ControllerTable.ContainsKey(controllerType)) return;

        ControllerTable[controllerType].StartController();
        
    }

    /// <summary>
    /// 특정 컨트롤러를 중지하도록 하는 메소드
    /// </summary>
    public void StopController(ControllerType controllerType)
    {
        if (!ControllerTable.ContainsKey(controllerType)) return;

        ControllerTable[controllerType].StopController();
    }

    #endregion
}

