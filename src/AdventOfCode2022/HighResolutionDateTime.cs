using System;
using System.Runtime.InteropServices;

namespace AdventOfCode2022
{
    public static partial class HighResolutionDateTime
    {
        public static bool IsAvailable { get; private set; }

        [LibraryImport("Kernel32.dll")]
        private static partial void GetSystemTimePreciseAsFileTime(out long filetime);

        public static DateTime UtcNow
        {
            get
            {
                if (!IsAvailable)
                {
                    throw new InvalidOperationException(
                        "High resolution clock isn't available.");
                }

                GetSystemTimePreciseAsFileTime(out var filetime);

                return DateTime.FromFileTimeUtc(filetime);
            }
        }

        static HighResolutionDateTime()
        {
            try
            {
                GetSystemTimePreciseAsFileTime(out var filetime);
                IsAvailable = true;
            }
            catch (EntryPointNotFoundException)
            {
                // Not running Windows 8 or higher.
                IsAvailable = false;
            }
        }
    }
}