using Easy.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    #region Fields

    public static PlayerAction Player;
    public static PlayerAction Player2;

    #endregion

    #region Callbacks

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        gameObject.AddComponent<InputManager>();
    }

    #endregion
}
