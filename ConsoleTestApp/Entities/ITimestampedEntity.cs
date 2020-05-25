using System;

namespace ConsoleTestApp.Entities
{
    public interface ITimestampedEntity
    {
        DateTime? Timestamp { get; set; }
    }
}
