using Easy.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    #region Callbacks

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        gameObject.AddComponent<InputManager>();
    }

    #endregion
}
