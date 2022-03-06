using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller
{
    #region Fields

    protected bool isRunning;

    #endregion

    #region Properties

    public bool IsRunning { get { return isRunning; } }

    #endregion

    #region Callbacks

    /// <summary>
    /// Ư�� Ű�� ���� �Է½� ����Ǵ� �޼ҵ�
    /// </summary>
    protected abstract void OnPressInput(InputInfo inputInfo);

    /// <summary>
    /// Ư�� Ű�� �Է��ϴ� ���� ����Ǵ� �޼ҵ�
    /// </summary>
    protected abstract void OnKeepInput(InputInfo inputInfo);

    /// <summary>
    /// Ư�� Ű�� ���� ���� ����Ǵ� �޼ҵ�
    /// </summary>
    protected abstract void OnReleaseInput(InputInfo inputInfo);

    /// <summary>
    /// �� ������ ���� ����Ǵ� �޼ҵ�.
    /// </summary>
    public abstract void Update();

    /// <summary>
    /// �Է� �������� �� �Է� ������ �Է� ���¸� Ȯ���ϴ� �޼ҵ�
    /// </summary>
    public abstract void OnCheckInput();
    #endregion

    #region Methods

    /// <summary>
    /// ��Ʈ�ѷ� �Է��� �����ϴ� �޼ҵ�
    /// </summary>
    public virtual void StartController()
    {
        isRunning = true;
    }

    /// <summary>
    /// ��Ʈ�ѷ� �Է��� �����ϴ� �޼ҵ�
    /// </summary>
    public virtual void StopController()
    {
        isRunning = false;
    }

    #endregion
}
