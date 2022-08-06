using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : Command
{
    private readonly CommandReceiver _receiver;
    public MoveLeft(CommandReceiver receiver)
    {
        _receiver = receiver;
    }
    public override void Execute()
    {
        _receiver.Turn(Direction.Left);
    }

    public override void Undo()
    {
        _receiver.Turn(Direction.Right);
    }
}

