using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationCurveDemo : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float _animTime;
    // Start is called before the first frame update
    private GameObject _testObject;

    public event Action<GameObject> OnAnimationFinished;
    void Start()
    {
        StartCoroutine(AnimationCurveCor());
        CharacterController characterController = new CharacterNavMeshMovementController();
        characterController.Move(Vector3.zero);
    }

    IEnumerator AnimationCurveCor()
    {
        float currentTime = 0f;
        _animationCurve = new AnimationCurve(new Keyframe(0f, transform.position.x), new Keyframe(0.5f, transform.position.x + 10), new Keyframe(1f, transform.position.x + 15));


        _animationCurve.SmoothTangents(0, 0.25f);
        _animationCurve.SmoothTangents(1, 1f);
        _animationCurve.SmoothTangents(2, 0.25f);
        while (currentTime < _animTime)
        {
            transform.position = new Vector2(_animationCurve.Evaluate(currentTime / _animTime), transform.position.y);
            currentTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        OnAnimationFinished?.Invoke(_testObject);
    }
}
