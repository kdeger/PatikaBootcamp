public class HealthBooster : BoosterBase
{
    public override void OnBoosterActivated(Player player)
    {
        player.AddHealth(10);
    }
}
