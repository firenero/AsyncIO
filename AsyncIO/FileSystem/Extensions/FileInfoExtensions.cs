using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncIO.FileSystem.Extensions
{
    public static class FileInfoExtensions
    {
        #region AppendAllLinesAsync

        /// <summary>
        /// Appends lines asynchronously to a file, and then closes the file. 
        /// If the specified file does not exist, this method creates a file, writes the specified lines to the file, and then closes the file.
        /// </summary>
        /// <param name="contents">The lines to append to the file.</param>
        /// <exception cref="ArgumentNullException"><paramref name="contents"/> is <c>null</c>.</exception>
        /// <exception cref="DirectoryNotFoundException"><see cref="FileInfo.FullName"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><see cref="FileInfo.FullName"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><see cref="FileInfo.FullName"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><see cref="FileInfo.FullName"/> is a directory.</para>
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
        /// <exception cref="DirectoryNotFoundException"><see cref="FileInfo.FullName"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><see cref="FileInfo.FullName"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><see cref="FileInfo.FullName"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><see cref="FileInfo.FullName"/> is a directory.</para>
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
        /// <exception cref="DirectoryNotFoundException"><see cref="FileInfo.FullName"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><see cref="FileInfo.FullName"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><see cref="FileInfo.FullName"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><see cref="FileInfo.FullName"/> is a directory.</para>
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
        /// <exception cref="DirectoryNotFoundException"><see cref="FileInfo.FullName"/> is invalid (for example, the directory doesn’t exist or it is on an unmapped drive).</exception>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
        /// <exception cref="NotSupportedException"><see cref="FileInfo.FullName"/> is in an invalid format.</exception>
        /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
        /// <exception cref="UnauthorizedAccessException"><see cref="FileInfo.FullName"/> specifies a file that is read-only.
        /// <para>-or-</para>
        /// <para>This operation is not supported on the current platform.</para>
        /// <para>-or-</para>
        /// <para><see cref="FileInfo.FullName"/> is a directory.</para>
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

        public static Task AppendAllTextAsync(this FileInfo fileInfo, string contents)
        {
            return AsyncFile.AppendAllTextAsync(fileInfo.FullName, contents, Encoding.UTF8);
        }

        public static Task AppendAllTextAsync(this FileInfo fileInfo, string contents, Encoding encoding)
        {
            return AsyncFile.AppendAllTextAsync(fileInfo.FullName, contents, encoding);
        }

        #endregion

        #region CopyToAsync

        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName);
        }

        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName, bool overwrite)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName, overwrite);
        }

        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName, CancellationToken cancellationToken)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName, cancellationToken);
        }

        public static Task CopyToAsync(this FileInfo fileInfo, string destFileName, bool overwrite, CancellationToken cancellationToken)
        {
            return AsyncFile.CopyAsync(fileInfo.FullName, destFileName, overwrite, cancellationToken);
        }

        #endregion

        #region DeleteAsync

        public static Task DeleteAsync(this FileInfo fileInfo)
        {
            return AsyncFile.DeleteAsync(fileInfo.FullName);
        }

        #endregion

        #region ReadAllBytesAsync

        public static Task ReadAllBytesAsync(this FileInfo fileInfo)
        {
            return AsyncFile.ReadAllBytesAsync(fileInfo.FullName);
        }

        public static Task ReadAllBytesAsync(this FileInfo fileInfo, CancellationToken cancellationToken)
        {
            return AsyncFile.ReadAllBytesAsync(fileInfo.FullName, cancellationToken);
        }

        #endregion

        #region ReadAllLinesAsync

        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName);
        }

        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo, Encoding encoding)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName, encoding);
        }

        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo, CancellationToken cancellationToken)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName, cancellationToken);
        }

        public static Task<string[]> ReadAllLinesAsync(this FileInfo fileInfo, Encoding encoding, CancellationToken cancellationToken)
        {
            return AsyncFile.ReadAllLinesAsync(fileInfo.FullName, encoding, cancellationToken);
        }

        #endregion

        #region ReadAllTextAsync

        public static Task<string> ReadAllTextAsync(this FileInfo fileInfo)
        {
            return AsyncFile.ReadAllTextAsync(fileInfo.FullName);
        }

        public static Task<string> ReadAllTextAsync(this FileInfo fileInfo, Encoding encoding)
        {
            return AsyncFile.ReadAllTextAsync(fileInfo.FullName, encoding);
        }

        #endregion

        #region WriteAllBytesAsync

        public static Task WriteAllBytesAsync(this FileInfo fileInfo, byte[] bytes)
        {
            return AsyncFile.WriteAllBytesAsync(fileInfo.FullName, bytes);
        }

        public static Task WriteAllBytesAsync(this FileInfo fileInfo, byte[] bytes, CancellationToken cancellationToken)
        {
            return AsyncFile.WriteAllBytesAsync(fileInfo.FullName, bytes, cancellationToken);
        }

        #endregion

        #region WriteAllLinesAsync

        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents);
        }

        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, Encoding encoding)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents, encoding);
        }

        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents, cancellationToken);
        }

        public static Task WriteAllLinesAsync(this FileInfo fileInfo, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken)
        {
            return AsyncFile.WriteAllLinesAsync(fileInfo.FullName, contents, encoding, cancellationToken);
        }

        #endregion

        #region WriteAllTextAsync

        public static Task WriteAllTextAsync(this FileInfo fileInfo, string contents)
        {
            return AsyncFile.WriteAllTextAsync(fileInfo.FullName, contents);
        }

        public static Task WriteAllTextAsync(this FileInfo fileInfo, string contents, Encoding encoding)
        {
            return AsyncFile.WriteAllTextAsync(fileInfo.FullName, contents, encoding);
        }

        #endregion
    }
}