using DeveloperApiService.Data.Contracts;
using DeveloperApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var allLinks = repo.GetAllLinks();
            if (allLinks == null)
            {
                return NotFound();
            }
            return Ok(allLinks);
        }

        [HttpGet("{Id}", Name = "GetLinkInfoById")]
        public ActionResult<IEnumerable<LinkInfo>> GetLinkInfoById(int Id)
        {
            var linkInfo = repo.GetLinkInfoById(Id);
            if (linkInfo == null)
            {
                return NotFound();
            }
            return Ok(linkInfo);
        }

        [HttpPost]
        public ActionResult<LinkInfo> CreateLinkInfo(LinkInfo linkInfo)
        {
            repo.CreateLinkInfo(linkInfo);
            return CreatedAtRoute(nameof(GetLinkInfoById), new { Id = linkInfo.Id }, linkInfo);
        }

        [HttpPut("{Id}")]
        public ActionResult<LinkInfo> UpdateCommand(int Id, LinkInfo linkInfo)
        {
            repo.UpdateLinkInfo(Id, linkInfo);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public ActionResult DeleteCommand(int Id)
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
    }
}
