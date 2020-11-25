using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengerPlanes()
        {
            return Planes.OfType<PassengerPlane>().ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.OfType<MilitaryPlane>().ToList();
        }

        public PassengerPlane GetMaxPassengersCapacityPassengerPlane()
        {
            int maxPassengersCapacity = GetPassengerPlanes().Max(x => x.GetPassengersCapacity());
            return GetPassengerPlanes().FirstOrDefault(x => x.GetPassengersCapacity() == maxPassengersCapacity);       
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(x => x.GetPlaneType() == MilitaryAirplaneType.Transport).ToList();
        }

        public List<MilitaryPlane> GetFighterMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(x => x.GetPlaneType() == MilitaryAirplaneType.Fighter).ToList();
        }

        public List<MilitaryPlane> GetBomberMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(x => x.GetPlaneType() == MilitaryAirplaneType.Bomber).ToList();
        }

        public Airport SortByMaxFlightDistance()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return Planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.GetAirplaneModel())) +
                    '}';
        }
    }
}
