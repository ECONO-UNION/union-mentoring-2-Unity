using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    void Execute();

    void Undo();
}

public enum CommandType
{
    Up, Left, Down, Right,

    Attack,
    Jump
}