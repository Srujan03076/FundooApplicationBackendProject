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
    }
}
        
    
