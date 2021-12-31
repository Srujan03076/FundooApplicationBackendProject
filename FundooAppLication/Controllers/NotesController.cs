using BussinessLayer.Interfaces;
using CommonLayer.Model;
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
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBL;
        public NotesController(INotesBL notesBL)
        {
            this.notesBL = notesBL;
        }
        [HttpPost]
        public IActionResult MakeANote(UserNotes notes)
        {
            try
            {
                if (this.notesBL.MakeANote(notes))
                {
                    return this.Ok(new { Success = true, message = "New note created successfully " });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "New node creation unsuccessful" });
                }

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.InnerException });
            }
        }
        [HttpGet("getalldata")]
        public IActionResult GetAllNotesData()
        {
            try
            {
                var notesDetails = this.notesBL.GetAllNotesData();
                if (notesDetails == null)
                {
                    return this.BadRequest(new { Success = false, message = " Notes records not found" });
                }
                return this.Ok(new { Success = true, message = "Notes records found", notesdata = notesDetails });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.InnerException });
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteNotes( DeleteNote deletenotes)
        {
            try
            {
                if (this.notesBL.DeleteNotes(deletenotes))
                {
                    return this.Ok(new { Success = true, message = " Registration Deleted" });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "No Such Registration Found" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException });
            }
        }
    }
}






            

       

    
   

