using UnityEngine;
using System.Collections;

public static class MathUtility
{
	public static Vector3 NoX(this Vector3 v)
	{
		return new Vector3(0f, v.y, v.z);
	}

	public static Vector3 NoY(this Vector3 v)
	{
		return new Vector3(v.x, 0f, v.z);
	}

	public static Vector3 NoZ(this Vector3 v)
    {
        return new Vector3(v.x, v.y, 0f);
    }

	public static bool IsClose(Vector3 p1, Vector3 p2, float threshold)
	{
		return Vector3.Distance(p1, p2) <= threshold;
	}
}