using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public async Task AppendAllLinesAsync_NullContent_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "AppendAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.AppendAllLinesAsync(path, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task AppendAllLinesAsync_NullEncoding_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "AppendAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.AppendAllLinesAsync(path, contents, null);
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

        #region AppendAllTextAsync Tests

        [TestMethod]
        public async Task AppendAllTextAsync_Default_TextAppended()
        {
            var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
            var path = Path.Combine(TestFolder, "AppendAllTextAsync_Default_TextAppended");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllText(path, contents);

            await AsyncFile.AppendAllTextAsync(path, contents);

            contents += string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));

            var result = File.ReadAllText(path);

            Assert.AreEqual(contents, result);
        }

        [TestMethod]
        public async Task AppendAllTextAsync_EncodingAscii_TextAppended()
        {
            await AppendAllTextAsync_EncodingTest(Encoding.ASCII);
        }

        [TestMethod]
        public async Task AppendAllTextAsync_EncodingUtf8_TextAppended()
        {
            await AppendAllTextAsync_EncodingTest(Encoding.UTF8);
        }

        [TestMethod]
        public async Task AppendAllTextAsync_EncodingBigEndianUnicode_TextAppended()
        {
            await AppendAllTextAsync_EncodingTest(Encoding.BigEndianUnicode);
        }

        [TestMethod]
        public async Task AppendAllTextAsync_EncodingDefault_TextAppended()
        {
            await AppendAllTextAsync_EncodingTest(Encoding.Default);
        }

        [TestMethod]
        public async Task AppendAllTextAsync_EncodingUtf32_TextAppended()
        {
            await AppendAllTextAsync_EncodingTest(Encoding.UTF32);
        }

        [TestMethod]
        public async Task AppendAllTextAsync_EncodingUtf7_TextAppended()
        {
            await AppendAllTextAsync_EncodingTest(Encoding.UTF7);
        }

        [TestMethod]
        public async Task AppendAllTextAsync_EncodingUnicode_TextAppended()
        {
            await AppendAllTextAsync_EncodingTest(Encoding.Unicode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task AppendAllTextAsync_NullContent_ExceptionThrown()
        {
            var path = Path.Combine(TestFolder, "AppendAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.AppendAllTextAsync(path, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task AppendAllTextAsync_NullEncoding_ExceptionThrown()
        {
            var contents = "This is a test line.";
            var path = Path.Combine(TestFolder, "AppendAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.AppendAllTextAsync(path, contents, null);
        }

        private async Task AppendAllTextAsync_EncodingTest(Encoding encoding)
        {
            var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
            var path = Path.Combine(TestFolder, "AppendAllTextAsync_Default_TextAppended");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllText(path, contents, encoding);

            await AsyncFile.AppendAllTextAsync(path, contents, encoding);

            contents += string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));

            var result = File.ReadAllText(path, encoding);

            Assert.AreEqual(contents, result);
        }

        #endregion

        #region CopyAsync Tests

        [TestMethod]
        public async Task CopyAsync_Default_FileCopied()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "CopyAsync_Default_FileCopied");


            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "CopyAsync_Default_FileCopied_Copy";
            File.Delete(copyPath);

            await AsyncFile.CopyAsync(path, copyPath);

            var result = File.ReadAllLines(copyPath);
            CollectionAssert.AreEqual(contents, result);
        }

        [TestMethod]
        public async Task CopyAsync_Overwrite_FileCopied()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "CopyAsync_Overwrite_FileCopied");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "CopyAsync_Overwrite_FileCopied_Copy";
            if (!File.Exists(copyPath))
                File.Create(copyPath).Dispose();

            await AsyncFile.CopyAsync(path, copyPath, true);

            var result = File.ReadAllLines(copyPath);
            CollectionAssert.AreEqual(contents, result);
        }

        [TestMethod]
        [ExpectedException(typeof (TaskCanceledException))]
        public async Task CopyAsync_CancellationToken_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150000).ToList();
            var path = Path.Combine(TestFolder, "CopyAsync_Default_FileCopied");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "CopyAsync_Default_FileCopied_Copy";
            File.Delete(copyPath);

            var tokenSource = new CancellationTokenSource(10);
            await AsyncFile.CopyAsync(path, copyPath, tokenSource.Token);

            var result = File.ReadAllLines(copyPath);
            Assert.IsTrue(contents.Count > result.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(TaskCanceledException))]
        public async Task CopyAsync_CancellationTokenOverwrite_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150000).ToList();
            var path = Path.Combine(TestFolder, "CopyAsync_Default_FileCopied");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "CopyAsync_Default_FileCopied_Copy";
            if (!File.Exists(copyPath))
                File.Create(copyPath).Dispose();

            var tokenSource = new CancellationTokenSource(10);
            await AsyncFile.CopyAsync(path, copyPath, true, tokenSource.Token);

            var result = File.ReadAllLines(copyPath);
            Assert.IsTrue(contents.Count > result.Length);
        }

        #endregion


    }
}