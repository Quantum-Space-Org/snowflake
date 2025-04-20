namespace Quantum.Snowflake;

public class SnowflakeIdGenerator
{
    private static IMachineIdGenerator _machineIdGenerator = IMachineIdGenerator.Default();
    private static Sequencer _sequencer = Sequencer.Default();
    private static TimeStampIdGenerator _timeStampIdGenerator = TimeStampIdGenerator.Default();

    internal static void  Set(TimeStampIdGenerator timeStampIdGenerator,
        IMachineIdGenerator machineIdGenerator,
        Sequencer sequencer)
    {
        _machineIdGenerator = machineIdGenerator;
        _sequencer = sequencer;
        _timeStampIdGenerator = timeStampIdGenerator;
    }

    public static SnowflakeId New()
        => new(_timeStampIdGenerator.Get()
            , _machineIdGenerator.GetInstanceId()
            , _sequencer.Next());
}