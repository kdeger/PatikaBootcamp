using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BezierExtension
{
    public static void SetPositionByBezierCurvePoint(this Transform trans, float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        trans.position = Mathf.Pow(1 - t, 3) * p0 +
                         3 * Mathf.Pow(1 - t, 2) * t * p1 +
                         3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
                         Mathf.Pow(t, 3) * p3;
    }

    public static void CustomLog(this Debug debug, object message)
    {
        Debug.Log("Custom message: " + message);
    }
}
