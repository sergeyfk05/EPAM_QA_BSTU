using Aircompany;
using Aircompany.Models;
using Aircompany.Planes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AircompanyTests.Tests
{
    [TestFixture]
    public class AirportTest
    {
        private readonly List<Plane> planes = new List<Plane>(){
           new PassengerPlane("Boeing-737", 900, 12000, 60500, 164),
           new PassengerPlane("Boeing-737-800", 940, 12300, 63870, 192),
           new PassengerPlane("Boeing-747", 980, 16100, 70500, 9999),
           new PassengerPlane("Airbus A320", 930, 11800, 65500, 188),
           new PassengerPlane("Airbus A330", 990, 14800, 80500, 222),
           new PassengerPlane("Embraer 190", 870, 8100, 30800, 64),
           new PassengerPlane("Sukhoi Superjet 100", 870, 11500, 50500, 140),
           new PassengerPlane("Bombardier CS300", 920, 11000, 60700, 196),
           new MilitaryPlane("B-1B Lancer", 1050, 21000, 80000, MilitaryAirplaneType.Bomber),
           new MilitaryPlane("B-2 Spirit", 1030, 22000, 70000, MilitaryAirplaneType.Bomber),
           new MilitaryPlane("B-52 Stratofortress", 1000, 20000, 80000, MilitaryAirplaneType.Bomber),
           new MilitaryPlane("F-15", 1500, 12000, 10000, MilitaryAirplaneType.Fighter),
           new MilitaryPlane("F-22", 1550, 13000, 11000, MilitaryAirplaneType.Fighter),
           new MilitaryPlane("C-130 Hercules", 650, 5000, 110000, MilitaryAirplaneType.Transport)
        };

        private const int MaxPassengerCapacityOfPassengerPlanes = 9999;

        [Test]
        public void GetPassengerPlanesTest()
        {
            Airport airport = new Airport(planes);
            List<PassengerPlane> passengerPlanes = airport.GetPassengerPlanes();
            Assert.IsNull(passengerPlanes.FirstOrDefault(x => !(x is PassengerPlane)));
        }
        [Test]
        public void GetMilitaryPlanesTest()
        {
            Airport airport = new Airport(planes);
            List<MilitaryPlane> militaryPlanes = airport.GetMilitaryPlanes();
            Assert.IsNull(militaryPlanes.FirstOrDefault(x => !(x is MilitaryPlane)));
        }

        private bool IsListContainsOnlySelectedMilitaryAirplaneType(List<MilitaryPlane> militaryPlanes, MilitaryAirplaneType airplaneType)
        {
            return militaryPlanes.FirstOrDefault(x => x.GetPlaneType() != airplaneType) == null;
        }

        [Test]
        public void GetTransportMilitaryPlanesTest()
        {
            Airport airport = new Airport(planes);
            List<MilitaryPlane> transportMilitaryPlanes = airport.GetTransportMilitaryPlanes();
            Assert.IsTrue(IsListContainsOnlySelectedMilitaryAirplaneType(transportMilitaryPlanes, MilitaryAirplaneType.Transport));
        }
        [Test]
        public void GetFighterMilitaryPlanesTest()
        {
            Airport airport = new Airport(planes);
            List<MilitaryPlane> transportMilitaryPlanes = airport.GetFighterMilitaryPlanes();
            Assert.IsTrue(IsListContainsOnlySelectedMilitaryAirplaneType(transportMilitaryPlanes, MilitaryAirplaneType.Fighter));
        }
        [Test]
        public void GetBomberMilitaryPlanesTest()
        {
            Airport airport = new Airport(planes);
            List<MilitaryPlane> transportMilitaryPlanes = airport.GetBomberMilitaryPlanes();
            Assert.IsTrue(IsListContainsOnlySelectedMilitaryAirplaneType(transportMilitaryPlanes, MilitaryAirplaneType.Bomber));
        }

        [Test]
        public void GetMaxPassengersCapacityPassengerPlaneTest()
        {
            Airport airport = new Airport(planes);
            Assert.IsTrue(airport.GetMaxPassengersCapacityPassengerPlane().GetPassengersCapacity() == MaxPassengerCapacityOfPassengerPlanes);
        }

        [Test]
        public void SortByMaxFlightDistanceTest()
        {
            Airport sortedAirport = new Airport(planes).SortByMaxFlightDistance();
            int currentMaxFlightDistance = -1;

            foreach(var el in sortedAirport.GetPlanes())
            {
                if (el.GetMaxFlightDistance() < currentMaxFlightDistance)
                    Assert.Fail();

                currentMaxFlightDistance = el.GetMaxFlightDistance();
            }

            Assert.Pass();
        }

        [Test]
        public void SortByMaxSpeedTest()
        {
            Airport sortedAirport = new Airport(planes).SortByMaxSpeed();
            int currentMaxSpeed = -1;

            foreach (var el in sortedAirport.GetPlanes())
            {
                if (el.GetMaxSpeed() < currentMaxSpeed)
                    Assert.Fail();

                currentMaxSpeed = el.GetMaxSpeed();
            }

            Assert.Pass();
        }

        [Test]
        public void SortByMaxLoadCapacityTest()
        {
            Airport sortedAirport = new Airport(planes).SortByMaxLoadCapacity();
            int currentMaxLoadCapacity = -1;

            foreach (var el in sortedAirport.GetPlanes())
            {
                if (el.GetMaxLoadCapacity() < currentMaxLoadCapacity)
                    Assert.Fail();

                currentMaxLoadCapacity = el.GetMaxLoadCapacity();
            }

            Assert.Pass();
        }

    }
}
