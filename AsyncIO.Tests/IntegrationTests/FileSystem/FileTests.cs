using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AsyncIO.FileSystem;
using NUnit.Framework;

namespace AsyncIO.Tests.IntegrationTests.FileSystem
{
    public class FileTests
    {
        private const string FileTestFolder = "FileTests";

        private static Encoding[] encodings =
        {
            Encoding.ASCII, Encoding.BigEndianUnicode, Encoding.UTF32, Encoding.UTF7, Encoding.UTF8, Encoding.Unicode
        };

        [TestFixture]
        public class AppendAllLinesAsyncMethod
        {
            private readonly string appendAllLinesTestFolder = Path.Combine(FileTestFolder, nameof(AppendAllLinesAsyncMethod));

            [Test]
            public async Task Default_LinesAppended()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(appendAllLinesTestFolder, nameof(Default_LinesAppended));

                Directory.CreateDirectory(appendAllLinesTestFolder);
                File.WriteAllLines(path, contents);

                await AsyncFile.AppendAllLinesAsync(path, contents);

                contents.AddRange(Enumerable.Repeat("This is a test line.", 150));

                var result = File.ReadAllLines(path);

                CollectionAssert.AreEqual(contents, result);
            }

            [TestCaseSource(typeof(FileTests), nameof(encodings))]
            public async Task LinesAppendedWithEncoding(Encoding encoding)
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(appendAllLinesTestFolder, nameof(LinesAppendedWithEncoding));
                Directory.CreateDirectory(appendAllLinesTestFolder);
                File.WriteAllLines(path, contents, encoding);

                await AsyncFile.AppendAllLinesAsync(path, contents, encoding);

                contents.AddRange(Enumerable.Repeat("This is a test line.", 150));

                var result = File.ReadAllLines(path, encoding);

                CollectionAssert.AreEqual(contents, result);
            }

            [Test]
            public void CancellationToken_LinesAppended()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(appendAllLinesTestFolder, nameof(CancellationToken_LinesAppended));
                Directory.CreateDirectory(appendAllLinesTestFolder);
                File.WriteAllLines(path, contents);

                contents.AddRange(Enumerable.Repeat("This is a test line.", 150000));

                var cancellationTokenSource = new CancellationTokenSource();

                Assert.ThrowsAsync<TaskCanceledException>(
                    async () =>
                    {
                        var task = AsyncFile.AppendAllLinesAsync(path, contents, cancellationTokenSource.Token);
                        cancellationTokenSource.Cancel();
                        await task;
                    });

                var result = File.ReadAllLines(path);

                Assert.IsTrue(contents.Count > result.Length);
            }

            [Test]
            public void NullContent_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(appendAllLinesTestFolder, nameof(NullEncoding_ExceptionThrown));

                Directory.CreateDirectory(appendAllLinesTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.AppendAllLinesAsync(path, null));
            }

            [Test]
            public void NullEncoding_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(appendAllLinesTestFolder, nameof(NullEncoding_ExceptionThrown));

                Directory.CreateDirectory(appendAllLinesTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.AppendAllLinesAsync(path, contents, null));
            }

        }

        [TestFixture]
        public class AppendAllTextAsyncMethod
        {
            private readonly string appendAllTextTestFolder = Path.Combine(FileTestFolder, nameof(AppendAllTextAsyncMethod));

            [Test]
            public async Task Default_TextAppended()
            {
                var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
                var path = Path.Combine(appendAllTextTestFolder, nameof(Default_TextAppended));

                Directory.CreateDirectory(appendAllTextTestFolder);
                File.WriteAllText(path, contents);

                await AsyncFile.AppendAllTextAsync(path, contents);

                contents += string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));

                var result = File.ReadAllText(path);

                Assert.AreEqual(contents, result);
            }

            [TestCaseSource(typeof(FileTests), nameof(encodings))]
            public async Task TextAppendedWithEncoding(Encoding encoding)
            {
                var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
                var path = Path.Combine(appendAllTextTestFolder, nameof(TextAppendedWithEncoding));

                Directory.CreateDirectory(appendAllTextTestFolder);
                File.WriteAllText(path, contents, encoding);

                await AsyncFile.AppendAllTextAsync(path, contents, encoding);

                contents += string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));

                var result = File.ReadAllText(path, encoding);

                Assert.AreEqual(contents, result);
            }

            [Test]
            public void NullContent_ExceptionThrown()
            {
                var path = Path.Combine(appendAllTextTestFolder, nameof(NullContent_ExceptionThrown));

                Directory.CreateDirectory(appendAllTextTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.AppendAllTextAsync(path, null));
            }

            [Test]
            public void AppendAllTextAsync_NullEncoding_ExceptionThrown()
            {
                var contents = "This is a test line.";
                var path = Path.Combine(appendAllTextTestFolder, "AppendAllLinesAsync_Default_LinesAppended");

                Directory.CreateDirectory(appendAllTextTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.AppendAllTextAsync(path, contents, null));
            }
        }

        [TestFixture]
        public class CopyAsyncMethod
        {
            private readonly string copyTestFolder = Path.Combine(FileTestFolder, nameof(CopyAsyncMethod));

            [Test]
            public async Task Default_FileCopied()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(copyTestFolder, nameof(Default_FileCopied));


                Directory.CreateDirectory(copyTestFolder);
                File.WriteAllLines(path, contents);

                var copyPath = Path.Combine(copyTestFolder, $"{nameof(Default_FileCopied)}_Copy");
                File.Delete(copyPath);

                await AsyncFile.CopyAsync(path, copyPath);

                var result = File.ReadAllLines(copyPath);
                CollectionAssert.AreEqual(contents, result);
            }

            [Test]
            public async Task Overwrite_FileCopied()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(copyTestFolder, nameof(Overwrite_FileCopied));

                Directory.CreateDirectory(copyTestFolder);
                File.WriteAllLines(path, contents);

                var copyPath = Path.Combine(copyTestFolder, $"{nameof(Overwrite_FileCopied)}_Copy");
                if (!File.Exists(copyPath))
                    File.Create(copyPath).Dispose();

                await AsyncFile.CopyAsync(path, copyPath, true);

                var result = File.ReadAllLines(copyPath);
                CollectionAssert.AreEqual(contents, result);
            }

            [Test]
            public void CancellationToken_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150000).ToList();
                var path = Path.Combine(copyTestFolder, nameof(CancellationToken_ExceptionThrown));

                Directory.CreateDirectory(copyTestFolder);
                File.WriteAllLines(path, contents);

                var copyPath = Path.Combine(copyTestFolder, $"{nameof(CancellationToken_ExceptionThrown)}_Copy");
                File.Delete(copyPath);

                var tokenSource = new CancellationTokenSource();
                Assert.ThrowsAsync<TaskCanceledException>(async () =>
                                                          {
                                                              var task = AsyncFile.CopyAsync(path, copyPath, tokenSource.Token);
                                                              tokenSource.Cancel();
                                                              await task;
                                                          });

                var result = File.ReadAllLines(copyPath);
                Assert.IsTrue(contents.Count > result.Length);
            }

            [Test]
            public void CancellationTokenOverwrite_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 300000).ToList();
                var path = Path.Combine(copyTestFolder, nameof(CancellationTokenOverwrite_ExceptionThrown));

                Directory.CreateDirectory(copyTestFolder);
                File.WriteAllLines(path, contents);

                var copyPath = Path.Combine(copyTestFolder, $"{nameof(CancellationTokenOverwrite_ExceptionThrown)}_Copy");
                if (!File.Exists(copyPath))
                    File.Create(copyPath).Dispose();

                var tokenSource = new CancellationTokenSource();
                Assert.ThrowsAsync<TaskCanceledException>(async () =>
                                                          {
                                                              var task = AsyncFile.CopyAsync(path, copyPath, true, tokenSource.Token);
                                                              tokenSource.Cancel();
                                                              await task;
                                                          });

                var result = File.ReadAllLines(copyPath);
                Assert.IsTrue(contents.Count > result.Length);
            }
        }

        public class DeleteAsyncMethod
        {
            private readonly string deleteTestFolder = Path.Combine(FileTestFolder, nameof(DeleteAsyncMethod));

            [Test]
            public async Task Default_FileDeleted()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(deleteTestFolder, nameof(Default_FileDeleted));


                Directory.CreateDirectory(deleteTestFolder);
                File.WriteAllLines(path, contents);

                await AsyncFile.DeleteAsync(path);

                Assert.IsFalse(File.Exists(path));
            }

            [Test]
            public async Task NotExists_FileDeleted()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(deleteTestFolder, nameof(NotExists_FileDeleted));


                Directory.CreateDirectory(deleteTestFolder);
                File.WriteAllLines(path, contents);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                await AsyncFile.DeleteAsync(path);

                Assert.IsFalse(File.Exists(path));
            }
        }

        [TestFixture]
        public class MoveAsyncMethod
        {

            private readonly string moveTestFolder = Path.Combine(FileTestFolder, nameof(MoveAsyncMethod));

            [Test]
            public async Task Default_FileMoved()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(moveTestFolder, nameof(Default_FileMoved));

                Directory.CreateDirectory(moveTestFolder);
                File.WriteAllLines(path, contents);

                var movePath = Path.Combine(moveTestFolder, $"{nameof(Default_FileMoved)}_Moved");
                File.Delete(movePath);

                await AsyncFile.MoveAsync(path, movePath);

                var result = File.ReadAllLines(movePath);
                CollectionAssert.AreEqual(contents, result);
                Assert.IsFalse(File.Exists(path));
            }

            [Test]
            public void Overwrite_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(moveTestFolder, nameof(Overwrite_ExceptionThrown));

                Directory.CreateDirectory(moveTestFolder);
                File.WriteAllLines(path, contents);

                var movePath = Path.Combine(moveTestFolder, $"{nameof(Overwrite_ExceptionThrown)}_Moved");
                if (!File.Exists(movePath))
                    File.Create(movePath).Dispose();

                Assert.ThrowsAsync<IOException>(async () => await AsyncFile.MoveAsync(path, movePath));
            }

            [Test]
            public async Task CancellationToken_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 300000).ToList();
                var path = Path.Combine(moveTestFolder, nameof(CancellationToken_ExceptionThrown));

                Directory.CreateDirectory(moveTestFolder);
                File.WriteAllLines(path, contents);

                var movePath = Path.Combine(moveTestFolder, $"{nameof(CancellationToken_ExceptionThrown)}_Moved");
                File.Delete(movePath);

                var tokenSource = new CancellationTokenSource();
                Assert.ThrowsAsync<TaskCanceledException>(async () =>
                                                          {
                                                              var task = AsyncFile.MoveAsync(path, movePath, tokenSource.Token);
                                                              tokenSource.Cancel();
                                                              await task;
                                                          });

                var result = File.ReadAllLines(movePath);
                Assert.IsTrue(contents.Count > result.Length);
                Assert.IsTrue(File.Exists(path));
            }

            [Test]
            public async Task SamePath_FileMoved()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150000).ToList();
                var path = Path.Combine(moveTestFolder, nameof(SamePath_FileMoved));

                Directory.CreateDirectory(moveTestFolder);
                File.WriteAllLines(path, contents);

                var movePath = path;

                await AsyncFile.MoveAsync(path, movePath);

                var result = File.ReadAllLines(movePath);
                CollectionAssert.AreEqual(contents, result);
                Assert.IsTrue(File.Exists(path));
            }
        }

        [TestFixture]
        public class ReadAllBytesAsyncMethod
        {
            private readonly string readAllBytesTestFolder = Path.Combine(FileTestFolder, nameof(ReadAllBytesAsyncMethod));

            [Test]
            public async Task Default_BytesRead()
            {
                var bytes = new byte[10000];
                var random = new Random();
                random.NextBytes(bytes);

                var path = Path.Combine(readAllBytesTestFolder, nameof(Default_BytesRead));
                Directory.CreateDirectory(readAllBytesTestFolder);

                File.WriteAllBytes(path, bytes);

                var result = await AsyncFile.ReadAllBytesAsync(path).ConfigureAwait(false);

                CollectionAssert.AreEqual(bytes, result);
            }

            [Test]
            public void CancellationToken_BytesRead()
            {
                var bytes = new byte[100000];
                var random = new Random();
                random.NextBytes(bytes);

                var path = Path.Combine(readAllBytesTestFolder, nameof(CancellationToken_BytesRead));
                Directory.CreateDirectory(readAllBytesTestFolder);

                File.WriteAllBytes(path, bytes);

                var tokenSource = new CancellationTokenSource();
                Assert.ThrowsAsync<TaskCanceledException>(async () =>
                                                          {
                                                              tokenSource.Cancel();
                                                              var task = AsyncFile.ReadAllBytesAsync(path, tokenSource.Token);
                                                              await task;
                                                          });

            }
        }

        [TestFixture]
        public class ReadAllLinesAsyncMethod
        {
            private readonly string readAllLinesTestFolder = Path.Combine(FileTestFolder, nameof(ReadAllLinesAsyncMethod));

            [Test]
            public async Task Default_LinesReaded()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(readAllLinesTestFolder, nameof(Default_LinesReaded));


                Directory.CreateDirectory(readAllLinesTestFolder);
                File.WriteAllLines(path, contents);

                var result = await AsyncFile.ReadAllLinesAsync(path).ConfigureAwait(false);

                CollectionAssert.AreEqual(contents, result);
            }

            [TestCaseSource(typeof(FileTests), nameof(encodings))]
            public async Task ReadAllLinesWithEncoding(Encoding encoding)
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(readAllLinesTestFolder, nameof(ReadAllLinesWithEncoding));

                Directory.CreateDirectory(readAllLinesTestFolder);
                File.WriteAllLines(path, contents, encoding);

                var result = await AsyncFile.ReadAllLinesAsync(path, encoding).ConfigureAwait(false);

                CollectionAssert.AreEqual(contents, result);
            }

            [Test]
            public void CancellationToken_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 30000).ToList();
                var path = Path.Combine(readAllLinesTestFolder, nameof(CancellationToken_ExceptionThrown));

                Directory.CreateDirectory(readAllLinesTestFolder);
                File.WriteAllLines(path, contents);

                var tokenSource = new CancellationTokenSource();
                Assert.ThrowsAsync<TaskCanceledException>(async () =>
                                                          {
                                                              tokenSource.Cancel();
                                                              await AsyncFile.ReadAllLinesAsync(path, tokenSource.Token).ConfigureAwait(false);
                                                          });
            }

            [Test]
            public void NullEncoding_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 30000).ToList();
                var path = Path.Combine(readAllLinesTestFolder, nameof(NullEncoding_ExceptionThrown));

                Directory.CreateDirectory(FileTestFolder);
                File.WriteAllLines(path, contents);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.ReadAllLinesAsync(path, null).ConfigureAwait(false));
            }
        }

        [TestFixture]
        public class ReadAllTextAsyncMethod
        {
            private readonly string readAllTextTestFolder = Path.Combine(FileTestFolder, nameof(ReadAllTextAsyncMethod));

            [Test]
            public async Task Default_LinesReaded()
            {
                var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
                var path = Path.Combine(readAllTextTestFolder, nameof(Default_LinesReaded));

                Directory.CreateDirectory(readAllTextTestFolder);
                File.WriteAllText(path, contents);

                var result = await AsyncFile.ReadAllTextAsync(path).ConfigureAwait(false);

                Assert.AreEqual(contents, result);
            }

            [TestCaseSource(typeof(FileTests), nameof(encodings))]
            public async Task ReadAllTextWithEncoding(Encoding encoding)
            {
                var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
                var path = Path.Combine(readAllTextTestFolder, nameof(ReadAllTextWithEncoding));

                Directory.CreateDirectory(readAllTextTestFolder);
                File.WriteAllText(path, contents, encoding);

                var result = await AsyncFile.ReadAllTextAsync(path, encoding).ConfigureAwait(false);

                Assert.AreEqual(contents, result);
            }



            [Test]
            public void NullEncoding_ExceptionThrown()
            {
                var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
                var path = Path.Combine(readAllTextTestFolder, nameof(NullEncoding_ExceptionThrown));

                Directory.CreateDirectory(readAllTextTestFolder);
                File.WriteAllText(path, contents);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.ReadAllTextAsync(path, null).ConfigureAwait(false));
            }
        }

        [TestFixture]
        public class WriteAllBytesAsyncMethod
        {
            private readonly string writeAllBytesTestFolder = Path.Combine(FileTestFolder, nameof(WriteAllBytesAsyncMethod));

            [Test]
            public async Task Default_BytesWritten()
            {
                var bytes = new byte[10000];
                var random = new Random();
                random.NextBytes(bytes);

                var path = Path.Combine(writeAllBytesTestFolder, nameof(Default_BytesWritten));
                Directory.CreateDirectory(writeAllBytesTestFolder);

                await AsyncFile.WriteAllBytesAsync(path, bytes).ConfigureAwait(false);

                var result = File.ReadAllBytes(path);

                CollectionAssert.AreEqual(bytes, result);
            }

            [Test]
            public async Task CancellationToken_ExceptionThrown()
            {
                var bytes = new byte[100000];
                var random = new Random();
                random.NextBytes(bytes);

                var path = Path.Combine(writeAllBytesTestFolder, nameof(CancellationToken_ExceptionThrown));
                Directory.CreateDirectory(writeAllBytesTestFolder);

                var tokenSource = new CancellationTokenSource();
                tokenSource.Cancel();
                Assert.ThrowsAsync<TaskCanceledException>(
                    async () => await AsyncFile.WriteAllBytesAsync(path, bytes, tokenSource.Token).ConfigureAwait(false));
            }
        }

        [TestFixture]
        public class WriteAllLinesAsyncMethod
        {
            private readonly string writeAllLinesTestFolder = Path.Combine(FileTestFolder, nameof(WriteAllLinesAsyncMethod));

            [Test]
            public async Task Default_LinesAppended()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(writeAllLinesTestFolder, nameof(Default_LinesAppended));

                Directory.CreateDirectory(writeAllLinesTestFolder);

                await AsyncFile.WriteAllLinesAsync(path, contents);

                var result = File.ReadAllLines(path);

                CollectionAssert.AreEqual(contents, result);
            }

            [TestCaseSource(typeof(FileTests), nameof(encodings))]
            public async Task WriteAllLinesWithEncoding(Encoding encoding)
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(writeAllLinesTestFolder, nameof(WriteAllLinesWithEncoding));

                Directory.CreateDirectory(writeAllLinesTestFolder);

                await AsyncFile.WriteAllLinesAsync(path, contents, encoding);

                var result = File.ReadAllLines(path, encoding);

                CollectionAssert.AreEqual(contents, result);
            }

            [Test]
            public void CancellationToken_LinesAppendedAndExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 30000).ToList();
                var path = Path.Combine(writeAllLinesTestFolder, nameof(CancellationToken_LinesAppendedAndExceptionThrown));
                Directory.CreateDirectory(writeAllLinesTestFolder);

                var tokenSource = new CancellationTokenSource();
                Assert.ThrowsAsync<TaskCanceledException>(async () =>
                                                          {
                                                              var task = AsyncFile.WriteAllLinesAsync(path, contents, tokenSource.Token);
                                                              tokenSource.Cancel();
                                                              await task;
                                                          });

                var result = File.ReadAllLines(path);

                Assert.IsTrue(contents.Count > result.Length);
            }

            [Test]
            public void NullContent_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(writeAllLinesTestFolder, nameof(NullContent_ExceptionThrown));

                Directory.CreateDirectory(writeAllLinesTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.WriteAllLinesAsync(path, null));
            }

            [Test]
            public async Task WriteAllLinesAsync_NullEncoding_ExceptionThrown()
            {
                var contents = Enumerable.Repeat("This is a test line.", 150).ToList();
                var path = Path.Combine(writeAllLinesTestFolder, nameof(NullContent_ExceptionThrown));

                Directory.CreateDirectory(writeAllLinesTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.WriteAllLinesAsync(path, contents, null));
            }
        }

        [TestFixture]
        public class WriteAllTextAsyncMethod
        {
            private readonly string writeAllTextTestFolder = Path.Combine(FileTestFolder, nameof(WriteAllTextAsyncMethod));

            [Test]
            public async Task Default_TextAppended()
            {
                var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
                var path = Path.Combine(writeAllTextTestFolder, nameof(Default_TextAppended));

                Directory.CreateDirectory(writeAllTextTestFolder);

                await AsyncFile.WriteAllTextAsync(path, contents);

                var result = File.ReadAllText(path);

                Assert.AreEqual(contents, result);
            }

            [TestCaseSource(typeof(FileTests), nameof(encodings))]
            public async Task WriteAllTextWithEncoding(Encoding encoding)
            {
                var contents = string.Join(Environment.NewLine, Enumerable.Repeat("This is a test line.", 150));
                var path = Path.Combine(writeAllTextTestFolder, nameof(WriteAllTextWithEncoding));

                Directory.CreateDirectory(writeAllTextTestFolder);

                await AsyncFile.WriteAllTextAsync(path, contents, encoding);

                var result = File.ReadAllText(path, encoding);

                Assert.AreEqual(contents, result);
            }

            [Test]
            public void NullContent_ExceptionThrown()
            {
                var path = Path.Combine(writeAllTextTestFolder, nameof(NullContent_ExceptionThrown));

                Directory.CreateDirectory(writeAllTextTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.WriteAllTextAsync(path, null));
            }

            [Test]
            public void WriteAllTextAsync_NullEncoding_ExceptionThrown()
            {
                const string content = "This is a test line.";
                var path = Path.Combine(writeAllTextTestFolder, nameof(NullContent_ExceptionThrown));

                Directory.CreateDirectory(writeAllTextTestFolder);

                Assert.ThrowsAsync<ArgumentNullException>(async () => await AsyncFile.WriteAllTextAsync(path, content, null));
            }
        }
    }
}