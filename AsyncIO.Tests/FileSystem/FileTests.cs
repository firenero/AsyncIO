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
        [ExpectedException(typeof(OperationCanceledException), AllowDerivedTypes = true)]
        public async Task CopyAsync_CancellationTokenOverwrite_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 300000).ToList();
            var path = Path.Combine(TestFolder, "CopyAsync_Default_FileCopied");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "CopyAsync_Default_FileCopied_Copy";
            if (!File.Exists(copyPath))
                File.Create(copyPath).Dispose();

            var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();
            await AsyncFile.CopyAsync(path, copyPath, true, tokenSource.Token);

            var result = File.ReadAllLines(copyPath);
            Assert.IsTrue(contents.Count > result.Length);
        }

        #endregion

        #region DeleteAsync Tests

        [TestMethod]
        public async Task DeleteAsync_Default_FileDeleted()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "DeleteAsync_Default_FileDeleted");


            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            await AsyncFile.DeleteAsync(path);

            Assert.IsFalse(File.Exists(path));
        }

        [TestMethod]
        public async Task DeleteAsync_NotExists_FileDeleted()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "DeleteAsync_NotExists_FileDeleted");


            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            await AsyncFile.DeleteAsync(path);

            Assert.IsFalse(File.Exists(path));
        }

        #endregion

        #region MoveAsync Tests

        [TestMethod]
        public async Task MoveAsync_Default_FileMoved()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "MoveAsync_Default_FileMoved");


            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "MoveAsync_Default_FileMoved_Copy";
            File.Delete(copyPath);

            await AsyncFile.MoveAsync(path, copyPath);

            var result = File.ReadAllLines(copyPath);
            CollectionAssert.AreEqual(contents, result);
            Assert.IsFalse(File.Exists(path));
        }

        [TestMethod]
        [ExpectedException(typeof (IOException), AllowDerivedTypes = true)]
        public async Task MoveAsync_Overwrite_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "MoveAsync_Overwrite_FileMoved");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "MoveAsync_Overwrite_FileMoved_Copy";
            if (!File.Exists(copyPath))
                File.Create(copyPath).Dispose();

            await AsyncFile.MoveAsync(path, copyPath);

            var result = File.ReadAllLines(copyPath);
            CollectionAssert.AreEqual(contents, result);
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        [ExpectedException(typeof(OperationCanceledException), AllowDerivedTypes = true)]
        public async Task MoveAsync_CancellationToken_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 300000).ToList();
            var path = Path.Combine(TestFolder, "MoveAsync_Default_FileMoved");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = "MoveAsync_Default_FileMoved_Copy";
            File.Delete(copyPath);

            var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();
            await AsyncFile.MoveAsync(path, copyPath, tokenSource.Token);

            var result = File.ReadAllLines(copyPath);
             Assert.IsTrue(contents.Count > result.Length);
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public async Task MoveAsync_SamePath_FileMoved()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150000).ToList();
            var path = Path.Combine(TestFolder, "MoveAsync_Default_FileMoved");

            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var copyPath = path;

            await AsyncFile.MoveAsync(path, copyPath);

            var result = File.ReadAllLines(copyPath);
            CollectionAssert.AreEqual(contents, result);
            Assert.IsTrue(File.Exists(path));
        }

        #endregion

        #region ReadAllBytesAsync Tests

        [TestMethod]
        public async Task ReadAllBytesAsync_Default_BytesRead()
        {
            var bytes = new byte[10000];
            var random = new Random();
            random.NextBytes(bytes);

            var path = Path.Combine(TestFolder, "ReadAllBytesAsync_Default_BytesRead");
            Directory.CreateDirectory(TestFolder);

            File.WriteAllBytes(path, bytes);

            var result = await AsyncFile.ReadAllBytesAsync(path).ConfigureAwait(false);

            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        [ExpectedException(typeof (OperationCanceledException), AllowDerivedTypes = true)]
        public async Task ReadAllBytesAsync_CancellationToken_BytesRead()
        {
            var bytes = new byte[100000];
            var random = new Random();
            random.NextBytes(bytes);

            var path = Path.Combine(TestFolder, "ReadAllBytesAsync_CancellationToken_BytesRead");
            Directory.CreateDirectory(TestFolder);

            File.WriteAllBytes(path, bytes);

            var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();
            var result = await AsyncFile.ReadAllBytesAsync(path, tokenSource.Token).ConfigureAwait(false);

            CollectionAssert.AreNotEqual(bytes, result);
        }

        #endregion

        #region ReadAllLinesAsync Tests

        [TestMethod]
        public async Task ReadAllLinesAsync_Default_LinesReaded()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "ReadAllLinesAsync_Default_LinesReaded");


            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var result = await AsyncFile.ReadAllLinesAsync(path).ConfigureAwait(false);

            CollectionAssert.AreEqual(contents, result);
        }

        [TestMethod]
        public async Task ReadAllLinesAsync_EncodingUtf8_LinesReaded()
        {
            await ReadAllLinesAsync_EncodingTest(Encoding.UTF8).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllLinesAsync_EncodingAscii_LinesReaded()
        {
            await ReadAllLinesAsync_EncodingTest(Encoding.ASCII).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllLinesAsync_EncodingBigEndianUnicode_LinesReaded()
        {
            await ReadAllLinesAsync_EncodingTest(Encoding.BigEndianUnicode).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllLinesAsync_EncodingUtf32_LinesReaded()
        {
            await ReadAllLinesAsync_EncodingTest(Encoding.UTF32).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllLinesAsync_EncodingUtf7_LinesReaded()
        {
            await ReadAllLinesAsync_EncodingTest(Encoding.UTF7).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllLinesAsync_EncodingUnicode_LinesReaded()
        {
            await ReadAllLinesAsync_EncodingTest(Encoding.Unicode).ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof (OperationCanceledException))]
        public async Task ReadAllLinesAsync_CancellationToken_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 30000).ToList();
            var path = Path.Combine(TestFolder, "ReadAllLinesAsync_Default_LinesReaded");


            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var tokenSource = new CancellationTokenSource(25);
            var result = await AsyncFile.ReadAllLinesAsync(path, tokenSource.Token).ConfigureAwait(false);

            CollectionAssert.AreNotEqual(contents, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ReadAllLinesAsync_NullEncoding_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 30000).ToList();
            var path = Path.Combine(TestFolder, "ReadAllLinesAsync_Default_LinesReaded");


            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents);

            var result = await AsyncFile.ReadAllLinesAsync(path, null).ConfigureAwait(false);
        }

        private async Task ReadAllLinesAsync_EncodingTest(Encoding encoding)
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "ReadAllLinesAsync_EncodingTest");
            Directory.CreateDirectory(TestFolder);
            File.WriteAllLines(path, contents, encoding);

            var result = await AsyncFile.ReadAllLinesAsync(path, encoding).ConfigureAwait(false);

            CollectionAssert.AreEqual(contents, result);
        }

        #endregion

        #region ReadAllTextAsync Tests

        [TestMethod]
        public async Task ReadAllTextAsync_Default_LinesReaded()
        {
            var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
            var path = Path.Combine(TestFolder, "ReadAllTextAsync_EncodingTest");
            Directory.CreateDirectory(TestFolder);
            File.WriteAllText(path, contents);

            var result = await AsyncFile.ReadAllTextAsync(path).ConfigureAwait(false);

            Assert.AreEqual(contents, result);
        }

        [TestMethod]
        public async Task ReadAllTextAsync_EncodingUtf8_LinesReaded()
        {
            await ReadAllTextAsync_EncodingTest(Encoding.UTF8).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllTextAsync_EncodingAscii_LinesReaded()
        {
            await ReadAllTextAsync_EncodingTest(Encoding.ASCII).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllTextAsync_EncodingBigEndianUnicode_LinesReaded()
        {
            await ReadAllTextAsync_EncodingTest(Encoding.BigEndianUnicode).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllTextAsync_EncodingUtf32_LinesReaded()
        {
            await ReadAllTextAsync_EncodingTest(Encoding.UTF32).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllTextAsync_EncodingUtf7_LinesReaded()
        {
            await ReadAllTextAsync_EncodingTest(Encoding.UTF7).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task ReadAllTextAsync_EncodingUnicode_LinesReaded()
        {
            await ReadAllTextAsync_EncodingTest(Encoding.Unicode).ConfigureAwait(false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task ReadAllTextAsync_NullEncoding_ExceptionThrown()
        {
            var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
            var path = Path.Combine(TestFolder, "ReadAllTextAsync_EncodingTest");
            Directory.CreateDirectory(TestFolder);
            File.WriteAllText(path, contents);

            var result = await AsyncFile.ReadAllTextAsync(path, null).ConfigureAwait(false);
        }

        private async Task ReadAllTextAsync_EncodingTest(Encoding encoding)
        {
            var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
            var path = Path.Combine(TestFolder, "ReadAllTextAsync_EncodingTest");
            Directory.CreateDirectory(TestFolder);
            File.WriteAllText(path, contents, encoding);

            var result = await AsyncFile.ReadAllTextAsync(path, encoding).ConfigureAwait(false);

            Assert.AreEqual(contents, result);
        }

        #endregion

        #region WriteAllBytesAsync Tests

        [TestMethod]
        public async Task WriteAllBytesAsync_Default_BytesWritten()
        {
            var bytes = new byte[10000];
            var random = new Random();
            random.NextBytes(bytes);

            var path = Path.Combine(TestFolder, "WriteAllBytesAsync_Default_BytesWritten");
            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllBytesAsync(path, bytes).ConfigureAwait(false);

            var result = File.ReadAllBytes(path);

            CollectionAssert.AreEqual(bytes, result);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationCanceledException), AllowDerivedTypes = true)]
        public async Task WriteAllBytesAsync_CancellationToken_BytesWritten()
        {
            var bytes = new byte[100000];
            var random = new Random();
            random.NextBytes(bytes);

            var path = Path.Combine(TestFolder, "WriteAllBytesAsync_CancellationToken_BytesWritten");
            Directory.CreateDirectory(TestFolder);

            var tokenSource = new CancellationTokenSource();
            tokenSource.Cancel();

            await AsyncFile.WriteAllBytesAsync(path, bytes, tokenSource.Token).ConfigureAwait(false);

            var result = File.ReadAllBytes(path);

            CollectionAssert.AreNotEqual(bytes, result);
        }

        #endregion

        #region WriteAllLinesAsync Tests

        [TestMethod]
        public async Task WriteAllLinesAsync_Default_LinesAppended()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "WriteAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllLinesAsync(path, contents);

            var result = File.ReadAllLines(path);

            CollectionAssert.AreEqual(contents, result);
        }

        [TestMethod]
        public async Task WriteAllLinesAsync_EncodingAscii_LinesAppended()
        {
            await WriteAllLinesAsync_EncodingTest(Encoding.ASCII);
        }

        [TestMethod]
        public async Task WriteAllLinesAsync_EncodingUtf8_LinesAppended()
        {
            await WriteAllLinesAsync_EncodingTest(Encoding.UTF8);
        }

        [TestMethod]
        public async Task WriteAllLinesAsync_EncodingBigEndianUnicode_LinesAppended()
        {
            await WriteAllLinesAsync_EncodingTest(Encoding.BigEndianUnicode);
        }

        [TestMethod]
        public async Task WriteAllLinesAsync_EncodingDefault_LinesAppended()
        {
            await WriteAllLinesAsync_EncodingTest(Encoding.Default);
        }

        [TestMethod]
        public async Task WriteAllLinesAsync_EncodingUtf32_LinesAppended()
        {
            await WriteAllLinesAsync_EncodingTest(Encoding.UTF32);
        }

        [TestMethod]
        public async Task WriteAllLinesAsync_EncodingUtf7_LinesAppended()
        {
            await WriteAllLinesAsync_EncodingTest(Encoding.UTF7);
        }

        [TestMethod]
        public async Task WriteAllLinesAsync_EncodingUnicode_LinesAppended()
        {
            await WriteAllLinesAsync_EncodingTest(Encoding.Unicode);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationCanceledException))]
        public async Task WriteAllLinesAsync_CancellationToken_LinesAppended()
        {
            var contents = Enumerable.Repeat("This is a test line.", 30000).ToList();
            var path = Path.Combine(TestFolder, "WriteAllLinesAsync_Default_LinesAppended");
            Directory.CreateDirectory(TestFolder);

            var cancellationTokenSource = new CancellationTokenSource(20);
            await AsyncFile.WriteAllLinesAsync(path, contents, cancellationTokenSource.Token);

            var result = File.ReadAllLines(path);

            Assert.IsTrue(contents.Count > result.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WriteAllLinesAsync_NullContent_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "WriteAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllLinesAsync(path, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WriteAllLinesAsync_NullEncoding_ExceptionThrown()
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "WriteAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllLinesAsync(path, contents, null);
        }

        private async Task WriteAllLinesAsync_EncodingTest(Encoding encoding)
        {
            var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
            var path = Path.Combine(TestFolder, "WriteAllLinesAsync_Encoding_LinesAppended");
            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllLinesAsync(path, contents, encoding);

            var result = File.ReadAllLines(path, encoding);

            CollectionAssert.AreEqual(contents, result);
        }

        #endregion

        #region WriteAllTextAsync Tests

        [TestMethod]
        public async Task WriteAllTextAsync_Default_TextAppended()
        {
            var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
            var path = Path.Combine(TestFolder, "WriteAllTextAsync_Default_TextAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllTextAsync(path, contents);

            var result = File.ReadAllText(path);

            Assert.AreEqual(contents, result);
        }

        [TestMethod]
        public async Task WriteAllTextAsync_EncodingAscii_TextAppended()
        {
            await WriteAllTextAsync_EncodingTest(Encoding.ASCII);
        }

        [TestMethod]
        public async Task WriteAllTextAsync_EncodingUtf8_TextAppended()
        {
            await WriteAllTextAsync_EncodingTest(Encoding.UTF8);
        }

        [TestMethod]
        public async Task WriteAllTextAsync_EncodingBigEndianUnicode_TextAppended()
        {
            await WriteAllTextAsync_EncodingTest(Encoding.BigEndianUnicode);
        }

        [TestMethod]
        public async Task WriteAllTextAsync_EncodingDefault_TextAppended()
        {
            await WriteAllTextAsync_EncodingTest(Encoding.Default);
        }

        [TestMethod]
        public async Task WriteAllTextAsync_EncodingUtf32_TextAppended()
        {
            await WriteAllTextAsync_EncodingTest(Encoding.UTF32);
        }

        [TestMethod]
        public async Task WriteAllTextAsync_EncodingUtf7_TextAppended()
        {
            await WriteAllTextAsync_EncodingTest(Encoding.UTF7);
        }

        [TestMethod]
        public async Task WriteAllTextAsync_EncodingUnicode_TextAppended()
        {
            await WriteAllTextAsync_EncodingTest(Encoding.Unicode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WriteAllTextAsync_NullContent_ExceptionThrown()
        {
            var path = Path.Combine(TestFolder, "WriteAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllTextAsync(path, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WriteAllTextAsync_NullEncoding_ExceptionThrown()
        {
            var contents = "This is a test line.";
            var path = Path.Combine(TestFolder, "WriteAllLinesAsync_Default_LinesAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllTextAsync(path, contents, null);
        }

        private async Task WriteAllTextAsync_EncodingTest(Encoding encoding)
        {
            var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
            var path = Path.Combine(TestFolder, "WriteAllTextAsync_Default_TextAppended");

            Directory.CreateDirectory(TestFolder);

            await AsyncFile.WriteAllTextAsync(path, contents, encoding);

            var result = File.ReadAllText(path, encoding);

            Assert.AreEqual(contents, result);
        }

        #endregion

    }
}