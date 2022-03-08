using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : Controller
{
    #region Callbacks

    public override void Update()
    {
        if (isRunning)
            OnCheckNonMoveInput();
    }
    public override void FixedUpdate()
    {
        if (isRunning)
            OnCheckMoveInput();
    }

    protected override void OnCheckMoveInput()
    {

    }

    protected override void OnCheckNonMoveInput()
    {

    }

    #endregion
}
