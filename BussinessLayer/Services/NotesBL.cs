using BussinessLayer.Interfaces;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        INotesRL notesRL;
        public NotesBL(INotesRL notesRL)
        {
            this.notesRL = notesRL;

        }
        public bool DeleteNotes(long Id)
        {
            try
            {
                return this.notesRL.DeleteNotes(Id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public IEnumerable<Notes> GetAllNotesData()
        {
            return this.notesRL.GetAllNotesData();
        }
        public UserNotes MakeANote(UserNotes notes)
        {
            try
            {
                return this.notesRL.MakeANote(notes);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool IsArchive(int notesId)
        {
            try
            {
                return this.notesRL.IsArchive(notesId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool NoteAddtionAsPinned(int notesId, long id)
        {
            try
            {
                return notesRL.NoteAdditionAsPinned(notesId, id);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool Trash(int notesId)
        {
            try
            {
                return notesRL.Trash(notesId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public UserNotes UpdateNotes(UserNotes usernotes)
        {
            return this.notesRL.UpdateNotes(usernotes);
        }
        public bool EditColour(int notesId, string colour)
        {
            try
            {
                return notesRL.EditColour(notesId, colour);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool UnArchive(int notesId)
        {
            try
            {
                return notesRL.UnArchive(notesId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool RestoreTrash(int notesId)
        {
            try
            {
                return notesRL.RestoreTrash(notesId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool AddImage(long notesId, IFormFile path)
        {
            try
            {
                return notesRL.AddImage(notesId, path);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}

       
    



























