using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AsyncIO.FileSystem
{
    internal static class PathValidator
    {
        internal static void EnsureCorrectFileSystemPath(string path)
        {
            var invalidPathChars = Path.GetInvalidPathChars();
            if (string.IsNullOrWhiteSpace(path) || path.Any(invalidPathChars.Contains))
            {
                var message =
                    $"{nameof(path)} is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars.";
                throw new ArgumentException(message, nameof(path));
            }
        }
    }
}