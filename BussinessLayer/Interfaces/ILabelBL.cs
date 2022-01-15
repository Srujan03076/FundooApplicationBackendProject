using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Interfaces
{
    public interface ILabelBL
    {
        /// <summary>
        /// Adding the label into notes
        /// </summary>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        LabelModel MakeALabel(LabelModel labelModel);
        /// <summary>
        ///Make changes into label
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        public LabelModel EditLabel(long labelId, LabelModel labelModel);
        /// <summary>
        /// Deleting the label from notes
        /// </summary>
        /// <param name="notesId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Deletelabel(LabelModel model);
        /// <summary>
        ///Getting All the data 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Label> Getlabels();
    }
}
