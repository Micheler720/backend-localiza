﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Infra.Database.Implementations.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Domains.Repositories;
using Domains.UseCase.AppointmentService;
using Shared.Exceptions;
using Domains.UseCase.AppointmentService.Exceptions;
using Infra.Database.Implementations.EntityFramework.Repositories.AppointmentRepository;
using ViewModel.Appointments;
using Domains.UseCase.Builder;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly ILogger<ChecklistController> _logger;
        private readonly IChecklistRepository<CheckList> _context;
        private readonly IAppointmentRepository<Appointment> _contextAppointment;
        private readonly CheckListSaveService _save;
        private readonly ChekListListService _list;
        private readonly CheckListDeleteService _delete;

        public ChecklistController(ILogger<ChecklistController> logger, ContextEntity context)
        {
            _logger = logger;
            _context =  new ChecklistRepositoryEntity(context);
            _contextAppointment = new AppointmentRepositoryEntity(context);
            _save = new CheckListSaveService(_contextAppointment);
            _list = new ChekListListService(_context);
            _delete = new CheckListDeleteService(_context);
        }

        [HttpGet]
        [Route("/appointments/checklist")]
        [AllowAnonymous]
        public async Task<List<CheckList>> Get ()
        {
            return await this._list.Execute();
        }

        [HttpPost]
        [Route("/appointments/checklist/{idAppointment}")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CheckListSave checklistBody, int idAppointment)
        {
            try
            {
                var cheklist = EntityBuilder.Call<CheckList>(checklistBody);
                await _save.Execute(cheklist, idAppointment, checklistBody.DateTimeDelivery );                
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
        [Route("/appointments/checklist/{idAppointment}/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update([FromBody] CheckListSave checklistBody, int idAppointment, int id)
        {
            try
            {
                var checkList = EntityBuilder.Call<CheckList>(checklistBody);
                checkList.Id = id;                
                await _save.Execute(checkList, idAppointment, checklistBody.DateTimeDelivery);
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
            }
        }
        [HttpDelete]
        [Route("/appointments/checklist/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _delete.Execute(id);
                return StatusCode(204);
            }
            catch(NotFoundRegisterException err)
            {
                return StatusCode(404, new {
                    Message = err.Message
                });
            }
        }
        
    }
}
