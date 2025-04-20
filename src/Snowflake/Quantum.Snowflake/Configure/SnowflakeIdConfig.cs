using System;

namespace Quantum.Snowflake.Configure;

public class SnowflakeIdConfig
{
    public int InstanceId { get; set; } = 1;
    public int SequenceLength { get; set; } = 10;
    public int LengthOfComputerId { get; set; } = 12;
    public int SequenceThreshold { get; set; } = 4095;
    public DateTime StartingPoint { get; set; }= new(2023, 01, 01, 0, 0, 1, 0, 0, DateTimeKind.Utc);


    public SnowflakeIdConfig Default() => new();

    public static SnowflakeIdConfigBuilder Builder => new();
}

public class SnowflakeIdConfigBuilder
{
    public SnowflakeIdConfigBuilder WithInstanceId(int instanceId)
    {
        return this;
    }

    public SnowflakeIdConfigBuilder WithSequenceLength(int sequenceLength)
    {
        return this;
    }

    public SnowflakeIdConfigBuilder WithLengthOfComputerId(int lengthOfComputerId)
    {
        return this;
    }

    public SnowflakeIdConfigBuilder WithSequenceThreshold(int sequenceThreshold)
    {
        return this;
    }
    public SnowflakeIdConfigBuilder WithStartingPoint(DateTime startingPoint)
    {
        return this;
    }

    public SnowflakeIdConfig Build()
    {
        return new SnowflakeIdConfig();
    }
}