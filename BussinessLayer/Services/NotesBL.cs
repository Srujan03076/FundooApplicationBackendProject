using BussinessLayer.Interfaces;
using CommonLayer.Model;
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

        public bool DeleteNotes(DeleteNote deletenotes)
        {
            try
            {
                return this.notesRL.DeleteNotes(deletenotes);
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

        public bool MakeANote(UserNotes notes)
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

        
    }
}
