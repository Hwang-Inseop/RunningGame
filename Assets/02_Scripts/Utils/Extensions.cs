using RunningGame.Managers;
using System;

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
                "gemYellow"     => "Gem",
                "gemBlue"       => "Gem",
                "hud_heartHalf" => "HalfHealthPotion",
                "hud_heartFull" => "HealthPotion",
                _               => throw new System.Exception("Invalid object name")
            };
        }

        public static string GetSoundKey(this SoundType soundType)
        {
            return soundType switch
            {
                SoundType.TitleBgm    => "",
                SoundType.LobbyBgm    => "",
                SoundType.MainBgm     => "",
                SoundType.CoinSfx     => "CoinCollect",
                SoundType.JumpSfx     => "",
                SoundType.SlideSfx    => "",
                SoundType.HitSfx      => "",
                SoundType.GameOverSfx => "",
                SoundType.ButtonSfx   => "MouseButton",
                _                     => throw new ArgumentOutOfRangeException(nameof(soundType), soundType, null)
            };
        }
    }
}