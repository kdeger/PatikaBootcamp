using UnityEngine;
public interface IMover
{
    void Tick();
}

public interface IMousePositionToWorldPosition
{
    Vector3 MousePositionToWorldPosition(Vector3 mousePosition);
}
