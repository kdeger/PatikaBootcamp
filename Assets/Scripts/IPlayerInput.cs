using UnityEngine;
public interface IPlayerInput
{
    float Vertical { get; }
    float Horizontal { get; }
    Vector3 MousePosition { get; }
}
