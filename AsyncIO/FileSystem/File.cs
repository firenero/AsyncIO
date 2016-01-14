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
    }
}