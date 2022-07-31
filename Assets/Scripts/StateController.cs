using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private StateContext _stateContext;
    private IState _state1, _state2, _state3;
    // Start is called before the first frame update
    void Start()
    {
        _stateContext = new StateContext();
        _state1 = gameObject.AddComponent<State1>();
        _state2 = new State2();
        _state3 = new State3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _stateContext.Transition(_state1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _stateContext.Transition(_state2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _stateContext.Transition(_state3);
        }
    }
}
