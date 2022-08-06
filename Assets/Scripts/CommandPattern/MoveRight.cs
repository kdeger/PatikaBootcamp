using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Command
{
    private readonly CommandReceiver _receiver;
    public MoveRight(CommandReceiver receiver)
    {
        _receiver = receiver;
    }
    public override void Execute()
    {
        _receiver.Turn(Direction.Right);
    }

    public override void Undo()
    {
        _receiver.Turn(Direction.Left);
    }
}
