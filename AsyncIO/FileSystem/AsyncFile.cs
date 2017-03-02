using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncIO.FileSystem
{
    /// <summary>
    /// Provides static methods for the asynchronous creation, copying, deletion, moving, writing and reading of a single file.
    /// </summary>
    public static class AsyncFile
    {
        #region AppendAllLinesAsync

        /// <summary>
        /// Appends lines asynchronously to a file, and then closes the file. 
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="path"/> or <paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/> exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents)
        {
            return AppendAllLinesAsync(path, contents, Encoding.UTF8, CancellationToken.None);
        }

        /// <summary>
        /// Appends lines asynchronously to a file by using a specified encoding, and then closes the file. 
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="path"/>, <paramref name="contents"/>, or <paramref name="encoding"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/> exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding)
        {
            return AppendAllLinesAsync(path, contents, encoding, CancellationToken.None);
        }

        /// <summary>
        /// Appends lines asynchronously to a file by using a specified encoding, and then closes the file, and monitors cancellation requests. 
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="path"/> or <paramref name="contents"/>.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/> exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            return AppendAllLinesAsync(path, contents, Encoding.UTF8, cancellationToken);
        }

        /// <summary>
        /// Appends lines asynchronously to a file by using a specified encoding, and then closes the file, and monitors cancellation requests. 
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the lines to. The file is created if it doesn't already exist.</param>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="path"/>, <paramref name="contents"/>, or <paramref name="encoding"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/> exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static async Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken)
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

        /// <summary>
        /// Asynchronously appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <remarks>
        /// <para>Given a string and a file path, this method opens the specified file, appends the string to the end of the file using the specified encoding, and then closes the file. The file handle is guaranteed to be closed by this method, even if exceptions are raised.</para>
        /// <para>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</para>
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="path"/> or <paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/> exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllTextAsync(string path, string contents)
        {
            return AppendAllTextAsync(path, contents, Encoding.UTF8);
        }

        /// <summary>
        /// Asynchronously appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="path">The file to append the specified string to.</param>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <remarks>
        /// <para>Given a string and a file path, this method opens the specified file, appends the string to the end of the file using the specified encoding, and then closes the file. The file handle is guaranteed to be closed by this method, even if exceptions are raised.</para>
        /// <para>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</para>
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="path"/>, <paramref name="contents"/>, or <paramref name="encoding"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="PathTooLongException"><paramref name="path"/> exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static async Task AppendAllTextAsync(string path, string contents, Encoding encoding)
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

        /// <summary>
        /// Asynchronously copies an existing file to a new file, and monitors cancellation requests. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// 
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="sourceFileName"/> and <paramref name="destFileName"/> parameters can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para><paramref name="sourceFileName"/> or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="sourceFileName"/> or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="sourceFileName"/> was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task CopyAsync(string sourceFileName, string destFileName)
        {
            return CopyAsync(sourceFileName, destFileName, false, CancellationToken.None);
        }


        /// <summary>
        /// Asynchronously copies an existing file to a new file. Overwriting a file of the same name is allowed.
        /// </summary>
        /// 
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite"><c>true</c> if the destination file can be overwritten; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="sourceFileName"/> and <paramref name="destFileName"/> parameters can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para><paramref name="sourceFileName"/> or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="sourceFileName"/> or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists and <paramref name="overwrite"/> is <c>false</c>.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="sourceFileName"/> was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task CopyAsync(string sourceFileName, string destFileName, bool overwrite)
        {
            return CopyAsync(sourceFileName, destFileName, overwrite, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously copies an existing file to a new file, and monitors cancellation requests. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// 
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="sourceFileName"/> and <paramref name="destFileName"/> parameters can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para><paramref name="sourceFileName"/> or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="sourceFileName"/> or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="sourceFileName"/> was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task CopyAsync(string sourceFileName, string destFileName, CancellationToken cancellationToken)
        {
            return CopyAsync(sourceFileName, destFileName, false, cancellationToken);
        }

        /// <summary>
        /// Asynchronously copies an existing file to a new file, and monitors cancellation requests. Overwriting a file of the same name is allowed.
        /// </summary>
        /// 
        /// <param name="sourceFileName">The file to copy.</param>
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite"><c>true</c> if the destination file can be overwritten; otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="sourceFileName"/> and <paramref name="destFileName"/> parameters can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para><paramref name="sourceFileName"/> or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either <paramref name="sourceFileName"/> or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists and <paramref name="overwrite"/> is <c>false</c>.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException"><paramref name="sourceFileName"/> was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
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

        /// <summary>
        /// Asynchronously deletes the specified file.
        /// </summary>
        /// 
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        /// <remarks>
        /// <para>
        /// Specify a file name with any relative or absolute path information for the <paramref name="path"/> parameter. 
        /// Wildcard characters cannot be included. Relative path information is interpreted as relative to the current working directory. 
        /// To obtain the current working directory, see <see cref="Directory.GetCurrentDirectory"/>.
        /// </para>
        /// <para>If the file to be deleted does not exist, no exception is thrown.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para>The specified file is in use.</para>
        /// <para>-or-</para>
        /// <para>There is an open handle on the file, and the operating system is Windows XP or earlier. This open handle can result from enumerating directories and files.</para>
        /// </exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="path"/> specifies a read-only file.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// <para>-or-</para>
        /// <para>The file is an executable file that is in use.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> is a directory.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
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

        /// <summary>
        /// Asynchronously moves a specified file to a new location, providing the option to specify a new file name.
        /// </summary>
        /// 
        /// <param name="sourceFileName">The name of the file to move. Can include a relative or absolute path.</param>
        /// <param name="destFileName">The new path and name for the file.</param>
        /// 
        /// <remarks>
        /// <para>
        /// This method works across disk volumes, and it does not throw an exception if the source and destination are the same. 
        /// Note that if you attempt to replace a file by moving a file of the same name into that directory, you get an <see cref="IOException"/>. 
        /// You cannot use the Move method to overwrite an existing file.
        /// </para>
        /// <para>
        /// The <paramref name="sourceFileName"/> and <paramref name="destFileName"/> arguments can include relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// To obtain the current working directory, see <see cref="Directory.GetCurrentDirectory"/>.
        /// </para>
        /// <para>If you try to move a file across disk volumes and that file is in use, the file is copied to the destination, but it is not deleted from the source.</para>
        /// </remarks>
        /// 
        /// <exception cref="IOException">
        /// <para>The destination file already exists.</para>
        /// <para>-or-</para>
        /// <para><paramref name="sourceFileName"/> was not found.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="sourceFileName"/> or <paramref name="destFileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="sourceFileName"/> or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="NotSupportedException"><paramref name="sourceFileName"/> or <paramref name="destFileName"/> is in an invalid format.</exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task MoveAsync(string sourceFileName, string destFileName)
        {
            return MoveAsync(sourceFileName, destFileName, CancellationToken.None);
        }


        /// <summary>
        /// Asynchronously moves a specified file to a new location, providing the option to specify a new file name, and monitors cancellation requests.
        /// </summary>
        /// 
        /// <param name="sourceFileName">The name of the file to move. Can include a relative or absolute path.</param>
        /// <param name="destFileName">The new path and name for the file.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <remarks>
        /// <para>
        /// This method works across disk volumes, and it does not throw an exception if the source and destination are the same. 
        /// Note that if you attempt to replace a file by moving a file of the same name into that directory, you get an <see cref="IOException"/>. 
        /// You cannot use the Move method to overwrite an existing file.
        /// </para>
        /// <para>
        /// The <paramref name="sourceFileName"/> and <paramref name="destFileName"/> arguments can include relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// To obtain the current working directory, see <see cref="Directory.GetCurrentDirectory"/>.
        /// </para>
        /// <para>If you try to move a file across disk volumes and that file is in use, the file is copied to the destination, but it is not deleted from the source.</para>
        /// </remarks>
        /// 
        /// <exception cref="IOException">
        /// <para>The destination file already exists.</para>
        /// <para>-or-</para>
        /// <para><paramref name="sourceFileName"/> was not found.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="sourceFileName"/> or <paramref name="destFileName"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="sourceFileName"/> or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="sourceFileName"/> or <paramref name="destFileName"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="NotSupportedException"><paramref name="sourceFileName"/> or <paramref name="destFileName"/> is in an invalid format.</exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
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

        /// <summary>
        /// Opens a binary file, asynchronously reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// 
        /// <remarks>Given a file path, this method opens the file, reads the contents of the file into a byte array, and then closes the file.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// 
        /// <returns>A task with a byte array containing the contents of the file.</returns>
        public static Task<byte[]> ReadAllBytesAsync(string path)
        {
            return ReadAllBytesAsync(path, CancellationToken.None);
        }

        /// <summary>
        /// Opens a binary file, asynchronously reads the contents of the file into a byte array, and then closes the file, and monitors cancellation requests.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <remarks>Given a file path, this method opens the file, reads the contents of the file into a byte array, and then closes the file.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// 
        /// <returns>A task with a byte array containing the contents of the file.</returns>
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

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// 
        /// <returns>A task with a string array containing all lines of the file.</returns>
        /// 
        /// <remarks>
        /// <para>
        /// This method opens a file, reads each line of the file, and then adds each line as an element of a string array. It then closes the file. 
        /// A line is defined as a sequence of characters followed by a carriage return ('\r'), a line feed ('\n'), or a carriage return immediately followed by a line feed. 
        /// The resulting string does not contain the terminating carriage return and/or line feed.
        /// </para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string[]> ReadAllLinesAsync(string path)
        {
            return ReadAllLinesAsync(path, Encoding.UTF8, CancellationToken.None);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// 
        /// <returns>A task with a string array containing all lines of the file.</returns>
        /// 
        /// <remarks>
        /// <para>
        /// This method opens a file, reads each line of the file, and then adds each line as an element of a string array. It then closes the file. 
        /// A line is defined as a sequence of characters followed by a carriage return ('\r'), a line feed ('\n'), or a carriage return immediately followed by a line feed. 
        /// The resulting string does not contain the terminating carriage return and/or line feed.
        /// </para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="encoding"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding)
        {
            return ReadAllLinesAsync(path, encoding, CancellationToken.None);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file, and monitors cancellation requests.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>A task with a string array containing all lines of the file.</returns>
        /// 
        /// <remarks>
        /// <para>
        /// This method opens a file, reads each line of the file, and then adds each line as an element of a string array. It then closes the file. 
        /// A line is defined as a sequence of characters followed by a carriage return ('\r'), a line feed ('\n'), or a carriage return immediately followed by a line feed. 
        /// The resulting string does not contain the terminating carriage return and/or line feed.
        /// </para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken)
        {
            return ReadAllLinesAsync(path, Encoding.UTF8, cancellationToken);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file with the specified encoding, and then closes the file, and monitors cancellation requests.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>A task with a string array containing all lines of the file.</returns>
        /// 
        /// <remarks>
        /// <para>
        /// This method opens a file, reads each line of the file, and then adds each line as an element of a string array. It then closes the file. 
        /// A line is defined as a sequence of characters followed by a carriage return ('\r'), a line feed ('\n'), or a carriage return immediately followed by a line feed. 
        /// The resulting string does not contain the terminating carriage return and/or line feed.
        /// </para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="encoding"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static async Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken)
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

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// 
        /// <returns>A task with a string containing all lines of the file.</returns>
        /// 
        /// <remarks>
        /// <para>
        /// This method opens a file, reads each line of the file, and then adds each line as an element of a string. It then closes the file. 
        /// A line is defined as a sequence of characters followed by a carriage return ('\r'), a line feed ('\n'), or a carriage return immediately followed by a line feed. 
        /// The resulting string does not contain the terminating carriage return and/or line feed.
        /// </para>
        /// <para>The file handle is guaranteed to be closed by this method, even if exceptions are raised.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string> ReadAllTextAsync(string path)
        {
            return ReadAllTextAsync(path, Encoding.UTF8);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file with the specified encoding, and then closes the file.
        /// </summary>
        /// 
        /// <param name="path">The file to open for reading.</param>
        /// <param name="encoding">The encoding applied to the contents of the file.</param>
        /// 
        /// <returns>A task with a string containing all lines of the file.</returns>
        /// 
        /// <remarks>
        /// <para>
        /// This method opens a file, reads each line of the file, and then adds each line as an element of a string. It then closes the file. 
        /// A line is defined as a sequence of characters followed by a carriage return ('\r'), a line feed ('\n'), or a carriage return immediately followed by a line feed. 
        /// The resulting string does not contain the terminating carriage return and/or line feed.
        /// </para>
        /// <para>The file handle is guaranteed to be closed by this method, even if exceptions are raised.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="encoding"/> is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in <paramref name="path"/> is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in <paramref name="path"/> was not found.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
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

        /// <summary>
        /// Creates a new file, asynchronously writes the specified byte array to the file, and then closes the file. 
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>Given a byte array and a file path, this method opens the specified file, writes the contents of the byte array to the file, and then closes the file.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="bytes"/> is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            return WriteAllBytesAsync(path, bytes, CancellationToken.None);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes the specified byte array to the file, and then closes the file, and monitors cancellation requests. 
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="bytes">The bytes to write to the file.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>Given a byte array and a file path, this method opens the specified file, writes the contents of the byte array to the file, and then closes the file.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="bytes"/> is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
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

        /// <summary>
        /// Creates a new file, asynchronously writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="contents"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents)
        {
            return WriteAllLinesAsync(path, contents, Encoding.UTF8, CancellationToken.None);
        }

        /// <summary>
        /// Creates a new file by using the specified encoding, asynchronously writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>, <paramref name="contents"/> or <paramref name="encoding"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding)
        {
            return WriteAllLinesAsync(path, contents, encoding, CancellationToken.None);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes a collection of strings to the file, and then closes the file, and monitors cancellation requests.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="contents"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            return WriteAllLinesAsync(path, contents, Encoding.UTF8, cancellationToken);

        }

        /// <summary>
        /// Creates a new file by using the specified encoding, asynchronously writes a collection of strings to the file, and then closes the file, and monitors cancellation requests.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>, <paramref name="contents"/> or <paramref name="encoding"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static async Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken)
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

        /// <summary>
        /// Creates a new file, asynchronously writes the specified string to the file, and then closes the file.
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="contents"/>is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllTextAsync(string path, string contents)
        {
            return WriteAllTextAsync(path, contents, Encoding.UTF8);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes the specified string to the file using the specified encoding, and then closes the file.
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="path">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException"><paramref name="path"/> is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/>, <paramref name="contents"/> or <paramref name="encoding"/> is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException"><paramref name="path"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><paramref name="path"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para><paramref name="path"/> specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><paramref name="path"/> specified a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static async Task WriteAllTextAsync(string path, string contents, Encoding encoding)
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