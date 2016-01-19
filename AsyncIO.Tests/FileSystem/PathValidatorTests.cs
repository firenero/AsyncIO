using System;
using System.IO;
using System.Linq;
using AsyncIO.FileSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsyncIO.Tests.FileSystem
{
    [TestClass]
    public class PathValidatorTests
    {
        [TestMethod]
        public void EnsureCorrectFileSystemPath_Default_True()
        {
            PathValidator.EnsureCorrectFileSystemPath(Environment.CurrentDirectory);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void EnsureCorrectFileSystemPath_Null_ExceptionThrown()
        {
            PathValidator.EnsureCorrectFileSystemPath(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureCorrectFileSystemPath_EmptyString_ExceptionThrown()
        {
            PathValidator.EnsureCorrectFileSystemPath(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureCorrectFileSystemPath_WhitespaceString_ExceptionThrown()
        {
            PathValidator.EnsureCorrectFileSystemPath("   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EnsureCorrectFileSystemPath_HasInvalidChars_ExceptionThrown()
        {
            PathValidator.EnsureCorrectFileSystemPath(Environment.CurrentDirectory + Path.GetInvalidPathChars().First());
        }
    }
}