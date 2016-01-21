using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace AsyncIO.FileSystem
{
    public static class AsyncFile
    {
        #region AppendAllLinesAsync

        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents)
        {
            return AppendAllLinesAsync(path, contents, Encoding.UTF8, CancellationToken.None);
        }

        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding)
        {
            return AppendAllLinesAsync(path, contents, encoding, CancellationToken.None);
        }

        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            return AppendAllLinesAsync(path, contents, Encoding.UTF8, cancellationToken);
        }

        public static async Task AppendAllLinesAsync(string path, [NotNull] IEnumerable<string> contents, [NotNull] Encoding encoding, CancellationToken cancellationToken)
        {
            if (contents == null)
                throw new ArgumentNullException(nameof(contents));
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));
            PathValidator.EnsureCorrectFileSystemPath(path);

            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None, fileBufferSize, true))
            {
                using (var writer = new StreamWriter(fileStream, encoding))
                {
                    foreach (var content in contents)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await writer.WriteLineAsync(content).ConfigureAwait(false);
                    }
                }
            }
        }

        #endregion

        #region AppendAllTextAsync

        public static Task AppendAllTextAsync(string path, string contents)
        {
            return AppendAllTextAsync(path, contents, Encoding.UTF8);
        }

        public static async Task AppendAllTextAsync(string path, [NotNull] string contents, [NotNull] Encoding encoding)
        {
            if (contents == null)
                throw new ArgumentNullException(nameof(contents));
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));
            PathValidator.EnsureCorrectFileSystemPath(path);

            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None, fileBufferSize, true))
            {
                using (var writer = new StreamWriter(fileStream, encoding))
                {
                    await writer.WriteAsync(contents).ConfigureAwait(false);
                }
            }
        }

        #endregion

        #region CopyAsync

        public static Task CopyAsync(string sourceFileName, string destFileName)
        {
            return CopyAsync(sourceFileName, destFileName, false, CancellationToken.None);
        }


        public static Task CopyAsync(string sourceFileName, string destFileName, bool overwrite)
        {
            return CopyAsync(sourceFileName, destFileName, overwrite, CancellationToken.None);
        }

        public static Task CopyAsync(string sourceFileName, string destFileName, CancellationToken cancellationToken)
        {
            return CopyAsync(sourceFileName, destFileName, false, cancellationToken);
        }

        public static async Task CopyAsync(string sourceFileName, string destFileName, bool overwrite, CancellationToken cancellationToken)
        {
            PathValidator.EnsureCorrectFileSystemPath(sourceFileName);
            PathValidator.EnsureCorrectFileSystemPath(destFileName);

            const int fileBufferSize = 4096;
            using (var sourceStream = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read, fileBufferSize, true))
            {
                var fileMode = overwrite ? FileMode.OpenOrCreate : FileMode.CreateNew;
                using (var destStream = new FileStream(destFileName, fileMode, FileAccess.Write, FileShare.None, fileBufferSize, true))
                {
                    const int copyBufferSize = 81920;
                    await sourceStream.CopyToAsync(destStream, copyBufferSize, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
        }

        #endregion

        #region DeleteAsync

        public static async Task DeleteAsync(string path)
        {
            PathValidator.EnsureCorrectFileSystemPath(path);
            if (File.Exists(path))
            {
                const int bufferSize = 4096;
                using (var fileStream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.Delete, bufferSize, true))
                {
                    await fileStream.FlushAsync();
                    File.Delete(path);
                }
            }
        }

        #endregion

        #region MoveAsync

        public static Task MoveAsync(string sourceFileName, string destFileName)
        {
            return MoveAsync(sourceFileName, destFileName, CancellationToken.None);
        }

        public static async Task MoveAsync(string sourceFileName, string destFileName, CancellationToken cancellationToken)
        {
            PathValidator.EnsureCorrectFileSystemPath(sourceFileName);
            PathValidator.EnsureCorrectFileSystemPath(destFileName);

            if (Path.Combine(Path.GetDirectoryName(sourceFileName), sourceFileName) == Path.Combine(Path.GetDirectoryName(destFileName), destFileName))
                return;
            const int fileBufferSize = 4096;
            using (var sourceStream = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read, fileBufferSize, true))
            {
                using (var destStream = new FileStream(destFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None, fileBufferSize, true))
                {
                    const int copyBufferSize = 81920;
                    await sourceStream.CopyToAsync(destStream, copyBufferSize, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            if (!cancellationToken.IsCancellationRequested)
            {
                await DeleteAsync(sourceFileName);
            }
        }

        #endregion

        #region ReadAllBytesAsync

        public static Task<byte[]> ReadAllBytesAsync(string path)
        {
            return ReadAllBytesAsync(path, CancellationToken.None);
        }

        public static async Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken)
        {
            PathValidator.EnsureCorrectFileSystemPath(path);
            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, fileBufferSize, true))
            {
                var length = fileStream.Length;
                if (length > int.MaxValue)
                    throw new IOException("File is greater than 2GB.");
                var bytes = new byte[length];
                await fileStream.ReadAsync(bytes, 0, (int)length, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                return bytes;
            }
        }

        #endregion

        #region ReadAllLinesAsync

        public static Task<string[]> ReadAllLinesAsync(string path)
        {
            return ReadAllLinesAsync(path, Encoding.UTF8, CancellationToken.None);
        }

        public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding)
        {
            return ReadAllLinesAsync(path, encoding, CancellationToken.None);
        }

        public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken)
        {
            return ReadAllLinesAsync(path, Encoding.UTF8, cancellationToken);
        }

        public static async Task<string[]> ReadAllLinesAsync([NotNull] string path, [NotNull] Encoding encoding, CancellationToken cancellationToken)
        {
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));
            PathValidator.EnsureCorrectFileSystemPath(path);

            var lines = new List<string>();
            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, fileBufferSize, true))
            {
                using (var reader = new StreamReader(fileStream, encoding))
                {
                    while (!reader.EndOfStream)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            cancellationToken.ThrowIfCancellationRequested();
                        lines.Add(await reader.ReadLineAsync().ConfigureAwait(false));
                    }
                }
            }
            return lines.ToArray();
        }

        #endregion

        #region ReadAllTextAsync

        public static Task<string> ReadAllTextAsync(string path)
        {
            return ReadAllTextAsync(path, Encoding.UTF8);
        }

        public static async Task<string> ReadAllTextAsync(string path, Encoding encoding)
        {
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));
            PathValidator.EnsureCorrectFileSystemPath(path);

            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, fileBufferSize, true))
            {
                using (var reader = new StreamReader(fileStream, encoding))
                {
                    return await reader.ReadToEndAsync().ConfigureAwait(false);
                }
            }
        }

        #endregion

        #region WriteAllBytesAsync

        public static Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            return WriteAllBytesAsync(path, bytes, CancellationToken.None);
        }

        public static async Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken)
        {
            PathValidator.EnsureCorrectFileSystemPath(path);
            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write, fileBufferSize, true))
            {
                await fileStream.WriteAsync(bytes, 0, bytes.Length, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        #endregion

        #region WriteAllLinesAsync

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents)
        {
            return WriteAllLinesAsync(path, contents, Encoding.UTF8, CancellationToken.None);
        }

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding)
        {
            return WriteAllLinesAsync(path, contents, encoding, CancellationToken.None);
        }

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            return WriteAllLinesAsync(path, contents, Encoding.UTF8, cancellationToken);

        }

        public static async Task WriteAllLinesAsync(string path, [NotNull] IEnumerable<string> contents, [NotNull] Encoding encoding, CancellationToken cancellationToken)
        {
            if (contents == null)
                throw new ArgumentNullException(nameof(contents));
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));
            PathValidator.EnsureCorrectFileSystemPath(path);

            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, fileBufferSize, true))
            {
                using (var writer = new StreamWriter(fileStream, encoding))
                {
                    foreach (var content in contents)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await writer.WriteLineAsync(content).ConfigureAwait(false);
                    }
                }
            }
        }

        #endregion

        #region WriteAllTextAsync

        public static Task WriteAllTextAsync(string path, string contents)
        {
            return WriteAllTextAsync(path, contents, Encoding.UTF8);
        }

        public static async Task WriteAllTextAsync(string path, [NotNull] string contents, [NotNull] Encoding encoding)
        {
            if (contents == null)
                throw new ArgumentNullException(nameof(contents));
            if (encoding == null)
                throw new ArgumentNullException(nameof(encoding));
            PathValidator.EnsureCorrectFileSystemPath(path);

            const int fileBufferSize = 4096;
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, fileBufferSize, true))
            {
                using (var writer = new StreamWriter(fileStream, encoding))
                {
                    await writer.WriteAsync(contents).ConfigureAwait(false);
                }
            }
        }

        #endregion
    }
}