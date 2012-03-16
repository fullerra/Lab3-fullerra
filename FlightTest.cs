using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime TestDateThatFlightLeaves = new DateTime(2012, 4, 10);
        private readonly DateTime TestDateThatFlightReturns = new DateTime(2012, 4, 11);
        private readonly int TestMiles = 1;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(TestDateThatFlightLeaves, TestDateThatFlightReturns, TestMiles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnEndDateBeforeStartDate()
        {
            new Flight(TestDateThatFlightReturns, TestDateThatFlightLeaves, TestMiles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnMilesLessThanZero()
        {
            new Flight(TestDateThatFlightLeaves, TestDateThatFlightReturns, -1);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlightReturn()
        {
            var target = new Flight(new DateTime(2012, 4, 10), new DateTime(2012, 4, 11), 1);
            Assert.AreEqual(200 + (1 * 20), target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlightReturn()
        {
            var target = new Flight(new DateTime(2012, 4, 10), new DateTime(2012, 4, 12), 1);
            Assert.AreEqual(200 + (2 * 20), target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlightReturn()
        {
            var target = new Flight(new DateTime(2012, 4, 10), new DateTime(2012, 4, 20), 1);
            Assert.AreEqual(200 + (10 * 20), target.getBasePrice());
        }
	}
}
