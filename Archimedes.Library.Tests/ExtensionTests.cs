using System;
using System.Runtime.CompilerServices;
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
    }
}