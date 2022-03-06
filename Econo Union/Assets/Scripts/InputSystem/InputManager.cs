using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class InputManager : MonoBehaviour
{
    #region Fields

    private static InputManager instance;

    /// <summary>
    /// ���� ��� ���� ��Ʈ�ѷ� Ÿ�� ����Ʈ
    /// </summary>
    public List<ControllerType> ControllerTypeList = new List<ControllerType>();

    /// <summary>
    /// ��Ʈ�ѷ� Ÿ�Կ� ���� Controller ��ü ��ųʸ�
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
    /// �Է� �÷��� Ÿ��
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
    /// ��� ��Ʈ�ѷ��� �����ϴ� �޼ҵ� 
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
    /// �÷������� ��Ʈ�ѷ��� �����ϵ��� �ϴ� �޼ҵ�
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
    /// Ư�� ��Ʈ�ѷ��� �����ϵ��� �ϴ� �޼ҵ�
    /// </summary>
    public void StartController(ControllerType controllerType)
    {
        if (!ControllerTable.ContainsKey(controllerType)) return;

        ControllerTable[controllerType].StartController();
        
    }

    /// <summary>
    /// Ư�� ��Ʈ�ѷ��� �����ϵ��� �ϴ� �޼ҵ�
    /// </summary>
    public void StopController(ControllerType controllerType)
    {
        if (!ControllerTable.ContainsKey(controllerType)) return;

        ControllerTable[controllerType].StopController();
    }

    #endregion
}

