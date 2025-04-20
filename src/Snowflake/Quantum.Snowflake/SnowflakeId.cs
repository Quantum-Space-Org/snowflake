using System;

namespace Quantum.Snowflake;

public class SnowflakeId
{
    public string TimeStamp { get; }
    public string InstanceId { get; }
    public string SequenceId { get; }

    public SnowflakeId(string timeStamp, string instanceId, string sequenceId)
    {
        TimeStamp = timeStamp;
        InstanceId = instanceId;
        SequenceId = sequenceId;
    }

    public string Get() => $"{TimeStamp}{InstanceId}{SequenceId}";
    public long ToLong() =>
        Convert.ToInt64(Get(), 2);
}