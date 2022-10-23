using DeveloperApiService.Data.Contracts;
using DeveloperApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DeveloperApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandersController : ControllerBase
    {
        private readonly ICommander repo;

        public CommandersController(ICommander repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandDetail>> GetAllCommand()
        {
            try
            {
                var objGetAll = repo.GetAll();
                return Ok(objGetAll);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{Id}", Name = "GetByIdCommand")]
        public ActionResult<CommandDetail> GetByIdCommand(int Id)
        {
            try
            {
                var obj = repo.GetById(Id);
                if (obj == null)
                {
                    return NotFound();
                }
                return Ok(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("{Id}")]
        public ActionResult<CommandDetail> UpdateCommand(int Id, CommandDetail obj)
        {
            try
            {
                repo.Update(Id, obj);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteCommand(int Id)
        {
            try
            {
                var obj = repo.GetById(Id);

                if (obj == null)
                {
                    return NotFound();
                }
                repo.Delete(obj);
                repo.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<CommandDetail> CreateCommand(CommandDetail obj)
        {
            try
            {
                repo.Create(obj);
                return CreatedAtRoute(nameof(GetByIdCommand), new { Id = obj.Id }, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
