namespace Quantum.Snowflake;

internal static class PaddingExtensions
{
    internal static string AddPaddingToTheLeft(this string result, short length)
    {
        var resultLength = result.Length;

        if (result.Length >= length) return result;

        for (var i = 0; i < length - resultLength; i++)
            result = "0" + result;

        return result;
    }
}