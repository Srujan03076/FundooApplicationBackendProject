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
    public class CollaboratorRL : ICollaboratorRL
    {
        FundooContext context;
        public CollaboratorRL(FundooContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// This method implements adding collaborator into notes
        /// </summary>
        /// <param name="collaboration"></param>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        public CollabModel AddCollab(CollabModel collaboration, long tokenId)
        {
            try
            {
                var existingId = this.context.UserTable.Where(x => x.Id == tokenId).FirstOrDefault();
                if (existingId != null)
                {
                    Collaborator collab = new Collaborator();
                    collab.Id = tokenId;
                    collab.NotesId = collaboration.NotesId;
                    collab.EmailId = collaboration.EmailId;
                    this.context.CollaborationTable.Add(collab);
                    this.context.SaveChanges();
                }

                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return collaboration;
                }
                else
                {
                    return collaboration;
                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        /// <summary>
        /// This method implements deletion of collaborator from notes 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteCollab(CollabModel model)
        {
            try
            {
                var deletecollab = this.context.CollaborationTable.FirstOrDefault(e => e.EmailId == model.EmailId);
                if (deletecollab != null)
                {
                    this.context.CollaborationTable.Remove(deletecollab);
                    this.context.SaveChanges();
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
        /// <summary>
        /// This method implements getting all the collaborator from database 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Collaborator> GetCollaborator()
        {
            return this.context.CollaborationTable.ToList();
        }
    }
}
