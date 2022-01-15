using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class CollaboratorBL : ICollaboratorBL
    {
        ICollaboratorRL collaboratorRL;
        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this.collaboratorRL = collaboratorRL;

        }
        public CollabModel AddCollab(CollabModel collaboration, long tokenId)
        {
            try
            {
                return this.collaboratorRL.AddCollab(collaboration, tokenId);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public bool Deletecollab(CollabModel model)
        {
            try
            {
                return this.collaboratorRL.DeleteCollab(model);
            }
            catch (Exception e)
            {
                throw;
            }

        }
        public IEnumerable<Collaborator> GetCollaborator()
        {
            return this.collaboratorRL.GetCollaborator();
        }
    }
}

    

