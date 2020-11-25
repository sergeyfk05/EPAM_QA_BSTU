using Aircompany.Planes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircompanyTests.Tests.Planes
{
    [TestFixture]
    public class PlaneTest
    {
        private readonly PassengerPlane passengerPlane = new PassengerPlane("model", 999, 9999, 99999, 123);
        private readonly MilitaryPlane militaryPlane = new MilitaryPlane("model", 999, 9999, 99999,Aircompany.Models.MilitaryAirplaneType.Transport);
        [Test]
        public void GetPassengerAirplaneModelTest()
        {
            Assert.AreEqual("model", passengerPlane.GetAirplaneModel());
        }

        [Test]
        public void GetPassengerPlaneMaxSpeedTest()
        {
            Assert.AreEqual(999, passengerPlane.GetMaxSpeed());
        }

        [Test]
        public void GetPassengerPlaneMaxFlightDistanceTest()
        {
            Assert.AreEqual(9999, passengerPlane.GetMaxFlightDistance());
        }

        [Test]
        public void GetPassengerPlaneMaxLoadCapacityTest()
        {
            Assert.AreEqual(99999, passengerPlane.GetMaxLoadCapacity());
        }

        [Test]
        public void GetMilitaryAirplaneModelTest()
        {
            Assert.AreEqual("model", militaryPlane.GetAirplaneModel());
        }

        [Test]
        public void GetMilitaryPlaneMaxSpeedTest()
        {
            Assert.AreEqual(999, militaryPlane.GetMaxSpeed());
        }

        [Test]
        public void GetMilitaryPlaneMaxFlightDistanceTest()
        {
            Assert.AreEqual(9999, militaryPlane.GetMaxFlightDistance());
        }

        [Test]
        public void GetMilitaryPlaneMaxLoadCapacityTest()
        {
            Assert.AreEqual(99999, militaryPlane.GetMaxLoadCapacity());
        }
    }
}
