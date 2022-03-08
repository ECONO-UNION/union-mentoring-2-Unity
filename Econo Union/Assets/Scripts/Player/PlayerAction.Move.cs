using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerAction : MonoBehaviour
{
    float moveSpeed = 10f;

    /// <summary>
    /// 이동 커맨드 메소드
    /// </summary>
    public void Move(float x, float y)
    {
        Vector3 velocity = _rigidbody.velocity;
        Vector3 inputPos = new Vector3(x, y, 0).normalized;

        _rigidbody.MovePosition(transform.position + inputPos * Time.deltaTime * moveSpeed);
    }
}
