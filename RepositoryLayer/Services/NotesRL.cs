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

        public bool DeleteNotes(DeleteNote deletenotes)
        {
            {
                try
                {
                    var ValidNote = this.context.NoteTable.Where(Y => Y.Id == deletenotes.Id).FirstOrDefault();
                    if (ValidNote != null)
                    {
                        Notes deleteNote = new Notes();
                        deleteNote.Title = ValidNote.Title;
                        deleteNote.Message = ValidNote.Message;
                        deleteNote.Remainder = ValidNote.Remainder;
                        deleteNote.Colour = ValidNote.Colour;
                        deleteNote.Image = ValidNote.Image;
                        deleteNote.IsArchive = ValidNote.IsArchive;
                        deleteNote.IsPin = ValidNote.IsPin;
                        deleteNote.IsTrash = ValidNote.IsTrash;
                        deleteNote.Createdat = ValidNote.Createdat;
                        deleteNote.Modifiedat = ValidNote.Modifiedat;
                    }
                    //Deleting user details from the database user table 
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
        }

        public IEnumerable<Notes> GetAllNotesData()
        {
            return context.NoteTable.ToList();
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
    }
}
        

    
               
                   
                
                   

                








