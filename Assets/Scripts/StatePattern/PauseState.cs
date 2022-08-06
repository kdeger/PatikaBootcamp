using UnityEngine;

public class PauseState : IState
{
    public void Handle()
    {
        Time.timeScale = 0f;
        Debug.Log("PauseState");
    }
    
}
