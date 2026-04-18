using UnityEngine;
using System;

public static class ArrayExtension {

    public static ref T At<T, U>(this T[] array, U enumValue) where U : Enum {
        int index = (int)(object)enumValue;

        if (index < 0 || index >= array.Length) { throw new IndexOutOfRangeException("Index was out of bounds"); }
        return ref array[(int)(object)enumValue];
    }
}
