using System;
using Quantum.Core;

namespace Quantum.Snowflake;

internal class TimeStampIdGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private DateTime StartingPoint { get; }
    static readonly DateTime DefaultStartingPoint = new DateTime(2023, 01, 01, 0, 0, 1, 0, 0, DateTimeKind.Utc);

    internal static TimeStampIdGenerator Default()
        => new TimeStampIdGenerator(DefaultStartingPoint, new DateTimeProvider());

    internal TimeStampIdGenerator(DateTime startingPoint, IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
        StartingPoint = startingPoint;
    }

    internal string Get()
    {
        var dateTime = _dateTimeProvider.UtcDateTimeNow();
        var ticks = (dateTime - StartingPoint).Milliseconds;

        return Convert.ToString(ticks, 2)
            .AddPaddingToTheLeft(41);
    }


}