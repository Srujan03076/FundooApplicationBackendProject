using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface INotesRL
    {
        public bool MakeANote(UserNotes notes);
        IEnumerable<Notes> GetAllNotesData();
        public bool DeleteNotes(DeleteNote deletenotes);
    }
}
