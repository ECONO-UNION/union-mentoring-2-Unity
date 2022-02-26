using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    /// <summary>
    /// ���� �Է� ���� ��ư ���¸� �˷��ִ� ����
    /// </summary>
    int CurrentButtonState;

    #region Methods

    /// <summary>
    /// Ư�� Ű�� ���� ���� �ִ��� �����ϴ� �޼ҵ�
    /// </summary>
    public bool HasKeyBit(int keyBit)
    {
        var pivot = 1 << keyBit;
        return (CurrentButtonState & pivot) == pivot;
    }

    /// <summary>
    /// Ư�� Ű�� Ȧ�� ���·� ����� �޼ҵ�
    /// </summary>
    public void AddKeyBit(int keyBit)
    {
        var pivot = 1 << keyBit;
        CurrentButtonState |= pivot;
    }

    /// <summary>
    /// Ư�� Ű�� ������ ���·� ����� �޼ҵ�
    /// </summary>
    public void DeleteKeyBit(int keyBit)
    {
        var pivot = 1 << keyBit;
        CurrentButtonState &= ~pivot;
    }

    #endregion
}
