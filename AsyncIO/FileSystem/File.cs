using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncIO.FileSystem
{
    public static class File
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

        public static Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region AppendAllTextAsync

        public static Task AppendAllTextAsync(string path, string contents)
        {
            return AppendAllTextAsync(path, contents, Encoding.UTF8, CancellationToken.None);
        }

        public static Task AppendAllTextAsync(string path, string contents, Encoding encoding)
        {
            return AppendAllTextAsync(path, contents, encoding, CancellationToken.None);
        }

        public static Task AppendAllTextAsync(string path, string contents, CancellationToken cancellationToken)
        {
            return AppendAllTextAsync(path, contents, Encoding.UTF8, cancellationToken);
        }

        public static Task AppendAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        public static Task CopyAsync(string sourceFileName, string destFileName, bool overwrite, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region MoveAsync

        public static Task MoveAsync(string sourceFileName, string destFileName)
        {
            return MoveAsync(sourceFileName, destFileName, CancellationToken.None);
        }

        public static Task MoveAsync(string sourceFileName, string destFileName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ReadAllBytesAsync

        public static Task<byte[]> ReadAllBytesAsync(string path)
        {
            return ReadAllBytesAsync(path, CancellationToken.None);
        }

        public static Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        public static Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ReadAllTextAsync

        public static string ReadAllTextAsync(string path)
        {
            return ReadAllTextAsync(path, Encoding.UTF8, CancellationToken.None);
        }

        public static string ReadAllTextAsync(string path, Encoding encoding)
        {
            return ReadAllTextAsync(path, encoding, CancellationToken.None);
        }

        public static string ReadAllTextAsync(string path, CancellationToken cancellationToken)
        {
            return ReadAllTextAsync(path, Encoding.UTF8, cancellationToken);
        }

        public static string ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ReadLinesAsync

        public static Task<IEnumerable<string>> ReadLinesAsync(string path)
        {
            return ReadLinesAsync(path, Encoding.UTF8, CancellationToken.None);
        }


        public static Task<IEnumerable<string>> ReadLinesAsync(string path, Encoding encoding)
        {
            return ReadLinesAsync(path, encoding, CancellationToken.None);
        }

        public static Task<IEnumerable<string>> ReadLinesAsync(string path, CancellationToken cancellationToken)
        {
            return ReadLinesAsync(path, Encoding.UTF8, cancellationToken);
        }

        public static Task<IEnumerable<string>> ReadLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region WriteAllBytesAsync

        public static Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            return WriteAllBytesAsync(path, bytes, CancellationToken.None);
        }

        public static Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken none)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region WriteAllLinesAsync

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents)
        {
            throw new NotImplementedException();
        }

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding)
        {
            throw new NotImplementedException();
        }

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public static Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region WriteAllTextAsync

        public static Task WriteAllTextAsync(string path, string contents)
        {
            return WriteAllTextAsync(path, contents, Encoding.UTF8, CancellationToken.None);
        }

        public static Task WriteAllTextAsync(string path, string contents, Encoding encoding)
        {
            return WriteAllTextAsync(path, contents, encoding, CancellationToken.None);
        }

        public static Task WriteAllTextAsync(string path, string contents, CancellationToken cancellationToken)
        {
            return WriteAllTextAsync(path, contents, Encoding.UTF8, cancellationToken);
        }

        public static Task WriteAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}