using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandClient : MonoBehaviour
{
    private CommandInvoker _invoker;
    private CommandReceiver _receiver;
    private Command _moveForward, _moveRight, _moveLeft, _moveBackward;
    private void Start()
    {
        _invoker = gameObject.AddComponent<CommandInvoker>();
        _receiver = GameObject.FindObjectOfType<CommandReceiver>();
        _moveForward = new MoveForward(_receiver);
        _moveRight = new MoveRight(_receiver);
        _moveLeft = new MoveLeft(_receiver);
        _moveBackward = new MoveBackward(_receiver);

        _receiver.ResetPosition();
        _invoker.Record();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _invoker.ExecuteCommand(_moveForward);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _invoker.ExecuteCommand(_moveRight);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _invoker.ExecuteCommand(_moveLeft);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _invoker.ExecuteCommand(_moveBackward);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _invoker.UndoLastCommand();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _receiver.ResetPosition();
            _invoker.Record();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _invoker.StopRecord();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _receiver.ResetPosition();
            _invoker.Replay();
        }
    }
}
