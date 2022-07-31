using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandClient : MonoBehaviour
{
    private CommandInvoker _invoker;

    private ICommand _command1, _command2, _command3;
    void Start()
    {
        _invoker = new CommandInvoker();
        _command1 = new Command1();
        _command2 = new Command2();
        _command3 = new Command3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _invoker.ExecuteCommand(_command1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _invoker.ExecuteCommand(_command2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _invoker.ExecuteCommand(_command3);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _invoker.ExecuteCommand(_command3);
        }
    }
}
