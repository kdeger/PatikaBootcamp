using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class StateContext
{
    public IState CurrentState { get; set; }
    public void Transition(IState state)
    {
        CurrentState = state;
        CurrentState.Handle(this);
    }
}

public interface IState
{
    void Handle(StateContext context);
}

public class State1 : MonoBehaviour, IState
{
    private StateContext _context;
    
    public void Handle(StateContext context)
    {
        _context = context;
        Debug.Log("State1");
        StartCoroutine(WaitAndTransition());
    }

    IEnumerator WaitAndTransition()
    {
        yield return new WaitForSeconds(2);

        _context.Transition(new State2());
    }

}

public class State2 : MonoBehaviour, IState
{
    public void Handle(StateContext context)
    {
        Debug.Log("State2");
    }
}

public class State3 : MonoBehaviour, IState
{
    public void Handle(StateContext context)
    {
        Debug.Log("State3");
    }
}
