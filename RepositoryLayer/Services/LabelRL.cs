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
    public class LabelRL : ILabelRL
    {
        FundooContext context;
        public LabelRL(FundooContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// This method implements deletion of label from notes 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteLabel(LabelModel model)
        {
            try
            {
                var deletelabel = this.context.LabelTable.FirstOrDefault(e => e.LabelName == model.LabelName);
                if (deletelabel != null)
                {
                    this.context.LabelTable.Remove(deletelabel);
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
        /// This method implements updation of the label in notes 
        /// </summary>
        /// <param name="labelId"></param>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        public LabelModel EditLabel(long labelId, LabelModel labelModel)
        {
            try
            {
                var result = this.context.LabelTable.FirstOrDefault(e => e.LabelId == labelId);
                var checkLabel = this.context.LabelTable.FirstOrDefault(l => l.LabelName == labelModel.LabelName);
                if (result != null && checkLabel == null)
                {
                    result.LabelName = labelModel.LabelName;
                    this.context.SaveChanges();
                    return labelModel;
                }
                else return labelModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// This method implements getting all the labels from database 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Label> Getlabels()
        {
            return context.LabelTable.ToList();
        }
        /// <summary>
        /// This method implements creation of label in notes
        /// </summary>
        /// <param name="labelModel"></param>
        /// <returns></returns>
        public LabelModel MakeALabel(LabelModel labelModel)
        {
            try
            {
                var validnotesId = this.context.NoteTable.Where(x => x.NotesId == labelModel.NotesId).FirstOrDefault();
                var validId = this.context.UserTable.Where(x => x.Id == labelModel.Id).FirstOrDefault();
                if (validnotesId != null && validId !=null)
                {
                    Label label = new Label();
                    label.LabelName = labelModel.LabelName;
                    label.NotesId = labelModel.NotesId;
                    label.Id = labelModel.Id;
                    this.context.LabelTable.Add(label);
                }
                var result = this.context.SaveChanges();
                if (result > 0)
                {
                    return labelModel;
                }
                else
                {
                    return labelModel;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
            
        
    

            

           
        
 

          
        


    
        
           
    

                    

   
 



    

