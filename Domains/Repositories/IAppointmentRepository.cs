using System;
using System.Threading.Tasks;
using Entities;

namespace Domains.Repositories
{
    public interface IAppointmentRepository<Appointment> : IBaseRepository<Appointment> where Appointment : class
    {
        Task<Appointment> FindById(int id);
        Task<Boolean> CheckAvailabilityCar(int idCar, DateTime dateTimeExpectedCollected );
        Task<Boolean> CheckAvailabilityClient(int idClient, DateTime dateTimeExpectedCollected );
        
    }
}