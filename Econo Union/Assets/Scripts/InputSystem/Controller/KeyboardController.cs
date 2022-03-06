using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class KeyboardController : Controller
{
    #region Fields

    /// <summary>
    /// 키 정보 데이터 
    /// </summary>
    private KeyData keyData;

    /// <summary>
    /// 데이터 파일 경로
    /// </summary>
    public const string DataFilePath = "Data/KeyData";

    #endregion

    #region Properties


    #endregion

    #region Constructors

    public KeyboardController()
    {
        keyData = Resources.Load<KeyData>(DataFilePath);

        if (keyData == null)
        {
            Debug.LogError("Can't load KeyData file");
            return;
        }
    }

    #endregion

    #region Callbacks

    public override void Update()
    {
        if (isRunning)
            OnCheckInput();
    }

    public override void OnCheckInput()
    {
        foreach(var keyInfo in keyData.KeyInfos)
        {
            var keyCode = keyInfo.Code;
            var keyBit = keyInfo.Index;

            if (Input.GetKeyUp(keyCode))
            {
                OnReleaseInput(keyInfo);
            }
            if (Input.GetKey(keyCode) && keyInfo.ContinuousCommand)
            {
                OnKeepInput(keyInfo);
            }
            if (Input.GetKeyDown(keyCode))
            {
                OnReleaseInput(keyInfo);
            }

        }
    }

    protected override void OnPressInput(InputInfo inputInfo)
    {
         EventManager.Instance.PostNotification(inputInfo.EVENT_TYPE, GameManager.Player);
    }

    protected override void OnKeepInput(InputInfo inputInfo)
    {
        if (inputInfo.EVENT_TYPE == EVENT_TYPE.MOVE)
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            EventManager.Instance.PostNotification(inputInfo.EVENT_TYPE, GameManager.Player, new object[] { h, v });
        }
        else
        {
            EventManager.Instance.PostNotification(inputInfo.EVENT_TYPE, GameManager.Player);
        }
    }

    protected override void OnReleaseInput(InputInfo inputInfo)
    {
        
    }

    #endregion
}
