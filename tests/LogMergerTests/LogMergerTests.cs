using LogMerger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogMergerTests
{
    [TestClass]
    public class LogMergerTests
    {
        //2018-06-29 14:14:46.675 Hello Refract!
        //2018-06-29 14:15:00.123 Goodbye Refract!
        private readonly Log[] Input1Logs = new Log[]
            {
                new Log
                (
                    new DateTime(2018, 06, 29, 14, 14, 46, 675),
                    "Hello Refract!"
                ),
                new Log
                (
                    new DateTime(2018, 06, 29, 14, 15, 00, 123),
                    "Goodbye Refract!"
                ),
            };

        private readonly string InputPath1    = "resources/test-input1.txt";
        private readonly string InputPath2    = "resources/test-input2.txt";
        private readonly string OutputPath12  = "resources/test-output12.txt";

        private readonly string InputPath3    = "resources/test-input3.txt";
        private readonly string OutputPath123 = "resources/test-output123.txt";

        [TestMethod]
        public void Reader_Works()
        {
            var expected = Input1Logs;
            var result = LogReader.Read(InputPath1);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Writer_Works()
        {
            var expected = LogReader.Read(InputPath1);

            var testPath = "writer-test.txt";
            FileLogWriter.Write(testPath, Input1Logs);
            var result = LogReader.Read(testPath);
            
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void One_Input()
        {
            var expected = LogReader.Read(InputPath1);
            var result = new LogMerger.LogMerger().Merge(new string[] { InputPath1 });
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Duplicate_Input()
        {
            var expected = LogReader.Read(InputPath1);
            var result = new LogMerger.LogMerger().Merge(new string[] { InputPath1, InputPath1 });
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Will_Merge_Two_In_Order()
        {
            var expected = LogReader.Read(OutputPath12);
            var result = new LogMerger.LogMerger().Merge(new string[] { InputPath1, InputPath2 });
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Will_Merge_Three_In_Order() // Also contains 2 logs with the same timestamp
        {
            var expected = LogReader.Read(OutputPath123);
            var result = new LogMerger.LogMerger().Merge(new string[] { InputPath1, InputPath2, InputPath3 });
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
