public class HealthBooster : BoosterBase
{
    public override void OnBoosterActivated(Player player)
    {
        int healingAmount = 10;

        if (player.IsDoubleBoosterActive)
            healingAmount *= 2;

        player.Heal(healingAmount);
    }
}
