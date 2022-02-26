using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class KeyboardController : Controller
{
    #region Fields

    /// <summary>
    /// Ű ������ ���� ���
    /// </summary>
    public const string KeyDataPath = "Data/KeyData";

    /// <summary>
    /// Ű ���� ������ 
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
    /// Ű �Է��� Ȯ���ϴ� �޼ҵ�
    /// </summary>
    private void OnCheckKey()
    {
        foreach(var keyInfo in keyData.KeyInfos)
        {
            var keyCode = keyInfo.Code;
            var keyBit = keyInfo.Index;


            // �̹� �ش� Ű�� �Է� ������ Ȯ��
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
    /// Ư�� Ű�� �Է� �� ���� ����Ǵ� �޼ҵ�
    /// </summary>
    private void OnPressKey(KeyInfo keyInfo)
    {
#if UNITY_EDITOR
        //Debug.Log($"{keyCode} ����");
#endif
      
        EventManager.Instance.PostNotification(keyInfo.EVENT_TYPE, GameManager.Player);
        
    }

    /// <summary>
    /// Ư�� Ű�� �Է��ϴ� ���� ����Ǵ� �޼ҵ�
    /// </summary>
    private void OnKeepKey(KeyInfo keyInfo)
    {
#if UNITY_EDITOR
        //Debug.Log($"{keyCode} ������ ��");
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
    /// Ư�� Ű�� ���� ���� ����Ǵ� �޼ҵ�
    /// </summary>
    private void OnReleaseKey(KeyInfo keyInfo)
    {
#if UNITY_EDITOR
        //Debug.Log($"{keyCode} ����");
#endif
        

    }

    #endregion
}
