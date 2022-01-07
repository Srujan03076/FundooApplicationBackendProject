using CommonLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        FundooContext context;
        public NotesRL(FundooContext context)
        {
            this.context = context;
        }

        public bool DeleteNotes(long Id)
        {
            try
            {
                var ValidNote = this.context.NoteTable.Where(Y => Y.Id == Id).FirstOrDefault();

                this.context.NoteTable.Remove(ValidNote);

                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public IEnumerable<Notes> GetAllNotesData()
        {
            return context.NoteTable.ToList();
        }

        public bool IsArchive(int notesId)
        {
            try
            {
                var validNote = this.context.NoteTable.FirstOrDefault(e => e.NotesId == notesId);

                if (validNote != null)
                {
                    validNote.IsArchive = true;
                    validNote.IsTrash = false;
                }
                int result = this.context.SaveChanges();

                if (result > 0) return true;

                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool MakeANote(UserNotes notes)
        {
            try
            {
                Notes newNotes = new Notes();
                newNotes.Title = notes.Title;
                newNotes.Message = notes.Message;
                newNotes.Remainder = notes.Remainder;
                newNotes.Colour = notes.Colour;
                newNotes.Image = notes.Image;
                newNotes.IsArchive = notes.IsArchive;
                newNotes.IsPin = notes.IsPin;
                newNotes.IsTrash = notes.IsTrash;
                newNotes.Id = notes.Id;
                newNotes.Createdat = notes.Createdat;
                //Adding the data to database
                this.context.NoteTable.Add(newNotes);
                //Save the changes in database
                int result = this.context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool NoteAdditionAsPinned(int notesId, long id)
        {
            try
            {
                var validnote = this.context.NoteTable.FirstOrDefault(e => e.NotesId == notesId && e.Id == id);

                if (validnote != null)
                {
                    if (validnote.IsPin == true)
                    {
                        validnote.IsPin = false;
                    }
                    else if (validnote.IsPin == false)
                    {
                        validnote.IsPin = true;
                    }
                }
                int result = this.context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Trash(int notesId)
        {
            try
            {
                var validId = this.context.NoteTable.FirstOrDefault(e => e.NotesId == notesId);

                if (validId != null)
                {
                    validId.IsTrash = true;
                    validId.IsArchive = false;
                }
                int result = this.context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserNotes UpdateNotes(UserNotes usernotes)
        {

            var UpdateNote = this.context.NoteTable.Where(Y => Y.Id == usernotes.Id).FirstOrDefault();
            if (UpdateNote != null)
            {
                UpdateNote.Title = usernotes.Title;
                UpdateNote.Message = usernotes.Message;
                UpdateNote.Remainder = usernotes.Remainder;
                UpdateNote.Colour = usernotes.Colour;
                UpdateNote.Image = usernotes.Image;
                UpdateNote.IsArchive = usernotes.IsArchive;
                UpdateNote.IsPin = usernotes.IsPin;
                UpdateNote.IsTrash = usernotes.IsTrash;
                UpdateNote.Createdat = usernotes.Createdat;


            }
            var result = this.context.SaveChanges();
            if (result > 0)
            {
                return usernotes;
            }
            else
            {
                return default;
            }
        }
        public bool EditColour(int notesId, string colour)
        {
            try
            {
                var validnote = this.context.NoteTable.FirstOrDefault(e => e.NotesId == notesId);

                if (validnote != null)
                {
                    validnote.Colour = colour;
                }
                int result = this.context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UnArchive(int notesId)
        {
            try
            {
                var unarchive = this.context.NoteTable.FirstOrDefault(e => e.NotesId == notesId);

                if (unarchive != null)
                {
                    unarchive.IsArchive = false;
                }
                int result = this.context.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RestoreTrash(int notesId)
        {
            try
            {
                var restoreTrash = this.context.NoteTable.FirstOrDefault(e => e.NotesId == notesId );

                if (restoreTrash != null)
                {
                    restoreTrash.IsTrash = false;
                }
                int result = this.context.SaveChanges();

                if (result > 0) 
                { 
                    return true;
                }
                else 
                { 
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

    


    

    













































