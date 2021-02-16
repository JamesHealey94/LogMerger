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
                {
                    DateTime = new DateTime(2018, 06, 29, 14, 14, 46, 675),
                    Message = "Hello Refract!"
                },
                new Log
                {
                    DateTime = new DateTime(2018, 06, 29, 14, 15, 00, 123),
                    Message = "Goodbye Refract!"
                },
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
            var result = new LogReader.Read(InputPath1);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Writer_Works()
        {
            var expected = new LogReader.Read(InputPath1);
            var result = new LogWriter.Write("writer-test.txt", Input1Logs);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void One_Input()
        {
            var expected = new LogReader.Read(InputPath1);
            var result = new LogMerger.LogMerger().Merge(new string[] { InputPath1 });
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Duplicate_Input()
        {
            var expected = new LogReader.Read(InputPath1);
            var result = new LogMerger.LogMerger().Merge(InputPath1, new string[] { InputPath1, InputPath1 });
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Will_Merge_Two_In_Order()
        {
            var expected = new LogReader.Read(InputPath12);
            var result = new LogMerger.LogMerger().Merge(OutputPath12, new string[] { InputPath1, InputPath2 });
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Will_Merge_Three_In_Order()
        {
            var expected = new LogReader.Read(InputPath123);
            var result = new LogMerger.LogMerger().Merge(OutputPath123, new string[] { InputPath1, InputPath2, InputPath3 });
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
