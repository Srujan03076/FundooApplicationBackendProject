using BussinessLayer.Interfaces;
using BussinessLayer.Services;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FundooAppLication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesBL notesBL;
        private readonly IMemoryCache memoryCache;
        private readonly FundooContext context;
        private readonly IDistributedCache distributedCache;
        public NotesController(INotesBL notesBL, IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.notesBL = notesBL;
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }
        /// <summary>
        /// API for creating the notes in the web application
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("MakeANote")]
        public IActionResult MakeANote(UserNotes notes)
        {
            try
            {
                var result = this.notesBL.MakeANote(notes);
                if (result != null)
                {
                    return this.Ok(new { Success = true, message = "New note created successfully ", Data = notes });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "New node creation unsuccessful" });
                }

            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for getting all the data from database in the web application
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("GetNotesData")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for updating the data in notes in the web application
        /// </summary>
        /// <param name="usernotes"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("UpdateNotes")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for deleting the notes in the web application
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{Id}/DeleteNotes")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for archiving the note in the web application
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{notesId}/Archive")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API unarchiving the note in the web application
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{notesId}/Unarchive")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for pinning the notes in the web application 
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{notesId}/Pin")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        ///  API for sending the data into trash in the web application
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{notesId}/Trash")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for restore note from trash in the web application
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{notesId}/RestoreTrash")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        ///API for changing the color in notes the web application
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("{notesId}/ChangeColour")]
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
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for adding Images in notes in the web application
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("{notesId}/Image")]
        public IActionResult AddImage(long notesId, IFormFile path)
        {
            try
            {
                var result = this.notesBL.AddImage(notesId, path);
                if (result == true)
                {
                    return this.Ok(new { Status = true, Message = "Image added sucessfully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Image not added" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { Success = false, message = e.Message, InnerException = e.InnerException });
            }
        }
        /// <summary>
        /// API for getting all the data in with the help of redis cache
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllNotesUsingRedisCache")]
        public async Task<IActionResult> GetAllNotesUsingRedisCache()
        {
            var cacheKey = "NoteList";
            string serializedNotesList;
            var NoteList = new List<Notes>();
            var redisNotesList = await distributedCache.GetAsync(cacheKey);
            if (redisNotesList != null)
            {
                serializedNotesList = Encoding.UTF8.GetString(redisNotesList);
                NoteList = JsonConvert.DeserializeObject<List<Notes>>(serializedNotesList);
            }
            else
            {
                NoteList = (List<Notes>)notesBL.GetAllNotesData();
                serializedNotesList = JsonConvert.SerializeObject(NoteList);
                redisNotesList = Encoding.UTF8.GetBytes(serializedNotesList);


            }
            return Ok(NoteList);


        }
    }
}















