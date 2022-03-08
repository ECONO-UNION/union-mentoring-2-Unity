using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public partial class PlayerAction : MonoBehaviour
{
    #region Fields

    [SerializeField]
    Rigidbody2D _rigidbody;

    #endregion

    #region Callbacks

    void Awake()
    {
        
    }

    #endregion

    #region Methods

    public void Attack()
    {
        Debug.Log("Attack");
    }

    public void Jump()
    {
        Debug.Log("Jump");
    }

    #endregion
}
