using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooAppLication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorBL collaboratorBL;
        public CollaboratorController(ICollaboratorBL collaboratorBL)
        {
            this.collaboratorBL = collaboratorBL;
        }
        /// <summary>
        ///API for Adding collaboration into notes
        /// </summary>
        /// <param name="collab"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult AddCollab(CollabModel collaboration)
        {
            try
            {
                long tokenId = Convert.ToInt64(User.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                
                if ( tokenId!=0)
                {
                    CollabModel collabModel = this.collaboratorBL.AddCollab(collaboration, tokenId);
                    return Ok(new { Success = true, message = "Collaboration Added Successfully.",Data= collaboration });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Adding Collaboration failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for Getting all data
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetCollaborator()
        {
            try
            {
                var collabDetails = this.collaboratorBL.GetCollaborator();
                if (collabDetails == null)
                {
                    return this.BadRequest(new { Success = false, message = " Collab records not found" });
                }
                else
                {
                    return this.Ok(new { Success = true, message = "Collab records found", collabdata = collabDetails });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for Remove collaboration in notes
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="emailId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        public IActionResult Deletecollab(CollabModel model)
        {
            try
            {
                var deletecollab = this.collaboratorBL.Deletecollab(model);
                if (deletecollab == true)
                {
                    return this.Ok(new { Success = true, message = "Delete Collab successfully" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = " Delete Collab Failed" });
                }

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
    }
}
