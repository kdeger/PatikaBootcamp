using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackward : Command
{
    private readonly CommandReceiver _receiver;
    public MoveBackward(CommandReceiver receiver)
    {
        _receiver = receiver;
    }
    public override void Execute()
    {
        _receiver.Move(Direction.Backward);
    }

    public override void Undo()
    {
        _receiver.Move(Direction.Forward);
    }
}
