using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : Controller
{
    #region Callbacks

    public override void Update()
    {
        if (isRunning)
            OnCheckInput();
    }
    public override void OnCheckInput()
    {
        
    }

    protected override void OnKeepInput(InputInfo inputInfo)
    {
        
    }

    protected override void OnPressInput(InputInfo inputInfo)
    {
        
    }

    protected override void OnReleaseInput(InputInfo inputInfo)
    {
        
    }

    #endregion
}
