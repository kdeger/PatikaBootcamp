using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _recordTime;
    private float _replayTime;
    private SortedList<float, Command> _commands = new SortedList<float, Command>();
    public void ExecuteCommand(Command command)
    {
        command.Execute();
        _commands.Add(_recordTime, command);
        Debug.Log("Recorded command at time: " + _recordTime);
    }

    public void UndoLastCommand()
    {
        var lastCommand = _commands.Last();
        lastCommand.Value.Undo();
        //_commands.Add(_recordTime, lastCommand.Value);
    }

    private void FixedUpdate()
    {
        if (_isRecording)
            _recordTime += Time.fixedDeltaTime;

        if (_isReplaying)
        {
            _replayTime += Time.fixedDeltaTime;

            if (_commands.Any())
            {
                if (Mathf.Approximately(_replayTime, _commands.Keys[0]))
                {
                    _commands.Values[0].Execute();
                    _commands.RemoveAt(0);
                }
            }
            else
                _isReplaying = false;
        }
    }

    public void Record()
    {
        _isRecording = true;
        _isReplaying = false;
        _recordTime = 0f;
    }

    public void StopRecord()
    {
        _isRecording = false;
        _isReplaying = false;
    }

    public void Replay()
    {
        _isRecording = false;
        _isReplaying = true;
        _replayTime = 0f;
        _recordTime = 0f;
    }
}
