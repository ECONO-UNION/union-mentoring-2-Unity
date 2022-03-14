using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Easy.InputSystem.Mapper
{
    /// <summary>
    /// 입력 처리가 실제로 이루어지는 객체를 연결해주는 클래스.
    /// InputMapper.EventHandler에서 Controller로부터 입력된 커맨드에 대한 이벤트 핸들러를 기술한다.
    /// InputMapper에서는 각 커맨드에 맞는 Player와 UI의 함수를 호출하도록 매핑한다.
    /// </summary>
    public partial class InputMapper
    {
        private static InputMapper instance;

        public static InputMapper Instance
        {
            get
            {
                if (instance == null) instance = new InputMapper();
                return instance;
            }
        }
        public InputMapper()
        {
            InitSendHandler();
        }

    }
}
