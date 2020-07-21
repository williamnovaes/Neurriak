using System;
using System.Diagnostics;

public static class DateUtil {
    public static long CurrentTimeNano() {
        double timestamp = Stopwatch.GetTimestamp();
        double nano = (1000000000 * timestamp) / Stopwatch.Frequency;
        return (long) nano;
    }

    public static long CurrentTimeMillis() {
        return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
    }
}