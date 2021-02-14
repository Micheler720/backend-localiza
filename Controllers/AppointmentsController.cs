using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.UseCase.UserServices.Exceptions;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Domains.Repositories;
using Infra.Database.Implementations.EntityFramework.Repositories.UsersRespository;
using Infra.Database.Implementations.EntityFramework.Repositories.AppointmentRepository;
using Domains.UseCase.AppointmentService;
using ViewModel.Appointments;
using Domains.UseCase.Builder;
using Infra.Database.Implementations.EntityFramework.Repositories.CarsRepository;
using Shared.Exceptions;
using Domains.UseCase.AppointmentService.Exceptions;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly IAppointmentRepository<Appointment> _context;
        private readonly ICarRepository<Car> _contextCar;
        private readonly IClientRepository<Client> _contextClient;
        private readonly IOperatorRepository<Operator> _contextOperator;
        private readonly AppointmentSaveService _save;
        private readonly AppointmentListService _list;
        private readonly AppointmentDeleteService _delete;

        public AppointmentsController(ILogger<AppointmentsController> logger, ContextEntity context)
        {
            _logger = logger;
            _context =  new AppointmentRepositoryEntity(context);
            _contextClient = new ClientRepositoryEntity(context);
            _contextOperator = new OperatorRepositoryEntity(context);
            _contextCar = new CarRepositoryEntity(context);
            _save = new AppointmentSaveService(_context, _contextCar, _contextClient, _contextOperator);
            _list = new AppointmentListService(_context);
            _delete = new AppointmentDeleteService(_context);
        }

        [HttpGet]
        [Route("/appointments")]
        [AllowAnonymous]
        public async Task<List<Appointment>> Get ()
        {
            return await this._list.Execute();
        }

        [HttpPost]
        [Route("/appointments")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] AppointmentCreateView appointmentBody)
        {
            try
            {
                await _save.Execute(EntityBuilder.Call<Appointment>(appointmentBody));                
                return StatusCode(201);
            }
            catch(NotFoundRegisterException err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }catch(CarNotAvalabityException err)
            {
                 return StatusCode(401, new {
                    Message = err.Message
                });
            }catch(ClientNotAvalabityException err)
            {
                 return StatusCode(401, new {
                    Message = err.Message
            });
            }catch(DateTimeColectedInvalidException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }catch(ValuesInvalidException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }

        [HttpPut]
        [Route("/appointments/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody]AppointmentUpdateView appointmentBody, int id)
        {
            try
            {   var appointment = EntityBuilder.Call<Appointment>(appointmentBody);
                appointment.Id = id;             
                await _save.Execute(appointment);
                return StatusCode(204);
            }
            catch(NotFoundRegisterException err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }catch(DateTimeColectedInvalidException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }catch(ValuesInvalidException err)
            {
                return StatusCode(401, new {
                    Message = err.Message
                });
            }
        }
        [HttpDelete]
        [Route("/appointments/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _delete.Execute(id);
                return StatusCode(204);
            }
            catch(UserNotFound err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }
        }

        

        
    }
}
