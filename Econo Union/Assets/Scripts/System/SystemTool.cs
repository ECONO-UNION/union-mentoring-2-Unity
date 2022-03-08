using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class SystemTool
{
    /// <summary>
    /// 기본 타입을 변환하기 위한 컬렉션
    /// </summary>
    private static Dictionary<Type, Func<string, object>> BaseTypeCollection = new Dictionary<Type, Func<string, object>>
    {
        {typeof(string), (value) => value },
        {typeof(byte), (value) => ChangeType<byte>(value)},
        {typeof(Int32), (value) => ChangeType<Int32>(value)},
        {typeof(Int64), (value) => ChangeType<Int64>(value)},
        {typeof(UInt32), (value) => ChangeType<UInt32>(value)},
        {typeof(UInt64), (value) => ChangeType<UInt64>(value)},
        {typeof(float), (value) => ChangeType<float>(value)},
        {typeof(double), (value) => ChangeType<double>(value)},
        {typeof(bool), (value) => ChangeType<bool>(value)},
    };

    /// <summary>
    /// object를 T로 타입 변환하는 메소드
    /// </summary>
    public static T ChangeType<T>(object obj)
    {
        return (T)Convert.ChangeType(obj, typeof(T));
    }

    /// <summary>
    /// string형 value를 type형으로 디코드하는 메소드
    /// </summary>
    public static object DecodeType(this string value, Type type)
    {
        if (BaseTypeCollection.ContainsKey(type))
            return BaseTypeCollection[type](value);
        return null;
    }
}
