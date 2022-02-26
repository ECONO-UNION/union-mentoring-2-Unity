using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class KeyboardController : Controller
{
    #region Fields

    /// <summary>
    /// 키 데이터 파일 경로
    /// </summary>
    public const string KeyDataPath = "Data/KeyData";

    /// <summary>
    /// 키 정보 데이터 
    /// </summary>
    private KeyData keyData;

   
    #endregion

    #region Callbacks

    void Awake()
    {
        keyData = Resources.Load<KeyData>(KeyDataPath);
       
        if(keyData == null)
        {
            Debug.LogError("Can't load KeyData file");
            return;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        OnCheckKey();
    }

    /// <summary>
    /// 키 입력을 확인하는 메소드
    /// </summary>
    private void OnCheckKey()
    {
        foreach(var keyInfo in keyData.KeyInfos)
        {
            var keyCode = keyInfo.Code;
            var keyBit = keyInfo.Index;


            // 이미 해당 키가 입력 중인지 확인
            if (HasKeyBit(keyBit))
            {
                if (Input.GetKeyUp(keyCode))
                {
                    DeleteKeyBit(keyBit);
                    OnReleaseKey(keyInfo);
                }
                else
                {
                    if (keyInfo.ContinuousCommand)
                        OnKeepKey(keyInfo);
                }
            }
            else
            {
                if (Input.GetKeyDown(keyCode))
                {
                    AddKeyBit(keyBit);
                    OnPressKey(keyInfo);
                }
            }
        }
    }

    /// <summary>
    /// 특정 키를 입력 시 최초 실행되는 메소드
    /// </summary>
    private void OnPressKey(KeyInfo keyInfo)
    {
#if UNITY_EDITOR
        //Debug.Log($"{keyCode} 눌림");
#endif
      
        EventManager.Instance.PostNotification(keyInfo.EVENT_TYPE, GameManager.Player);
        
    }

    /// <summary>
    /// 특정 키를 입력하는 동안 실행되는 메소드
    /// </summary>
    private void OnKeepKey(KeyInfo keyInfo)
    {
#if UNITY_EDITOR
        //Debug.Log($"{keyCode} 눌리는 중");
#endif
       
        if (keyInfo.EVENT_TYPE == EVENT_TYPE.MOVE)
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            EventManager.Instance.PostNotification(keyInfo.EVENT_TYPE, GameManager.Player, new object[] { h, v });
        }
        else
        {
            EventManager.Instance.PostNotification(keyInfo.EVENT_TYPE, GameManager.Player);
        }
    }

    /// <summary>
    /// 특정 키를 떼는 순간 실행되는 메소드
    /// </summary>
    private void OnReleaseKey(KeyInfo keyInfo)
    {
#if UNITY_EDITOR
        //Debug.Log($"{keyCode} 떼짐");
#endif
        

    }

    #endregion
}
