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
        public ActionResult<IEnumerable<LinkInfo>> GetAllLinks()
        {
            try
            {
                var allLinks = repo.GetAllLinks();
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

        [HttpGet("{Id}", Name = "GetLinkInfoById")]
        public ActionResult<IEnumerable<LinkInfo>> GetLinkInfoById(int Id)
        {
            try
            {
                var linkInfo = repo.GetLinkInfoById(Id);
                if (linkInfo == null)
                {
                    return NotFound();
                }
                return Ok(linkInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<LinkInfo> CreateLinkInfo(LinkInfo linkInfo)
        {
            try
            {
                repo.CreateLinkInfo(linkInfo);
                return CreatedAtRoute(nameof(GetLinkInfoById), new { Id = linkInfo.Id }, linkInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{Id}")]
        public ActionResult<LinkInfo> UpdateCommand(int Id, LinkInfo linkInfo)
        {
            try
            {
                repo.UpdateLinkInfo(Id, linkInfo);
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
                var command = repo.GetLinkInfoById(Id);

                if (command == null)
                {
                    return NotFound();
                }
                repo.DeleteLinkInfo(command);
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
