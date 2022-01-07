using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface INotesBL
    {
        public bool MakeANote(UserNotes notes);
        IEnumerable<Notes> GetAllNotesData();
        public bool DeleteNotes(long Id);
        UserNotes UpdateNotes(UserNotes usernotes);
        public bool NoteAddtionAsPinned(int notesId, long id);
        public bool Trash(int notesId);
        public bool IsArchive(int notesId);
        public bool EditColour(int notesId, string colour);
        public bool UnArchive(int notesId);
        public bool RestoreTrash(int notesId);
    }
}
        
    
