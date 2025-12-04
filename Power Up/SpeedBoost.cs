using System;
using System.Threading.Tasks;

public class SpeedBoost
{
    private float boostMultiplier;
    private int durationMilliseconds;

    public SpeedBoost(float multiplier = 2.0f, int durationSeconds = 4)
    {
        boostMultiplier = multiplier;
        durationMilliseconds = durationSeconds * 1000;
    }

    public async Task ActivateAsync(Player player)
    {
        if (player == null) return;

        player.IsInvincible = true;
        player.Speed *= boostMultiplier;

        await Task.Delay(durationMilliseconds);

        player.IsInvincible = false;
        player.Speed /= boostMultiplier;
    }
}




