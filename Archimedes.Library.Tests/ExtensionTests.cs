using System;
using Archimedes.Library.Extensions;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void Should_return_formatted_date()
        {
            var test = new DateTime(2020, 01, 01, 10, 10, 00);

            test.BrokerDate();

        }


        [Test]
        public void Should_ReturnNumberFromString()
        {
            var subject = "15Min";
            var result = subject.ExtractTimeInterval();

            Assert.AreEqual(15,result);
        }
    }
}