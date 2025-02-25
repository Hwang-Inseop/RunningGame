using RunningGame.Managers;

namespace RunningGame.Utils
{
    public static class Extensions
    {
        public static string GetPoolKey(this string name)
        {
            return name switch
            {
                "coinSilver"    => "Coin_Silver",
                "coinBronze"    => "Coin_Bronze",
                "coinGold"      => "Coin_Gold",
                "gemBlue"       => "Gem",
                "gemYellow"       => "Gem",
                "hud_heartHalf" => "HalfHealthPotion",
                "hud_heartFull" => "HealthPotion",
                _               => throw new System.Exception($"Invalid object name {name}")
            };
        }
    }
}