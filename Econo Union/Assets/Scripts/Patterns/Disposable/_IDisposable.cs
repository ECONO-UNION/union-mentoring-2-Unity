using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface _IDisposable : IDisposable
{
    bool IsDisposed { get; set; }

    /// <summary>
    /// 인스턴스가 파기될 때 수행하는 메소드
    /// </summary>
    void DisposeUnManaged();

}
