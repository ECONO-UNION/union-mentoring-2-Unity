using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Easy.InputSystem
{
    /// <summary>
    /// 입력 시스템은 Controller -> InputMapper -> 커맨드 수행 객체 순으로 처리된다.
    /// 
    /// 입력 시스템에서 Controller를 관리하는 클래스
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        #region Fields

        private static InputManager instance;
     
        /// <summary>
        /// 현재 실행 중인 Controller 리스트
        /// </summary>
        private List<Controller> ActiveControllers;

        #endregion

        #region Properties

        public static InputManager Instance
        {
            get { return instance; }
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

            ActiveControllers = new List<Controller>();
        }

        void Start()
        {
            CreateController();
        }

        void Update()
        {
            foreach (var controller in ActiveControllers)
            {              
                controller.Update();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 플랫폼에 해당하는 컨트롤러를 생성하는 메소드 
        /// </summary>
        private void CreateController()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.WindowsPlayer:
                    ActiveControllers.Add(new KeyboardController());
                    ActiveControllers.Add(new MouseController());
                    break;
                case RuntimePlatform.XboxOne:
                case RuntimePlatform.PS4:
                case RuntimePlatform.PS5:
                case RuntimePlatform.Switch:
                    CheckJoysticks();
                    break;
            }

        }

        /// <summary>
        /// 현재 연결 중인 조이스틱들을 확인 후 JoystickController 객체를 생성한다.
        /// </summary>
        private void CheckJoysticks()
        {
            string[] joystickNames = Input.GetJoystickNames();

            if (joystickNames.Length > 0)
            {
                for (int i = 0; i < joystickNames.Length; i++)
                {
                    ActiveControllers.Add(new JoystickController(joystickNames[i], i));
                }
            }
        }

        #endregion
    }

    
}
