using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

    [TestFixture]
    class TestCurrencyConverterService
    {
        CurrencyConverterClient client;
        [TestFixtureSetUp]
        public void Setup()
        {
            client = new CurrencyConverterClient();
        }

        [Test]
        public void TestDollarsToPounds()
        {
            double result = client.DollarsToPounds(10.00);
            Assert.AreEqual(6.60, Math.Round(result, 2));
        }

        [Test]
        public void TestPoundssToDollars()
        {
            double result = client.PoundsToDollars(10.00);
            Assert.AreEqual(15.20, Math.Round(result, 2));
        }

        [Test]
        public void TestEurosToPounds()
        {
            double result = client.EurosToPounds(10.00);
            Assert.AreEqual(8.50, Math.Round(result, 2));
        }

        [Test]
        public void TestPoundssToEuros()
        {
            double result = client.PoundsToEuros(10.00);
            Assert.AreEqual(11.70, Math.Round(result, 2));
        }
    }

