using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Easy.Events.Delegate;

public class PlayerAction : MonoBehaviour
{
    float moveSpeed = 5f;

    private EventManager.OnEvent OnEvent;

    void Start()
    {
        OnEvent = CheckEvent;
        EventManager.Instance.AddListener(EVENT_TYPE.ATTACK, OnEvent);
        EventManager.Instance.AddListener(EVENT_TYPE.JUMP, OnEvent);
        EventManager.Instance.AddListener(EVENT_TYPE.MOVE, OnEvent);
    }
  
    public void CheckEvent(EVENT_TYPE Event_Type, Component Sender, object[] Param = null)
    {
        switch (Event_Type)
        {
            case EVENT_TYPE.ATTACK:
                Attack();
                break;
            case EVENT_TYPE.JUMP:
                Jump();
                break;
            case EVENT_TYPE.MOVE:
                if(Param != null)
                    Move((float)Param[0], (float)Param[1]);
                break;
        }
    }

    void Attack()
    {
        Debug.Log("Player Attack!");
    }

    void Jump()
    {
        Debug.Log("Player Jump!");
    }

    void Move(float h, float v)
    {
        Vector3 moveDir = Vector3.up * v + Vector3.right * h;
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
    }
}
