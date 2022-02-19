using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyInfo
{
    #region Fields

    [SerializeField]
    private CommandType commandType;

    //[SerializeField]
    private string name;

    [SerializeField]
    private KeyCode code;

    private int index;


    #endregion

    #region Properties

    public string Name 
    { 
        get => name;
    }

    public KeyCode Code
    {
        get => code;
    }

    public int Index
    {
        get => index;
    }    

    public CommandType CommandType
    {
        get => commandType;
    }

    #endregion
}

[CreateAssetMenu(fileName = "KeyData", menuName = "KeyData")]
public class KeyData : ScriptableObject
{
    [SerializeField]
    private List<KeyInfo> keys;

    public List<KeyInfo> Keys
    {
        get => keys;
    }
}


[System.Serializable]
public class InputState
{
    public bool GetKeyDown => Input.GetKeyDown(Code);

    public KeyCode Code;

    public InputState(KeyCode code)
    {
        Code = code;
    }
}