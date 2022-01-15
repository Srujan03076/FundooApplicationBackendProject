using BussinessLayer.Interfaces;
using CommonLayer.Model;
using RepositoryLayer.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        ILabelRL labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this.labelRL = labelRL;

        }
        public bool Deletelabel( LabelModel model)
        {
            try
            {
                return this.labelRL.DeleteLabel(model);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public LabelModel EditLabel(long labelId, LabelModel labelModel)
        {
            try
            {
                return this.labelRL.EditLabel(labelId, labelModel);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IEnumerable<Label> Getlabels()
        {
            return this.labelRL.Getlabels();
        }
        public LabelModel MakeALabel(LabelModel labelModel)
        {
            try
            {
                return this.labelRL.MakeALabel (labelModel);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
    

