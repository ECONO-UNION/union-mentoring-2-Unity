using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class GameManager : MonoBehaviour
{
    #region Fields

    public static PlayerAction Player;

    #endregion

    #region Callbacks

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(Player == null)
        {
            Player = FindObjectOfType<PlayerAction>();
        }
        gameObject.AddComponent<EventManager>();
        gameObject.AddComponent<InputManager>();
    }

    #endregion
}
