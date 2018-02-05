using UnityEngine;
using System.Collections;

public static class Extensions
{
    public static Vector3 NoY(this Vector3 v)
    {
        return new Vector3(v.x, 0f, v.z);
    }
}