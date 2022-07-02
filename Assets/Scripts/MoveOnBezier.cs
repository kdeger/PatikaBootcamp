using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnBezier : MonoBehaviour
{
    [SerializeField] Transform[] _beizerCurve;
    [SerializeField] float _speedCoef = 1;
    int _runningBezierCurveNo = 0;

    void Start()
    {
        StartCoroutine(MoveOnBezierRoute());
    }

    IEnumerator MoveOnBezierRoute()
    {
        Vector2 positionToGo = transform.position;

        float t = 0f;

        while (t <= 1)
        {
            t += Time.deltaTime * _speedCoef;
            positionToGo = BezierCurveEditor.GetBezierCurvePointByT(t, _beizerCurve[_runningBezierCurveNo].GetChild(0).position,
            _beizerCurve[_runningBezierCurveNo].GetChild(1).position, _beizerCurve[_runningBezierCurveNo].GetChild(2).position, 
            _beizerCurve[_runningBezierCurveNo].GetChild(3).position);
            transform.position = positionToGo;
            yield return new WaitForEndOfFrame();
        }

        _runningBezierCurveNo++;

        if (_runningBezierCurveNo >= _beizerCurve.Length)
        {
            _runningBezierCurveNo = 0;
        }

        StartCoroutine(MoveOnBezierRoute());
        yield break;
    }
}
