using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ICollaboratorRL
    {
        /// <summary>
        /// Adding the collaborator into notes
        /// </summary>
        /// <param name="collaboration"></param>
        /// <param name="tokenId"></param>
        /// <returns></returns>
        CollabModel AddCollab(CollabModel collaboration, long tokenId);
        /// <summary>
        /// Deleting the collaborator from notes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteCollab(CollabModel model);
        /// <summary>
        /// Getting all data from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Collaborator> GetCollaborator();
        
    }
}
