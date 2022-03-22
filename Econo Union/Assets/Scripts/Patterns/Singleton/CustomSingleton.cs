using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISingleton : _IDisposable
{
    /// <summary>
    /// 싱글톤 생성시 초기화하는 메소드
    /// </summary>
    void OnInitiate();

    /// <summary>
    /// 싱글톤 생성시 실행하는 메소드 
    /// </summary>
    void OnCreate();

}

public abstract class Singleton<T> : ISingleton where T: Singleton<T>, new()
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null) instance = GetInstanceObject();
            return instance;
        }
    }

    protected static T GetInstanceObject()
    {
        if (instance != null) return instance;

        instance = new T();

        var _singleton = instance as Singleton<T>;

        _singleton.OnCreate();
        _singleton.OnInitiate();
        return instance;
    }

    public abstract void OnCreate();

    public abstract void OnInitiate();

    #region Disposable
    public bool IsDisposed { get; set; }

    public void Dispose()
    {
        if (IsDisposed) return;

        IsDisposed = true;
        DisposeUnManaged();
    }

    public void DisposeUnManaged()
    {
        instance = null;
    }

    #endregion
}

public abstract class UnitySingleton<T> : MonoBehaviour, ISingleton where T : UnitySingleton<T>
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null) instance = GetInstanceObject();
            return instance;
        }
    }
    protected static T GetInstanceObject()
    {
        if (instance != null) return instance;

        instance = FindObjectOfType<T>();

        var _singleton = instance as UnitySingleton<T>;

        _singleton.OnCreate();
        _singleton.OnInitiate();

        return instance;
    }

    protected void Awake()
    {
        instance = GetInstanceObject();
    }

    public abstract void OnCreate();
    public abstract void OnInitiate();


    #region Disposable
    public bool IsDisposed { get; set; }

    public void Dispose()
    {
        if (IsDisposed) return;

        IsDisposed = true;
        DisposeUnManaged();
    }

    public void DisposeUnManaged()
    {
        instance = null;
        Destroy(this);
    }


    #endregion
}