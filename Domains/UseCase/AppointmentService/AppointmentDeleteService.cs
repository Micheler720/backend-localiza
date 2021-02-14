using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.AppointmentService.Exceptions;
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
            if(appointment.DateTimeCollected != null && appointment.DateTimeDelivery == null ) throw new AppointmentNotExcludeException("Carro possui agendamento em aberto. Verifique para exclusão.");
            await _repository.Delete(appointment);
        }
    }
}