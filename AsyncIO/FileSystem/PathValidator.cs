using System;
using System.Collections.Generic;
using System.IO;

namespace AsyncIO.FileSystem
{
    internal static class PathValidator
    {
        /// <summary>
        /// Ensures the correct file system path.
        /// </summary>
        /// <param name="path">The path to file or directory.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <c>null</c></exception>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <remarks>Throws an exception if <paramref name="path"/> is not a correct file system path, otherwise no.</remarks>
        internal static void EnsureCorrectFileSystemPath(string path)
        {
            if (path == null)
                throw new ArgumentNullException($"{nameof(path)} is null.", nameof(path));

            if (string.IsNullOrWhiteSpace(path) || HasSpecifiedChars(path, Path.GetInvalidPathChars()))
            {
                var message =
                    $"{nameof(path)} is a zero-length string, contains only white space, or contains one or more invalid characters as defined by InvalidPathChars.";
                throw new ArgumentException(message, nameof(path));
            }
        }

        private static bool HasSpecifiedChars(string text, char[] chars)
        {
            var charsHashSet = new HashSet<char>(chars);
            for (var i = 0; i < text.Length; ++i)
            {
                if (charsHashSet.Contains(text[i]))
                    return true;
            }
            return false;
        }
    }
}