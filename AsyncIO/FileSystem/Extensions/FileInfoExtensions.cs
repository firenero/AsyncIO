using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
#pragma warning disable 1573

namespace AsyncIO.FileSystem.Extensions
{
    /// <summary>
    /// Provides async extension method for <see cref="FileInfo"/>.
    /// </summary>
    public static class FileInfoExtensions
    {
        #region AppendAllLinesAsync

        /// <summary>
        /// Appends lines asynchronously to a file, and then closes the file. 
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="contents">The lines to append to the file.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">File path specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>File path is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents)
        {
            return AsyncFile.AppendAllLinesAsync(fileInfo.FullName, contents);
        }

        /// <summary>
        /// Appends lines asynchronously to a file by using a specified encoding, and then closes the file.
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">File path specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>File path is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, Encoding encoding)
        {
            return AsyncFile.AppendAllLinesAsync(fileInfo.FullName, contents, encoding, CancellationToken.None);
        }

        /// <summary>
        /// Appends lines asynchronously to a file, and then closes the file, and monitors cancellation requests. 
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">File path specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>File path is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            return AsyncFile.AppendAllLinesAsync(fileInfo.FullName, contents, Encoding.UTF8, cancellationToken);
        }

        /// <summary>
        /// Appends lines asynchronously to a file by using a specified encoding, and then closes the file, and monitors cancellation requests.
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="contents">The lines to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">File path specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>File path is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <remarks>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</remarks>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, Encoding encoding,
                                               CancellationToken cancellationToken)
        {
            return AsyncFile.AppendAllLinesAsync(fileInfo.FullName, contents, encoding, cancellationToken);
        }

        #endregion

        #region AppendAllTextAsync

        /// <summary>
        /// Asynchronously appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="contents">The string to append to the file.</param>
        /// <remarks>
        /// <para>Given a string and a file path, this method opens the specified file, appends the string to the end of the file using the specified encoding, and then closes the file. The file handle is guaranteed to be closed by this method, even if exceptions are raised.</para>
        /// <para>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</para>
        /// </remarks>
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="PathTooLongException">File path exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">File path specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>File path is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllTextAsync(this FileInfo fileInfo, string contents)
        {
            return AsyncFile.AppendAllTextAsync(fileInfo.FullName, contents, Encoding.UTF8);
        }

        /// <summary>
        /// Asynchronously appends the specified string to the file, creating the file if it does not already exist.
        /// </summary>
        /// <param name="contents">The string to append to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <remarks>
        /// <para>Given a string and a file path, this method opens the specified file, appends the string to the end of the file using the specified encoding, and then closes the file. The file handle is guaranteed to be closed by this method, even if exceptions are raised.</para>
        /// <para>The method creates the file if it doesn’t exist, but it doesn't create new directories. Therefore, the value of the path parameter must contain existing directories.</para>
        /// </remarks>
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="PathTooLongException">File path exceeds the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters and file names must be less than 260 characters.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">File path specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>File path is a directory.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task AppendAllTextAsync(this FileInfo fileInfo, string contents, Encoding encoding)
        {
            return AsyncFile.AppendAllTextAsync(fileInfo.FullName, contents, encoding);
        }

        #endregion

        #region CopyToAsync

        /// <summary>
        /// Asynchronously copies an existing file to a new file, and monitors cancellation requests. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// 
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="destFileName"/> parameter can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// File path or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para>File path or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either File path or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified inFile path or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException">Source file was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName);
        }

        /// <summary>
        /// Asynchronously copies an existing file to a new file, and monitors cancellation requests. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// 
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite"><c>true</c> if the destination file can be overwritten; otherwise, <c>false</c>.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="destFileName"/> parameter can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// File path or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para>File path or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either File path or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified inFile path or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException">Source file was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName, bool overwrite)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName, overwrite);
        }

        /// <summary>
        /// Asynchronously copies an existing file to a new file, and monitors cancellation requests. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// 
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="destFileName"/> parameter can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// File path or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para>File path or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either File path or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified inFile path or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException">Source file was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName, CancellationToken cancellationToken)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName, cancellationToken);
        }

        /// <summary>
        /// Asynchronously copies an existing file to a new file, and monitors cancellation requests. Overwriting a file of the same name is not allowed.
        /// </summary>
        /// 
        /// <param name="destFileName">The name of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite"><c>true</c> if the destination file can be overwritten; otherwise, <c>false</c>.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <remarks>
        /// <para>
        /// The <paramref name="destFileName"/> parameter can specify relative or absolute path information. 
        /// Relative path information is interpreted as relative to the current working directory. 
        /// This method does not support wildcard characters in the parameters.
        /// </para>
        /// <para>The attributes of the original file are retained in the copied file.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">
        /// File path or <paramref name="destFileName"/> is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.
        /// <para>-or-</para>
        /// <para>File path or <paramref name="destFileName"/> specifies a directory.</para>
        /// </exception>
        /// <exception cref="ArgumentNullException">Either File path or <paramref name="destFileName"/>is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified inFile path or <paramref name="destFileName"/> is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para><paramref name="destFileName"/> exists.</para>
        /// <para>-or-</para>
        /// <para>An I/O error has occurred.</para>
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="FileNotFoundException">Source file was not found.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><paramref name="destFileName"/> is read-only.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName, bool overwrite, CancellationToken cancellationToken)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName, overwrite, cancellationToken);
        }

        #endregion

        #region DeleteAsync

        /// <summary>
        /// Asynchronously deletes the specified file.
        /// </summary>
        /// 
        /// <remarks>
        /// <para>If the file to be deleted does not exist, no exception is thrown.</para>
        /// </remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains one more invalid characters defined by the <see cref="Path.GetInvalidPathChars"/> method.</exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">
        /// <para>The specified file is in use.</para>
        /// <para>-or-</para>
        /// <para>There is an open handle on the file, and the operating system is Windows XP or earlier. This open handle can result from enumerating directories and files.</para>
        /// </exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="PathTooLongException">
        /// The specified path, file name, or both exceed the system-defined maximum length. 
        /// For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.
        /// </exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">File path specifies a read-only file.
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para>
        /// <para>-or-</para>
        /// <para>The file is an executable file that is in use.</para>
        /// </exception>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        public static Task DeleteAsync(this FileInfo fileInfo)
        {
            return AsyncFile.DeleteAsync(fileInfo.FullName);
        }

        #endregion

        #region ReadAllBytesAsync

        /// <summary>
        /// Opens a binary file, asynchronously reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// 
        /// <returns>A task with a byte array containing the contents of the file.</returns>
        public static Task<byte[]> ReadAllBytesAsync(this FileInfo fileInfo)
        {
            return AsyncFile.ReadAllBytesAsync(fileInfo.FullName);
        }

        /// <summary>
        /// Opens a binary file, asynchronously reads the contents of the file into a byte array, and then closes the file.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// 
        /// <returns>A task with a byte array containing the contents of the file.</returns>
        public static Task<byte[]> ReadAllBytesAsync(this FileInfo fileInfo, CancellationToken cancellationToken)
        {
            return AsyncFile.ReadAllBytesAsync(fileInfo.FullName, cancellationToken);
        }

        #endregion

        #region ReadAllLinesAsync

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
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
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
        /// 
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
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo, Encoding encoding)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName, encoding);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
        /// 
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
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo, CancellationToken cancellationToken)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName, cancellationToken);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
        /// 
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
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo, Encoding encoding, CancellationToken cancellationToken)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName, encoding, cancellationToken);
        }

        #endregion

        #region ReadAllTextAsync

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
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
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string> ReadAllTextAsync(this FileInfo fileInfo)
        {
            return AsyncFile.ReadAllTextAsync(fileInfo.FullName);
        }

        /// <summary>
        /// Opens a file, asynchronously reads all lines of the file, and then closes the file.
        /// </summary>
        /// 
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
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path is <c>null</c>.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The path specified in File path is invalid, (dor example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="FileNotFoundException">The file specified in File path was not found.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task<string> ReadAllTextAsync(this FileInfo fileInfo, Encoding encoding)
        {
            return AsyncFile.ReadAllTextAsync(fileInfo.FullName, encoding);
        }

        #endregion

        #region WriteAllBytesAsync

        /// <summary>
        /// Creates a new file, asynchronously writes the specified byte array to the file, and then closes the file. 
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="bytes">The bytes to write to the file.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>Given a byte array, this method opens the specified file, writes the contents of the byte array to the file, and then closes the file.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="bytes"/> is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task WriteAllBytesAsync(this FileInfo fileInfo, byte[] bytes)
        {
            return AsyncFile.WriteAllBytesAsync(fileInfo.FullName, bytes);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes the specified byte array to the file, and then closes the file. 
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="bytes">The bytes to write to the file.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>Given a byte array, this method opens the specified file, writes the contents of the byte array to the file, and then closes the file.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="bytes"/> is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        public static Task WriteAllBytesAsync(this FileInfo fileInfo, byte[] bytes, CancellationToken cancellationToken)
        {
            return AsyncFile.WriteAllBytesAsync(fileInfo.FullName, bytes, cancellationToken);
        }

        #endregion

        #region WriteAllLinesAsync

        /// <summary>
        /// Creates a new file, asynchronously writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="contents">The lines to write to the file.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="contents"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="contents"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, Encoding encoding)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents, encoding);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="contents"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents, cancellationToken);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes a collection of strings to the file, and then closes the file.
        /// </summary>
        /// 
        /// <param name="contents">The lines to write to the file.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="contents"/> is <c>null</c></exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents, encoding, cancellationToken);
        }

        #endregion

        #region WriteAllTextAsync

        /// <summary>
        /// Creates a new file, asynchronously writes the specified string to the file, and then closes the file.
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="contents">The string to write to the file.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="contents"/>is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllTextAsync(this FileInfo fileInfo, string contents)
        {
            return AsyncFile.WriteAllTextAsync(fileInfo.FullName, contents);
        }

        /// <summary>
        /// Creates a new file, asynchronously writes the specified string to the file, and then closes the file.
        /// If the target file already exists, it is overwritten.
        /// </summary>
        /// 
        /// <param name="contents">The string to write to the file.</param>
        /// <param name="encoding">The encoding to apply to the string.</param>
        /// 
        /// <returns>Task that represents asynchronous operation.</returns>
        /// 
        /// <remarks>If the target file already exists, it is overwritten.</remarks>
        /// 
        /// <exception cref="ArgumentException">File path is a zero-length string, contains only white space, or contains invalid characters as defined in <see cref="Path.GetInvalidPathChars"/></exception>
        /// <exception cref="ArgumentNullException">File path or <paramref name="contents"/>is <c>null</c></exception>
        /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters.</exception>
        /// <exception cref="DirectoryNotFoundException">File path is invalid (for example, it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException">File path is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException">
        /// <para>File path specified a file that is read-only.</para>
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para>The caller does not have the required permission.</para> 
        /// </exception>
        public static Task WriteAllTextAsync(this FileInfo fileInfo, string contents, Encoding encoding)
        {
            return AsyncFile.WriteAllTextAsync(fileInfo.FullName, contents, encoding);
        }

        #endregion
    }
}