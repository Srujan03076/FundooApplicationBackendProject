using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        /// <summary>
        /// Creating the notes for user
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        UserNotes MakeANote(UserNotes notes);
        /// <summary>
        /// Getting all the data from database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Notes> GetAllNotesData();
        /// <summary>
        /// Deleting the notes
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteNotes(long Id);
        /// <summary>
        ///  Updating the notes 
        /// </summary>
        /// <param name="usernotes"></param>
        /// <returns></returns>
        public UserNotes UpdateNotes(UserNotes usernotes);
        /// <summary>
        /// Make a note as pinned
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool NoteAdditionAsPinned(int notesId, long id);
        /// <summary>
        /// Make a note moved to trash
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        public bool Trash(int notesId);
        /// <summary>
        /// Make the note archive
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        public bool IsArchive(int notesId);
        /// <summary>
        /// Change the color of note
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="colour"></param>
        /// <returns></returns>
        public bool EditColour(int notesId, string colour);
        /// <summary>
        /// Make the note unarchive
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        public bool UnArchive(int notesId);
        /// <summary>
        /// Restore trash from notes
        /// </summary>
        /// <param name="notesId"></param>
        /// <returns></returns>
        public bool RestoreTrash(int notesId);
        /// <summary>
        /// Add Image in notes
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool AddImage(long notesId, IFormFile path);
    }

}
