using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Database.Implementations.EntityFramework.Repositories.AppointmentRepository
{
    public class AppointmentRepositoryEntity  : BaseEntityRepository<Appointment>, IAppointmentRepository<Appointment>
    {
        public AppointmentRepositoryEntity(ContextEntity context) : base(context)
        {

            this._context = context;

        }

        public async Task<Appointment> FindById(int id)
        {
            var query = from a in _context.Appointments
                where  id == a.Id
                select a;
            return await query.FirstOrDefaultAsync<Appointment>() as Appointment;
        }

        public async Task<Boolean> CheckAvailabilityCar(int idCar, DateTime DateTimeExpectedCollected )
        {
            var query = from a in _context.Appointments
                where  idCar == a.IdCar && a.DateTimeCollected == null
                && a.DateTimeExpectedDelivery > DateTimeExpectedCollected
                select a;
            return await query.FirstOrDefaultAsync<Appointment>() == null;
        }

        public async Task<Boolean> CheckAvailabilityClient(int idClient, DateTime DateTimeExpectedCollected )
        {
            var query = from a in _context.Appointments
                where  idClient == a.IdClient && a.DateTimeCollected == null
                && a.DateTimeExpectedDelivery > DateTimeExpectedCollected
                select a;
            return await query.FirstOrDefaultAsync<Appointment>() == null;
        }

        
    }
}