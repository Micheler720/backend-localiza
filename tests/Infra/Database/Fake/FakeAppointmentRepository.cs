using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Repositories;
using Entities;

namespace Infra.Database.Fake
{
    public class FakeAppointmentRepository : FakeBaseRepository<Appointment>, IAppointmentRepository<Appointment>
    {
        public async Task<bool> CheckAvailabilityCar(int idCar, DateTime dateTimeExpectedCollected)
        {
            await Task.Delay(2000);
            var car = this._data.Where(
                data => data.IdCar == idCar
                && data.DateTimeCollected == null 
                && data.DateTimeExpectedDelivery >= dateTimeExpectedCollected
            ).FirstOrDefault();
            return car == null;
        }

        public async Task<bool> CheckAvailabilityClient(int idClient, DateTime dateTimeExpectedCollected)
        {
            await Task.Delay(2000);
            var client = this._data.Where(
                data => data.IdClient == idClient
                && data.DateTimeCollected == null 
                && data.DateTimeExpectedDelivery < dateTimeExpectedCollected
            ).FirstOrDefault();
            return client != null;
        }

        public async Task<Appointment> FindById(int id)
        {
            await Task.Delay(2000);
            return this._data.Where(
                data => data.Id == id
            ).FirstOrDefault();
        }
    }
}