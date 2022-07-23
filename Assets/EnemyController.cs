using UnityEngine;
public class EnemyController : CharacterController
{
    public override void Attack()
    {
        Debug.Log("Attack player");
    }
    public override void Move()
    {
        Debug.Log("Move slowly towards player");
    }
    public override void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage major damage: " + damage);
    }

    public virtual void SearchPlayer()
    {
        Debug.Log("Search player");
    }

    public override void GetBigger()
    {
        Debug.Log("Double size and damage");
    }
}
