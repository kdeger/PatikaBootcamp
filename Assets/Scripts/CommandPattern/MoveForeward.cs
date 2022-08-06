using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : Command
{
    private readonly CommandReceiver _receiver;
    public MoveForward(CommandReceiver receiver)
    {
        _receiver = receiver;
    }
    public override void Execute()
    {
        _receiver.Move(Direction.Forward);
        // Move the player forward
    }

    public override void Undo()
    {
        _receiver.Move(Direction.Backward);
    }
}
