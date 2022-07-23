using UnityEngine;
public class MeleeEnemyController : EnemyController
{
    public override void Attack()
    {
        Debug.Log("Attack player from close range");
    }
    public override void SearchPlayer()
    {
        Debug.Log("Search player melee");
    }
}
