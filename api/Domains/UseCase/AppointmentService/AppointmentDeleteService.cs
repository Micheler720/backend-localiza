using System.Threading.Tasks;
using Domains.Repositories;
using Entities;
using Shared.Exceptions;

namespace Domains.UseCase.AppointmentService
{
    public class AppointmentDeleteService
    {
        private IAppointmentRepository<Appointment> _repository;

        public AppointmentDeleteService(IAppointmentRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Execute(int id)
        {
            
            if(id == 0) throw new NotFoundRegisterException("Agendamento não Encontrado.");
            var appointment = await _repository.FindById(id);
            if(appointment == null ) throw new NotFoundRegisterException("Agendamento não Encontrado.");
            await _repository.Delete(appointment);
        }
    }
}