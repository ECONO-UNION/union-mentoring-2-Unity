using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInput : InputMapper
{
    #region Constructors

    public UIInput()
    {
        InitSendInput();
    }

    #endregion

    #region Callbacks

    protected override void PressInputHandler(InputInfo inputInfo)
    {
        base.PressInputHandler(inputInfo);
        Debug.Log("PressInputHandler");
    }

    protected override void HoldingInputHandler(InputInfo inputInfo)
    {
        base.HoldingInputHandler(inputInfo);
    }

    protected override void ReleaseInputHandler(InputInfo inputInfo)
    {
        base.ReleaseInputHandler(inputInfo);
    }

    #endregion
}
