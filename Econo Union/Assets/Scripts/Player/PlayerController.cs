using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent
{
    public Rigidbody2D _rigidbody;

    public Transform _transform;

    public PlayerComponent(Rigidbody2D rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
    }

}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _rigidbody;

    Transform _transform;

    public PlayerAction AttackAction { get; private set; }

    public AxisAction WalkAction { get; private set; }
    
    void Awake()
    {
        _transform = transform;
        PlayerComponent playerComponent = new PlayerComponent(_rigidbody, _transform);
        AttackAction = new AttackAction(playerComponent);
        WalkAction = new WalkAction(playerComponent); 
    }

}
