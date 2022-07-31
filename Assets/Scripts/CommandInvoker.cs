using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{

    private SortedList<float, ICommand> _commands = new SortedList<float, ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commands.Add(Time.time, command);
    }

    public void ReverseCommand(ICommand command)
    {
        command.Reverse();
        _commands.Add(Time.time, command);
    }

}

public interface ICommand
{
    void Execute();
    void Reverse();
}

public class Command1 : ICommand
{
    public void Execute()
    {
        Debug.Log("Command1");
    }

    public void Reverse()
    {
        Debug.Log("Command1 Reverse");
    }
}

public class Command2 : ICommand
{
    public void Execute()
    {
        Debug.Log("Command2");
    }

    public void Reverse()
    {
        Debug.Log("Command2 Reverse");
    }
}

public class Command3 : ICommand
{
    public void Execute()
    {
        Debug.Log("Command3");
    }

    public void Reverse()
    {
        Debug.Log("Command3 Reverse");
    }
}
