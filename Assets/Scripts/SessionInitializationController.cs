using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionInitializationController : MonoBehaviour
{
    public static event System.Action OnSessionInitialized;
    [SerializeField] Animator _animator;
    [SerializeField] bool _activateScene;

    private void Awake()
    {
        OnSessionInitialized += StopAnimator;
    }

    void Start()
    {
        StartCoroutine(InitializeSession());
        StateContext.Transition(new InitState());
    }

    IEnumerator InitializeSession()
    {
        yield return new WaitForSeconds(3f);
        OnSessionInitialized?.Invoke();
        Debug.Log("Session Initialized");
    }


    private void StopAnimator()
    {
        _animator.enabled = false;
    }
}
