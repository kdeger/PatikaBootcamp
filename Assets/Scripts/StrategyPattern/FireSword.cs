public class FireSword : WeaponBase
{
    public FireSword()
    {
        Damage = 10;
        DamageType.Add(new FireDamage());
    }
    
}