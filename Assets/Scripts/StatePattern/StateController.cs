using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    IState _initState, _playState, _pauseState;
    // Start is called before the first frame update
    void Start()
    {
        //_stateContext = new StateContext();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            StateContext.Transition(_initState);
    }
}
