using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ICollaboratorBL
    {
        /// <summary>
        /// Adding the collaborator into notes
        /// </summary>
        /// <param name="collaboration"></param>
        /// <returns></returns>
        public CollabModel AddCollab(CollabModel collaboration, long tokenId);
        /// <summary>
        /// Getting all data from the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<Collaborator> GetCollaborator();
        /// <summary>
        /// Deleting the collaborator from notes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Deletecollab(CollabModel model);
        
    }
}
