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
        OnSessionInitialized += ActivateSceneOnInitializationComplete;
    }

    void Start()
    {
        StartCoroutine(InitializeSession());
        StartCoroutine(LoadLevelSceneAsync());
    }

    IEnumerator InitializeSession()
    {
        yield return new WaitForSeconds(3f);
        OnSessionInitialized?.Invoke();
        Debug.Log("Session Initialized");
    }

    void ActivateSceneOnInitializationComplete()
    {
        _activateScene = true;
    }

    IEnumerator LoadLevelSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("LevelScene", LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                Debug.Log("Scene Loaded");
                asyncLoad.allowSceneActivation = _activateScene;
            }
            yield return null;
        }
        Debug.Log("Scene Loaded and ready to activate");
    }

    private void StopAnimator()
    {
        _animator.enabled = false;
    }
}
