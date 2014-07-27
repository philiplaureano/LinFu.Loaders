using System;

namespace LinFu.Loaders
{
    /// <summary>
    /// Adds helper methods that return information about the current
    /// runtime.
    /// </summary>
    public sealed class Runtime
    {
        /// <summary>
        /// Gets a value indicating if the application is
        /// currently running on the Mono platform.
        /// </summary>
        public static bool IsRunningOnMono
        {
            get { return Type.GetType("Mono.Runtime", false) != null; }
        }
    }
}