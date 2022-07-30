using UnityEngine;
public class EnemyMovementController
{
    public void Move()
    {
        //Use navmesh and basic AI to move
        Debug.Log("Move slowly towards player");
    }
}

public interface IGetBigger
{
    void GetBigger();
}
