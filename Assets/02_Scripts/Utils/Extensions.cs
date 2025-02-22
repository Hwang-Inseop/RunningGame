using RunningGame.Managers;

namespace RunningGame.Utils
{
    public static class Extensions
    {
        public static string GetName(this PatternType patternType)
        {
            return patternType switch
            {
                PatternType.Pattern1 => "Pattern1",
                PatternType.Pattern2 => "Pattern2",
                PatternType.Pattern3 => "Pattern3",
                PatternType.Pattern4 => "Pattern4",
                PatternType.Pattern5 => "Pattern5",
                _ => throw new System.ArgumentOutOfRangeException(nameof(patternType), patternType, null)
            };
        }
        
    }
}