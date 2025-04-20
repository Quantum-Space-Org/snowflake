using Quantum.Configurator;
using Quantum.Core;


namespace Quantum.Snowflake.Configure
{
    public static class ConfigQuantumSnowflakeExtensions
    {
        public static ConfigQuantumSnowflakeBuilder ConfigQuantumSnowflake(this QuantumServiceCollection collection)
        {
            return new ConfigQuantumSnowflakeBuilder(collection);
        }
    }

    public class ConfigQuantumSnowflakeBuilder
    {
        private readonly QuantumServiceCollection _quantumServiceCollection;
        private IMachineIdGenerator? _machineIdGenerator = null;

        public ConfigQuantumSnowflakeBuilder(QuantumServiceCollection collection) 
            => _quantumServiceCollection = collection;
        
        public ConfigQuantumSnowflakeBuilder RegisterMachineIdGenerator(IMachineIdGenerator machineIdGenerator)
        {
            _machineIdGenerator = machineIdGenerator;
            return this;
        }

        public ConfigQuantumSnowflakeBuilder RegisterSnowflakeIdConfig(SnowflakeIdConfig config)
        {
            SnowflakeIdGenerator.Set(new TimeStampIdGenerator(config.StartingPoint, new DateTimeProvider()), MachineIdGenerator(), new Sequencer(config.SequenceLength));

            return this;


            IMachineIdGenerator MachineIdGenerator()
            {
                return _machineIdGenerator ?? new DefaultMachineIdGenerator(config.LengthOfComputerId, config.InstanceId);
            }
        }

        public ConfigQuantumSnowflakeBuilder ConfigDefaultSnowflakeIdGenerator()
        {
            SnowflakeIdGenerator.Set(TimeStampIdGenerator.Default(), MachineIdGenerator(), Sequencer.Default());

            return this;

            IMachineIdGenerator MachineIdGenerator()
            {
                return _machineIdGenerator ?? IMachineIdGenerator.Default();
            }
        }

        public QuantumServiceCollection and() 
            => _quantumServiceCollection;
    }
}
