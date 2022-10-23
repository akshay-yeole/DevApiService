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
    public class UsefulLinksController : ControllerBase
    {
        private readonly ILinkRepo repo;

        public UsefulLinksController(ILinkRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LinkInfo>> GetAllLinkInfo()
        {
            try
            {
                var allLinks = repo.GetAll();
                if (allLinks == null)
                {
                    return NotFound();
                }
                return Ok(allLinks);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{Id}", Name = "GetByIdLinkInfo")]
        public ActionResult<IEnumerable<LinkInfo>> GetByIdLinkInfo(int Id)
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

        [HttpPost]
        public ActionResult<LinkInfo> CreateLinkInfo(LinkInfo obj)
        {
            try
            {
                repo.Create(obj);
                return CreatedAtRoute(nameof(GetByIdLinkInfo), new { Id = obj.Id }, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{Id}")]
        public ActionResult<LinkInfo> UpdateLinkInfo(int Id, LinkInfo obj)
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
        public ActionResult DeleteLinkInfo(int Id)
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
    }
}
