using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
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
        [Authorize]
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
        [Authorize]
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
        [HttpPut("Update")]
        public IActionResult UpdateNotes(UserNotes usernotes)
        {
            try
            {
                UserNotes userresponse = notesBL.UpdateNotes(usernotes);
                if (userresponse != null)

                {
                    return this.Ok(new { Success = true, message = " Updation Succesful", });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Not Successful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException });
            }
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteNotes(long Id)
        {
            try
            {
                if (this.notesBL.DeleteNotes(Id))
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
        [HttpPut("Archive")]
        public IActionResult IsArchive(int notesId)
        {
            try
            {
                 var result = this.notesBL.IsArchive(notesId);
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note archived Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException });
            }
        }
        [HttpPut("Unarchive")]
  
        public IActionResult Unarchive(int notesId)
        {
            try
            {
                var result = this.notesBL.UnArchive(notesId);
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note Unarchived Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException });
            }
        }

        [HttpPut("Pinnote")]
        public IActionResult NoteAddtionAsPinned(int notesId, long id)
        {
            try
            {
                var result = notesBL.NoteAddtionAsPinned(notesId, id);
                if (result == true)
                {
                    return Ok(new { success = true, message = "Pinned Successfully" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException });
            }
        }

        [HttpDelete("Trash")]
        public IActionResult Trash(int notesId)
        {
            try
            {
                var result = this.notesBL.Trash(notesId);
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note moved to trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccesful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException });
            }
        }
            
        

        [HttpPut("RestoreTrash")]
        public IActionResult RestoreTrash(int notesId)
        {
            try
            {
                var result = this.notesBL.RestoreTrash(notesId);
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note restored from trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException });
            }
        }


        [HttpPut("ChangeColour")]
        public IActionResult EditColour(int notesId, string colour)
        {

            try
            {
                var result = this.notesBL.EditColour(notesId, colour);
                if (result == true)
                {
                    return Ok(new { success = true, message = "Colour changed Successfully !!" });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Colour not changed !!" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.InnerException }); ;
            }
        }
    }
}















