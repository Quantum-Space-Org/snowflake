using System;

namespace Quantum.Snowflake;

internal class Sequencer
{
    private const int Threshold = 4095;
    private int _current = -1;
    private readonly int _length;

    private const int DefaultSequenceLength = 12;
    internal static Sequencer Default() => new Sequencer(DefaultSequenceLength);

    public Sequencer(int length)
        => _length = length;

    public string Next()
    {
        _current++;

        CheckThreshold();

        return AddPadding(Convert.ToString(_current, 2));
    }

    private void CheckThreshold()
    {
        if (_current > Threshold)
        {
            _current = 0;
        }
    }

    private string AddPadding(string result)
        => result.AddPaddingToTheLeft((short)_length);
}