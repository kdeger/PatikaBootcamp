using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandReceiver : MonoBehaviour
{
    [SerializeField] float _moveForwardMultiplier = 1f;
    [SerializeField] float _turnMultiplier = 1f;

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                transform.Translate(Vector3.forward * _moveForwardMultiplier);
                break;
            case Direction.Backward:
                transform.Translate(Vector3.back * _moveForwardMultiplier);
                break;
        }
    }

    public void Turn(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                transform.Translate(Vector3.left * _turnMultiplier);
                break;
            case Direction.Right:
                transform.Translate(Vector3.right * _turnMultiplier);
                break;
        }
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }
}

public enum Direction
{
    Left,
    Right,
    Forward,
    Backward
}
