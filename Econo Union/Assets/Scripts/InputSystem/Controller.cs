using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    /// <summary>
    /// 현재 입력 중인 버튼 상태를 알려주는 변수
    /// </summary>
    int CurrentButtonState;

    #region Methods

    /// <summary>
    /// 특정 키가 현재 눌려 있는지 검증하는 메소드
    /// </summary>
    public bool HasKeyBit(int keyBit)
    {
        var pivot = 1 << keyBit;
        return (CurrentButtonState & pivot) == pivot;
    }

    /// <summary>
    /// 특정 키를 홀딩 상태로 만드는 메소드
    /// </summary>
    public void AddKeyBit(int keyBit)
    {
        var pivot = 1 << keyBit;
        CurrentButtonState |= pivot;
    }

    /// <summary>
    /// 특정 키를 릴리스 상태로 만드는 메소드
    /// </summary>
    public void DeleteKeyBit(int keyBit)
    {
        var pivot = 1 << keyBit;
        CurrentButtonState &= ~pivot;
    }

    #endregion
}
