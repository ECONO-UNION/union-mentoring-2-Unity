using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Easy.InputSystem
{
    /// <summary>
    /// 입력 후 동작하는 명령 유형
    /// </summary>
    public enum CommandType
    {
        None,
        // Player 동작 //
        // 프레임당 상하좌우로 이동 
        Axis_Left, Axis_Right, Axis_Up, Axis_Down,
        // 특정 위치로 이동
        Move,

        Attack,
        Jump,

        // UI 동작 //
        // UI 취소 커맨드
        Cancel,
        // UI 확인 커맨드
        Submit,
    }

    [Serializable]
    public class InputInfo
    {       
        [SerializeField]
        protected CommandType commandType;

        [SerializeField]
        protected bool canHolding;

        public CommandType CommandType => commandType;

        /// <summary>
        /// 홀딩 상태를 유지할 수 있는지 판단
        /// </summary>
        public bool CanHolding => canHolding;

        /// <summary>
        /// 특정 키가 최초 입력 상태
        /// </summary>
        [NonSerialized]
        public bool IsPressed;

        /// <summary>
        /// 특정 키가 입력 중인 상태
        /// </summary>
        [NonSerialized]
        public bool IsHolding;

        /// <summary>
        /// 특정 키를 뗀 상태
        /// </summary>
        [NonSerialized]
        public bool IsReleased;

    }

}