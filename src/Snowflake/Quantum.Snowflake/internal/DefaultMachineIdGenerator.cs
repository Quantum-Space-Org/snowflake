using System;

namespace Quantum.Snowflake;

public interface IMachineIdGenerator
{
    string GetInstanceId();
    static IMachineIdGenerator Default()
    {
        const int DefaultMachineLength = 10;

        return new DefaultMachineIdGenerator(DefaultMachineLength, 1);
    }
}

internal class DefaultMachineIdGenerator : IMachineIdGenerator
{
    private readonly int _lengthOfBinaryNumber;
    private readonly int _instanceId;

    public DefaultMachineIdGenerator(int lengthOfBinaryNumber, int instanceId)
    {
        _lengthOfBinaryNumber = lengthOfBinaryNumber;
        _instanceId = instanceId;
    }

    public string GetInstanceId()
    {
        var result = Convert.ToString(_instanceId, 2);
        result = AddPadding(result);

        return result;
    }

    private string AddPadding(string result)
        => result.AddPaddingToTheLeft((short)_lengthOfBinaryNumber);
}