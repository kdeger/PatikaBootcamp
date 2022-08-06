using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public int Damage;
    public List<IDamageType> DamageType = new List<IDamageType>();

    public void DoAttack(Player enemy)
    {
        foreach (IDamageType damage in DamageType)
        {
            enemy.TakeDamage(damage.DealDamage(Damage, enemy));
        }
    }

    public void AddDamageType(IDamageType damage)
    {
        DamageType.Add(damage);
    }
}
