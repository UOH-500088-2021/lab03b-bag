using DataProcessor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethodCountForces()
        {
            var reader = new DataReader();
            reader.FileName = "police_101_call_test_data.csv";
            reader.ReadData();
            var expected = 8;
            var result = reader.NumberOfForces;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMethodAverageCalls()
        {
            var reader = new DataReader();
            reader.FileName = "police_101_call_test_data.csv";
            reader.ReadData();
            var expected = 27870;
            var result = reader.AverageTotalCalls;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAbondomentRate()
        {
            var reader = new DataReader();
            reader.FileName = "police_101_call_test_data.csv";
            var expected = "Avon and Somerset Constabulary";
            reader.ReadData();
            var result = reader.HighestAbandonmentRateName;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void RankedListJan()
        {
            var reader = new DataReader();
            reader.FileName = "police_101_call_test_data.csv";
            List<string> expected = new List<string>{ "Cumbria Constabulary", "Cambridgeshire Constabulary", "City of London Police", "Cleveland Police", "Cheshire Constabulary", "Bedfordshire Police", "British Transport Police", "Avon and Somerset Constabulary" };
            reader.ReadData();
            var result = reader.RankedListJan;
            for (int i =0;i<expected.Count();i++) 
            {
                Assert.AreEqual(expected[i],result[i]);
            }
        }
    }
}
