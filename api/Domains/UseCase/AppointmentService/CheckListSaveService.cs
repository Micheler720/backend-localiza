using System;
using System.Threading.Tasks;
using Domains.Repositories;
using Domains.UseCase.AppointmentService.Exceptions;
using Entities;
using Shared.Exceptions;

namespace Domains.UseCase.AppointmentService
{
    public class CheckListSaveService
    {
        private IAppointmentRepository<Appointment> _repository;

        public CheckListSaveService( IAppointmentRepository<Appointment> repository)
        {
            _repository = repository;
        }

        public async Task Execute(CheckList checklist, int idAppointment, DateTime dateTimeDelivery)
        {

            if(idAppointment == 0) throw new NotFoundRegisterException("Appointment não Encontrado. Verifique");
            var appointment = await _repository.FindById(idAppointment);
            if(appointment == null) throw new NotFoundRegisterException("Appointment não Encontrado. Verifique");
            if(appointment.DateTimeCollected == null) throw new     ("Carro não foi alocado. Verifique para realizar vistória.");
            if(appointment.DateTimeCollected > dateTimeDelivery) throw new DateTimeColectedInvalidException("A data de devolução é menor que a data coletada. Verifique para realizar vistória.");
            
            appointment.DateTimeDelivery = dateTimeDelivery;
            appointment.Inspected = true;
            if(appointment.IdCheckList != null ) checklist.Id = (int)appointment.IdCheckList;
            appointment.CheckList = checklist;

            
            await _repository.Update(appointment);
        }
    }
}