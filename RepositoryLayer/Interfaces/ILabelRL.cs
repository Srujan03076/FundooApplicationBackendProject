using CommonLayer.Model;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface ILabelRL
    {
        /// <summary>
        /// Adding the label into notes
        /// </summary>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        LabelModel MakeALabel(LabelModel labelModel);
        /// <summary>
        /// Make changes into label
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        public LabelModel EditLabel(long labelId, LabelModel labelModel);
        /// <summary>
        /// Deleting the label from notes
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteLabel(LabelModel model);
        /// <summary>
        /// Getting All the data
        /// </summary>
        /// <returns></returns>
        IEnumerable<Label> Getlabels();
       
    }
}
