using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncIO.FileSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncIO.Tests.FileSystem
{
    [TestClass]
    public class FileTests
    {
        private const string TestFolder = "FileTests";

        #region AppendAllLinesAsync Tests

        [TestMethod]
        public async Task AppendAllLinesAsync_Default_LinesAppended()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "AppendAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            await AsyncFile.AppendAllLinesAsync(path, contents);

            contents.AddRange(Enumerable.Repeat("This is a test line.", 150));

            var result = File.ReadAllLines(path);

            CollectionAssert.AreEqual(contents, result);
        }

        [TestMethod]
        public async Task AppendAllLinesAsync_EncodingAscii_LinesAppended()
        {
            await AppendAllLinesAsync_EncodingTest(Encoding.ASCII);
        }

        [TestMethod]
        public async Task AppendAllLinesAsync_EncodingUtf8_LinesAppended()
        {
            await AppendAllLinesAsync_EncodingTest(Encoding.UTF8);
        }

        [TestMethod]
        public async Task AppendAllLinesAsync_EncodingBigEndianUnicode_LinesAppended()
        {
            await AppendAllLinesAsync_EncodingTest(Encoding.BigEndianUnicode);
        }

        [TestMethod]
        public async Task AppendAllLinesAsync_EncodingDefault_LinesAppended()
        {
            await AppendAllLinesAsync_EncodingTest(Encoding.Default);
        }

        [TestMethod]
        public async Task AppendAllLinesAsync_EncodingUtf32_LinesAppended()
        {
            await AppendAllLinesAsync_EncodingTest(Encoding.UTF32);
        }

        [TestMethod]
        public async Task AppendAllLinesAsync_EncodingUtf7_LinesAppended()
        {
            await AppendAllLinesAsync_EncodingTest(Encoding.UTF7);
        }

        [TestMethod]
        public async Task AppendAllLinesAsync_EncodingUnicode_LinesAppended()
        {
            await AppendAllLinesAsync_EncodingTest(Encoding.Unicode);
        }

        [TestMethod]
        [ExpectedException(typeof (OperationCanceledException))]
        public async Task AppendAllLinesAsync_CancellationToken_LinesAppended()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "AppendAllLinesAsync_Default_LinesAppended");
            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            contents.AddRange(Enumerable.Repeat("This is a test line.", 150000));

            var cancellationTokenSource = new CancellationTokenSource(100);
            await AsyncFile.AppendAllLinesAsync(path, contents, cancellationTokenSource.Token);

            var result = File.ReadAllLines(path);

            Assert.IsTrue(contents.Count > result.Length);
        }

        private async Task AppendAllLinesAsync_EncodingTest(Encoding encoding)
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "AppendAllLinesAsync_Encoding_LinesAppended");
            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents, encoding);

            await AsyncFile.AppendAllLinesAsync(path, contents, encoding);

            contents.AddRange(Enumerable.Repeat("This is a test line.", 150));

            var result = File.ReadAllLines(path, encoding);

            CollectionAssert.AreEqual(contents, result);
        }

        #endregion

    }
}