using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurveEditor : MonoBehaviour
{
    [SerializeField] Transform[] _curvePoints;
    Vector2 _gizmoPosition;
    [Range(0.02f, 0.1f)]  public float _tCoef = 0.05f;

    private void OnDrawGizmos() 
    {
        for (float t = 0; t <= 1; t += _tCoef)
        {
            Gizmos.color = Color.red;
            _gizmoPosition = GetBezierCurvePointByT(t, _curvePoints[0].position, _curvePoints[1].position, _curvePoints[2].position, _curvePoints[3].position);

            Gizmos.DrawSphere(_gizmoPosition, 0.25f);
        }

    }

    public static Vector2 GetBezierCurvePointByT(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        return Mathf.Pow(1 - t, 3) * p0 +
                         3 * Mathf.Pow(1 - t, 2) * t * p1 +
                         3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
                         Mathf.Pow(t, 3) * p3;
    }
}
