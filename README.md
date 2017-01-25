# AsyncIO

AsyncIO is easy-to-use .NET library for common async IO operations with file system. Operations implemented are fully asynchronous and do not block any threads.

AsyncIO provides decent control over async execution (e.g. support of [`CancellationToken`](https://msdn.microsoft.com/en-us/library/system.threading.cancellationtoken(v=vs.110).aspx)) and provides API for specifying [`Encoding`](https://msdn.microsoft.com/en-us/library/system.text.encoding(v=vs.110).aspx).

## Installation

You can install AsyncIO from [nuget](https://www.nuget.org/packages/AsyncIO.DotNet/).

Also, you can download compiled dll from the [releases page](https://github.com/FireNero/AsyncIO/releases).

## Usage

AsyncIO is very easy to use especially if you used [`System.IO.File`](https://msdn.microsoft.com/en-us/library/system.io.file(v=vs.110).aspx). There is a static class `AsyncFile` to access all supported async io operations.

### Examples

* Read text from file

```csharp
var text = await AsyncFile.ReadAllTextAsync("path_to_file");
```

* Read text from file with Encoding

```csharp
var text = await AsyncFile.ReadAllTextAsync("path_to_file", Encoding.UTF8);
```

* CancellationToken usage

```csharp
var tokenSource = new CancellationTokenSource();
try
{
    var moveTask = AsyncFile.MoveAsync("file_source_path", "file_destination_path", tokenSource.Token);
    tokenSource.Cancel();
    await moveTask;
}
catch (OperationCancelledException e)
{
    // Handle cancellation here.
}

```

### Supported methods

* AppendAllLinesAsync
* AppendAllTextAsync
* CopyAsync
* DeleteAsync
* MoveAsync
* ReadAllBytesAsync
* ReadAllLinesAsync
* ReadAllTextAsync
* WriteAllBytesAsync
* WriteAllLinesAsync
* WriteAllTextAsync

## Contribution

### Issues tracking

* Feel free to submit issues with or request new features via [GitHub Issues](https://github.com/FireNero/AsyncIO/issues).
* Before asking questions about library usage, please verify that it isn't covered in [Usage section](#usage).

### Pull requests

* Before creating new pull request, please create a ticket for it.

## Licence

Library is distributing under the MIT license. You can see details [here](https://github.com/FireNero/AsyncIO/blob/master/LICENSE).

## Roadmap

1. Add support of .NET Core.
1. Implement async analog of [`File.Replace`](https://msdn.microsoft.com/en-us/library/9d9h163f(v=vs.110).aspx) method.
